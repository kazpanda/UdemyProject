# -*- coding: utf-8 -*-

import numpy as np
import matplotlib.pyplot as plt

'''
テーマ：気温（入力データ）とビールの売上（出力データ）を元に学習をさせ、ある気温の時のビールの売り上げを予想する直線をグラフに表すものです。
'''

'''
以下のinput_dataの値を変更・追加することによって入力データを追加・変更することができます。
例：[20,30]の左のデータは気温を、右のデータはビールの売上（本数）を示しています。

好きな数字を入力して、結果を確認してみましょう。
'''
input_data = np.array([[20,30],[23,32],[28,40],[30,44]])
data_number = input_data.shape[0]


'''
以下のepochsが学習させる回数、alphaが（表現が難しいのですが）一度に学習させる程度の大きさを示しています。
上記のデータを色々変化させた上でコードを実行し、結果があまり良くなかった場合は（それらしい直線を引くことが
できなかった場合は）、epochsの値と、alphaの値を変更させた上で改めて実行してみて下さい。

epochsとalphaについて詳しく知りたい方は、「最急降下法」という講義内容を参考にして下さい。

'''
epochs = 100
alpha = 0.00005


'''
w0とw1は直線を引く際の初期の切片と傾きを示しています。
詳しく知りたい方は、最小二乗の定義の所からの一連の講義内容を参考にして下さい。
'''

# 重み
w0 = 0.1
w1 = 0.1

# 誤差関数
# (w0) + w1x1 - y1)^2
# =w0^2 + w1^2x1^2 + y1^2 + 2w0w1x1 - 2w1x1y1 - 2y1w0

# 偏微分
for t in range(epochs):
    # 傾きの初期化
    dw0 = 0
    dw1 = 0
    for i in range(data_number):
        dw0 = dw0 + 2*w0 + 2*w1*input_data[i,0] - 2*input_data[i,1]
        dw1 = dw1 + input_data[i,0]*(2*w1*input_data[i,0] + 2*w0 - 2*input_data[i,1])

        '''
        誤差関数を下記します（使う場合は上のdw1の式の下に追記して下さい）。入力データを色々と変更させた上で誤差関数の値を確認し、
        学習する度に誤差の値が小さくなっているかを確認してみて下さい。
        error = w1**2 + w1**2*input_data[i,0] + input_data[i,1]**2 - 2*w1*input_data[i,0]*input_data[i,1] - 2*input_data[i,1]*w0
        
        （誤差を確認するには、下のw1の下にprint(error)と入力して下さい。）
        
        誤差関数について詳しく知りたい方は、誤差関数と最小値の求め方、という講義内容を参考にして下さい。
        '''
    
    # 重み
    w0 = w0 - alpha*(dw0)
    w1 = w1 - alpha*(dw1)


# グラフの設定
x = np.linspace(15,35,100)
y = w0 + w1*x

# グラフの描画
plt.plot(x,y)

# データの描画
for u in range(data_number):
    plt.scatter(input_data[u,0], input_data[u,1])
