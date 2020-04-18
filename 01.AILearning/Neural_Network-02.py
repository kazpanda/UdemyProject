# -*- coding: utf-8 -*-

import numpy as np

input_data = np.array([[0,0],[0,1],[1,0],[1,1]])
expected_output = np.array([[0],[1],[1],[0]])

data_number = input_data.shape[0]

input_node = input_data.T.shape[0]
first_node =3
second_node =1

alpha =0.1
epochs=10000

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

# 検証
first_node_input = np.dot(input_data,first_weight)
first_node_activation = sigmoid(first_node_input)
second_node_input = np.dot(first_node_activation,second_weight)
second_node_activation = sigmoid(second_node_input)
# 0.5以上は有効と判断
# 入力に対して判断されているか？
# 0-1-1-0に対して、0に近い、1に近い、1に近い、0に近い
print(second_node_activation) 
       