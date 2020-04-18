# プロジェクト側（最上位) urls.py
from django.contrib import admin
from django.urls import path,include

urlpatterns = [
    # adminの表示
    path('admin/', admin.site.urls),
    # アプリ内のurls.pyと連結
    path('',include('todo.urls'))
]
