# アプリケーション側 urls.py
from django.urls import path
from .views import TodoList,TodoDetail,TodoCreate,TodoDelete,TodoUpdate

# ここでページに名前を割り当てる
urlpatterns = [
    # リスト表示(views.pyのクラスを指定)
    path('list/', TodoList.as_view(), name='list'),
    # 詳細表示(views.pyのクラスを指定)
    path('detail/<int:pk>',TodoDetail.as_view(), name ='detail'),
    # 新規作成表示(views.pyのクラスを指定)
    path('create/',TodoCreate.as_view(), name= 'create'),
    # 削除(views.pyのクラスを指定)
    path('delete/<int:pk>',TodoDelete.as_view(), name= 'delete'),
    # 更新(views.pyのクラスを指定)
    path('update/<int:pk>',TodoUpdate.as_view(), name= 'update'),
]
