import logging

from sqlalchemy import Column
from sqlalchemy import desc
from sqlalchemy import DateTime
from sqlalchemy import Float
from sqlalchemy import Integer
from sqlalchemy.exc import IntegrityError

from app.models.base import Base
from app.models.base import session_scope

import constants


logger = logging.getLogger(__name__)


class BaseCandleMixin(object):
    """
    candleモデルクラス
    """
    time = Column(DateTime, primary_key=True, nullable=False)
    open = Column(Float)
    close = Column(Float)
    high = Column(Float)
    low = Column(Float)
    volume = Column(Integer)

    @classmethod
    def create(cls, time, open, close, high, low, volume):
        """
        candleの作成
        """
        candle = cls(time=time,
                     open=open,
                     close=close,
                     high=high,
                     low=low,
                     volume=volume)
        try:
            with session_scope() as session:
                session.add(candle)
            return candle
        except IntegrityError:
            return False

    @classmethod
    def get(cls, time):
        """
        candleの取得（時間足）
        """
        with session_scope() as session:
            candle = session.query(cls).filter(
                cls.time == time).first()
        if candle is None:
            return None
        return candle

    def save(self):
        with session_scope() as session:
            session.add(self)

    @classmethod
    def get_all_candles(cls, limit=100):
        """
        candleの取得（全て）
        """
        with session_scope() as session:
            candles = session.query(cls).order_by(
                desc(cls.time)).limit(limit).all()

        if candles is None:
            return None

        candles.reverse()
        return candles

    @property
    def value(self):
        return {
            'time': self.time,
            'open': self.open,
            'close': self.close,
            'high': self.high,
            'low': self.low,
            'volume': self.volume,
        }

class GbpJpyBaseCandle1D(BaseCandleMixin, Base):
    """
    ファクトリークラス
    """
    __tablename__ = 'GBP_JPY_1D'


class GbpJpyBaseCandle4H(BaseCandleMixin, Base):
    """
    ファクトリークラス
    """
    __tablename__ = 'GBP_JPY_4H'

class GbpJpyBaseCandle1H(BaseCandleMixin, Base):
    """
    ファクトリークラス
    """
    __tablename__ = 'GBP_JPY_1H'


class GbpJpyBaseCandle1M(BaseCandleMixin, Base):
    """
    ファクトリークラス
    """
    __tablename__ = 'GBP_JPY_1M'


class GbpJpyBaseCandle5S(BaseCandleMixin, Base):
    """
    ファクトリークラス
    """
    __tablename__ = 'GBP_JPY_5S'


class UsdJpyBaseCandle1D(BaseCandleMixin, Base):
    """
    ファクトリークラス
    """
    __tablename__ = 'USD_JPY_1D'


class UsdJpyBaseCandle4H(BaseCandleMixin, Base):
    """
    ファクトリークラス
    """
    __tablename__ = 'USD_JPY_4H'

class UsdJpyBaseCandle1H(BaseCandleMixin, Base):
    """
    ファクトリークラス
    """
    __tablename__ = 'USD_JPY_1H'


class UsdJpyBaseCandle1M(BaseCandleMixin, Base):
    """
    ファクトリークラス
    """
    __tablename__ = 'USD_JPY_1M'


class UsdJpyBaseCandle5S(BaseCandleMixin, Base):
    """
    ファクトリークラス
    """
    __tablename__ = 'USD_JPY_5S'


def factory_candle_class(product_code, duration):
    """
    ファクトリ生成
    """
    if product_code == constants.PRODUCT_CODE_GBP_JPY:
        if duration == constants.DURATION_5S:
            return GbpJpyBaseCandle5S
        if duration == constants.DURATION_1M:
            return GbpJpyBaseCandle1M
        if duration == constants.DURATION_1H:
            return GbpJpyBaseCandle1H
        if duration == constants.DURATION_4H:
            return GbpJpyBaseCandle4H
        if duration == constants.DURATION_1D:
            return GbpJpyBaseCandle1D
    elif product_code == constants.PRODUCT_CODE_USD_JPY:
        if duration == constants.DURATION_5S:
            return UsdJpyBaseCandle5S
        if duration == constants.DURATION_1M:
            return UsdJpyBaseCandle1M
        if duration == constants.DURATION_1H:
            return UsdJpyBaseCandle1H
        if duration == constants.DURATION_4H:
            return UsdJpyBaseCandle4H
        if duration == constants.DURATION_1D:
            return UsdJpyBaseCandle1D


def create_candle_with_duration(product_code, duration, ticker):
    """
    candleの生成
    tick情報から生成する
    新規作成=True,更新=False
    """
    cls = factory_candle_class(product_code, duration)
    ticker_time = ticker.truncate_date_time(duration)
    current_candle = cls.get(ticker_time)
    price = ticker.mid_price
    # 時間足テーブルが無ければテーブルを作成する
    if current_candle is None:
        cls.create(ticker_time, price, price, price, price, ticker.volume)
        return True

    # 価格更新
    if current_candle.high <= price:
        current_candle.high = price
    elif current_candle.low >= price:
        current_candle.low = price
    # 出来高更新    
    current_candle.volume += ticker.volume
    current_candle.close = price
    # candle保存
    current_candle.save()
    return False
