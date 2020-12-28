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
    time = Column(DateTime, primary_key=True, nullable=False)
    open = Column(Float)
    close = Column(Float)
    high = Column(Float)
    low = Column(Float)
    volume = Column(Integer)

    @classmethod
    def create(cls, time, open, close, high, low, volume):
        """
        時間足生成(非公開)
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


class UsdJpyBaseCandle1H(BaseCandleMixin, Base):
    __tablename__ = 'USD_JPY_1H'


class UsdJpyBaseCandle1M(BaseCandleMixin, Base):
    __tablename__ = 'USD_JPY_1M'


class UsdJpyBaseCandle5S(BaseCandleMixin, Base):
    __tablename__ = 'USD_JPY_5S'


def factory_candle_class(product_code, duration):
    """
    ファクトリーメソッド
    インスタンスの生成
    """
    if product_code == constants.PRODUCT_CODE_USD_JPY:
        if duration == constants.DURATION_5S:
            return UsdJpyBaseCandle5S
        if duration == constants.DURATION_1M:
            return UsdJpyBaseCandle1M
        if duration == constants.DURATION_1H:
            return UsdJpyBaseCandle1H


def create_candle_with_duration(product_code, duration, ticker):
    """
    時間足candleの生成
    """
    # 通貨情報の取得
    cls = factory_candle_class(product_code, duration)
    # 分情報へ変換
    ticker_time = ticker.truncate_date_time(duration)
    # candle情報の取得
    current_candle = cls.get(ticker_time)
    price = ticker.mid_price
    if current_candle is None:
        # candle足が無ければcandleの生成
        cls.create(ticker_time, price, price, price, price, ticker.volume)
        return True

    # 価格情報の更新
    if current_candle.high <= price:
        current_candle.high = price
    elif current_candle.low >= price:
        current_candle.low = price
    # 出来高の更新
    current_candle.volume += ticker.volume
    current_candle.close = price
    # 価格の保存
    current_candle.save()
    return False

