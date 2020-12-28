import logging
import sys
from threading import Thread

# ストリーム取得
from app.controllers.streamdata import stream
# Webサーバー
from app.controllers.webserver import start
# ロギング設定
logging.basicConfig(level=logging.INFO, stream=sys.stdout)

if __name__ == "__main__":
    # ストリームデータ取得スレッド
    streamThread = Thread(target=stream.stream_ingestion_data)
    # Webサーバースレッド
    serverThread = Thread(target=start)

    # スレッドの開始
    streamThread.start()
    serverThread.start()

    # スレッド終了待機
    streamThread.join()
    serverThread.join()
