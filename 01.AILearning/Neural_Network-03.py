# -*- coding: utf-8 -*-

import numpy as np
from PIL import Image

# 画像読込み
data1 = Image.open('4-1.png')
# グレー変換
data1_grey = data1.convert('L')
# 画像反転
data1_grey_array = (255- np.array(data1_grey))/255 # 255で割って標準化
data1_grey_list = data1_grey_array.reshape(1,784)


