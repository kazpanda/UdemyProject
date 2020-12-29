# -*- coding: utf-8 -*-
import collections
import mmap
import struct


class History:
    """
    .hst ファイルを collection にマップするクラス
    各レコードは以下の値を持つ

    ctm: レコードの時間（1970/1/1 からの秒）
    open: 始値
    high: 高値
    low: 安値
    close: 終値
    volume: 出来高

    以下は version 401
    spread: スプレッド
    real_volume: 実出来高？
    """

    def __init__(self, file):
        self.mm = mmap.mmap(file.fileno(), 0, access=mmap.ACCESS_READ)

        # Read Header
        self.version, self.copyright, self.symbol, self.period, self.digits, self.timesign, self.last_sync = \
            struct.unpack("<i64s12s4i", self.mm[:96])

        # Check version and detect record structure
        self.header_size = 148
        if self.version == 400:
            self.record_size = 44
            self.record_struct = struct.Struct("<i5d")
            self.candle = collections.namedtuple(
                'Candle', ['ctm', 'open', 'low', 'high', 'close', 'volume'])
        elif self.version == 401:
            self.record_size = 60
            self.record_struct = struct.Struct("<q4dqiq")
            self.candle = collections.namedtuple(
                'Candle', ['ctm', 'open', 'high', 'low', 'close', 'volume', 'spread', 'real_volume'])
        else:
            raise NotImplementedError

        self.len = int((len(self.mm) - self.header_size) / self.record_size)

    def __len__(self):
        return self.len

    def __getitem__(self, i):
        if i < 0 or self.len <= i:
            raise IndexError

        pivot = self.header_size + self.record_size * i
        return self.candle(*self.record_struct.unpack(self.mm[pivot:pivot + self.record_size]))
