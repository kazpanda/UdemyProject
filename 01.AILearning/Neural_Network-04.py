# -*- coding: utf-8 -*-

'''
テーマ：手書きの数字をデータとして学習させ、違う手書きの数字をアルゴリズムに認識させる仕組みを作っていきます。
'''

'''
まずは、学習用のデータとして手書きにした数字を画像データとして準備して下さい。
（学習用として2つ、検証用として1つ準備して下さい。学習用のデータ1つと、検証用のデータの数字は同じにして下さい。）
手書きの数字をデータにする方法は、（画像の取り込み、画像のデータ化）という講義を参考にして下さい。

そして、準備したデータを以下のtraining_data1の'4-1.png'、
training_data2の'7-1.pngファイルと差し替えて下さい'。
'''


import numpy as np
from PIL import Image

# 画像読込み
training_data1 = Image.open('4-1.png')
# グレー変換
training_data1_grey = training_data1.convert('L')
# 画像反転
training_data1_grey_array = (255- np.array(training_data1_grey))/255 # 255で割って標準化
# 1行配列
training_data1_list = training_data1_grey_array.reshape(1,784)

training_data2 = Image.open('7-1.png')
training_data2_grey = training_data2.convert('L')
training_data2_grey_array = (255- np.array(training_data2_grey))/255 # 255で割って標準化
training_data2_list = training_data2_grey_array.reshape(1,784)

input_data = np.append(training_data1_list,training_data2_list,axis=0)

expected_output = np.array([[0],[1]])

data_number = input_data.shape[0]

input_node = input_data.T.shape[0]
first_node =200
second_node =1

alpha =0.1
epochs=100


def sigmoid(z):
    return 1/ (1 + np.exp(-z))

def sigmoid_prime(z):
    return sigmoid(z)*(1-sigmoid(z))

first_weight = np.random.rand(input_node,first_node)-0.5
second_weight = np.random.rand(first_node,second_node) -0.5

for t in range(epochs):
    for i in range(data_number):
        first_node_input = np.dot(input_data,first_weight)
        first_node_activation = sigmoid(first_node_input)
        second_node_input = np.dot(first_node_activation,second_weight)
        second_node_activation = sigmoid(second_node_input)
        
        # 誤差関数
        d_error = second_node_activation - expected_output
        d_second_node_activation = d_error * sigmoid_prime(second_node_input)
        d_second_node_weight = first_node_activation.T.dot(d_second_node_activation)
        
        d_second_node_input = d_second_node_activation.dot(second_weight.T)
        d_first_node_activation= d_second_node_input * sigmoid_prime(first_node_input)
        d_input_weight = input_data.T.dot(d_first_node_activation)
    
        first_weight =first_weight - alpha * (d_input_weight)
        second_weight = second_weight - alpha * (d_second_node_weight)


'''
検証用のデータの差し替えをします。
検証用に作成したデータを、以下のtest_data内の'7-1.png'ファイルと差し替えて下さい。
'''

# 検証
test_data1 = Image.open('7-1.png')
test_data1_grey = test_data1.convert('L')
test_data1_grey_array = (255- np.array(test_data1_grey))/255 # 255で割って標準化
test_data1_list = test_data1_grey_array.reshape(1,784)

first_node_input = np.dot(test_data1_list,first_weight)
first_node_activation = sigmoid(first_node_input)
second_node_input = np.dot(first_node_activation,second_weight)
second_node_activation = sigmoid(second_node_input)
# 出力層の2層
# 0.5以上は有効と判断
# 入力に対して判断されているか？
# 0-1-1-0に対して、0に近い、1に近い、1に近い、0に近い
print(second_node_activation) 

'''
コードを実行すると、右の実行結果の所に数字が表示されます。この数字が大きければ大きいほど、正しく数字を認識しています。
意図した結果にならない場合は、alphaやepochsの数を変更して改めて結果を確認してみましょう。
'''