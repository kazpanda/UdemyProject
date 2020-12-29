DURATION_5S = '5s'
DURATION_1M = '1m'
DURATION_1H = '1h'
DURATION_4H = '4h'
DURATION_1D = '1d'

DURATIONS = [DURATION_5S, DURATION_1M, DURATION_1H, DURATION_4H, DURATION_1D]

GRANULARITY_5S = 'S5'
GRANULARITY_1M = 'M1'
GRANULARITY_1H = 'H1'
GRANULARITY_4H = 'H4'
GRANULARITY_1D = 'D1'

TRADE_MAP = {
    DURATION_5S: {
        'duration': DURATION_5S,
        'granularity': GRANULARITY_5S,
    },
    DURATION_1M: {
        'duration': DURATION_1M,
        'granularity': GRANULARITY_1M,
    },
    DURATION_1H: {
        'duration': DURATION_1H,
        'granularity': GRANULARITY_1H,
    },
    DURATION_4H: {
        'duration': DURATION_4H,
        'granularity': GRANULARITY_4H,
    },
    DURATION_1D: {
        'duration': DURATION_1D,
        'granularity': GRANULARITY_1D,
    }
}

BUY = 'BUY'
SELL = 'SELL'

PRODUCT_CODE_USD_JPY = 'USD_JPY'
PRODUCT_CODE_GBP_JPY = 'GBP_JPY'

