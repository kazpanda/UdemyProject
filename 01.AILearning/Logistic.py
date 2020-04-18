#!/usr/bin/env python3
# -*- coding: utf-8 -*-
import numpy as np
import matplotlib.pyplot as plt

'''
テーマ：飲酒量・喫煙量（入力データ）と、体調（生活習慣病か健康か）のデータを元に学習をさせ、ある飲酒量、喫煙量の場合においてその人が
生活習慣病か健康化を分類するための直線が引かれたグラフを作成するものです。
以下のinput_dataの値を変更・追加することによって入力データを追加・変更することができます。
例：[1,1,0]のデータは、左から飲酒量、喫煙量、生活習慣病/健康（生活習慣病の場合は1、健康の場合は0）を示しています。
'''

# 入力データ
input_data = np.array([[1, 1, 0], [1, 4, 0], [3, 1, 0], [4, 5, 1], [0, 5, 1]])
data_number = input_data.shape[0]

'''
以下のepochsが学習させる回数、alphaが一度に学習させる程度の大きさを示しています（単回帰分析と同じです）。
上記のデータを色々変化させた上でコードを実行し、結果があまり良くなかった場合は（うまく分類する直線を引くことが
できなかった場合は）、epochsの値と、alphaの値を変更させた上で改めて実行してみて下さい。
'''

epochs = 10000
alpha = 0.1

# 初期データ
b0 = 0.1
b1 = 0.1
b2 = 0.1

for t in range(epochs):
    db0 = 0
    db1 = 0
    db2 = 0
    L = 1  # 0だと例外が発生する
    for i in range(data_number):
        # シグモイド関数
        Z = b0 + b1*input_data[i, 0] + b2*input_data[i, 1]
        S = 1 / (1 + np.exp(-Z))

        if input_data[i, 2] == 1:
            # 生活習慣病における尤度関数の傾き
            db0 = db0 + (1-S)
            db1 = db1 + (1-S)*input_data[i, 0]
            db2 = db2 + (1-S)*input_data[i, 1]

            # Liklihood 尤度関数 = 1/(1-シグモイド関数)
            L = L*(1 / (1 + np.exp(-Z)))

        else:
            # 健康における尤度関数の傾き
            db0 = db0 - S
            db1 = db1 - S*input_data[i, 0]
            db2 = db2 - S*input_data[i, 1]

            # Liklihood 尤度関数 = 1/(1-シグモイド関数)
            L = L*(1 - (1 / (1 + np.exp(-Z))))

    # 最急降下法における傾き
    b0 = b0 + alpha*(db0)
    b1 = b1 + alpha*(db1)
    b2 = b2 + alpha*(db2)
    # 尤度関数のグラフ表示
#    plt.scatter(t,L)


x = np.linspace(0, 7, 100)
y = -b0/b2 - b1/b2*x
plt.plot(x, y)


for n in range(data_number):
    plt.scatter(input_data[n, 0], input_data[n, 1])
