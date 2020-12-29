# セッション変数の取得
from setting import session
from candle import *
import datetime
from history import History
from setting import engine


if __name__ == "__main__":

    with open('data/GBPJPY.5.hst', "rb") as f:
        #Base.metadata.drop_all(bind=ENGINE)
        Base.metadata.create_all(bind=engine)
        h = History(f)
        for record in h:
            #print("{0} Open:{1} High:{2} Low:{3} Close:{4} Volume:{5} Spread:{6} RealVolume:{7}".format(
            #    time.strftime("%Y/%m/%d %H:%M", time.gmtime(record.ctm)),
            #    record.open, record.high, record.low, record.close, record.volume, record.spread, record.real_volume))
            candle = Candle()
            candle.date = datetime.datetime.fromtimestamp(record.ctm)
            candle.open = record.open
            candle.high = record.high
            candle.low = record.low
            candle.close = record.close
            candle.volume = record.volume
            candle.spread = record.spread
            candle.realVolume = record.real_volume
            # DBへ登録
            session.add(candle)

        # コミット
        session.commit()

