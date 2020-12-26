from contextlib import contextmanager
import logging
import threading

from sqlalchemy import create_engine
from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.orm import sessionmaker
from sqlalchemy.orm import scoped_session

import settings

logger = logging.getLogger(__name__)
Base = declarative_base()
engine = create_engine(f'sqlite:///{settings.db_name}?check_same_thread=False')
Session = scoped_session(sessionmaker(bind=engine))
lock = threading.Lock()


@contextmanager
def session_scope():
    """
    session実行
    """
    session = Session()
    session.expire_on_commit = False
    try:
        lock.acquire()
        # sesionを渡す
        yield session
        # 何もなければcommit()
        session.commit() 
    except Exception as e:
        # errorが発生すればrollback()
        logger.error(f'action=session_scope error={e}')
        session.rollback()
        raise
    finally:
        # 最終close()
        session.expire_on_commit = True
        lock.release()


def init_db():
    """
    データベース初期化
    """
    import app.models.candle
    import app.models.events
    Base.metadata.create_all(bind=engine)

