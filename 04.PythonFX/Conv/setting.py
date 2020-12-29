from contextlib import contextmanager
import logging
import threading

from sqlalchemy import create_engine
from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.orm import sessionmaker
from sqlalchemy.orm import scoped_session

logger = logging.getLogger(__name__)
# mysqlのDBの設定
DATABASE = 'sqlite:///candle.db'
engine = create_engine(
    DATABASE,
    encoding="utf-8",
    echo=False  # Trueだと実行のたびにSQLが出力される
)
Session = scoped_session(sessionmaker(bind=engine))
lock = threading.Lock()

# Sessionの作成
session = scoped_session(
    # ORM実行時の設定。自動コミットするか、自動反映するなど。
    sessionmaker(autocommit=False, autoflush=False, bind=engine))

# modelで使用する
Base = declarative_base()
Base.query = session.query_property()


@contextmanager
def session_scope():
    session = Session()
    session.expire_on_commit = False
    try:
        lock.acquire()
        yield session
        session.commit()
    except Exception as e:
        logger.error(f'action=session_scope error={e}')
        session.rollback()
        raise
    finally:
        session.expire_on_commit = True
        lock.release()


def init_db():
    """
    初期化
    """
    import app.models.candle
    Base.metadata.create_all(bind=engine)