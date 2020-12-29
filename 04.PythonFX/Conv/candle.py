from sqlalchemy import Column, Integer, Float, DateTime, Date
from setting import Base


class Candle(Base):
    """
    足データモデル
    """
    __tablename__ = 'candle'
    #id = Column('id', Integer, primary_key=True)
    date = Column('datetime', DateTime, primary_key=True)
    open = Column('open', Float)
    high = Column('high', Float)
    low = Column('low', Float)
    close = Column('close', Float)
    volume = Column('volume', Integer)
    spread = Column('spread', Integer)
    realVolume = Column('realVolume', Integer)
