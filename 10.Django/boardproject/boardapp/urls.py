-from django.urls import path
from .views import signupfunc, loginfunc, listfunc, logoutfunc, detailfunc, goodfunc, readfunc, BoardCreate

urlpatterns = [
    # サインアップ関数を呼ぶ
    path('signup/',signupfunc,name ='signup'),
    # ログイン関数
    path('login/',loginfunc,name='login'),
    # リスト関数
    path('list/',listfunc,name='list'),
    # ログアウト関数
    path('logout/',logoutfunc, name='logout'),
    # 詳細関数 主キー付き
    path('detail/<int:pk>', detailfunc, name='detail'),
    # いいね関数 主キー付き
    path('good/<int:pk>', goodfunc, name='good'),
    # 既読関数 主キー付き
    path('read/<int:pk>', readfunc, name='read'),
    # 新規作成くラスを呼ぶ クラスの場合は、as_viewでクラスを関数化
    path('create/', BoardCreate.as_view(), name='create'),
]
