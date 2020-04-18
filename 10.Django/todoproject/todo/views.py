from django.shortcuts import render
from django.views.generic import ListView, DetailView, CreateView, DeleteView,UpdateView
from .models import TodoModel
from django.urls import reverse_lazy

# リスト表示クラス
class TodoList(ListView):
    # 表示するhtmlの指定
    template_name = 'list.html'
    # Modelの指定
    model = TodoModel

# 詳細表示クラス
class TodoDetail(DetailView):
    # 表示するhtmlの指定
    template_name = 'detail.html'
    # Modelの指定
    model = TodoModel

# 新規作成クラス
class TodoCreate(CreateView):
    # 作成するhtmlの指定
    template_name = 'create.html'
    # Modelの指定
    model = TodoModel
    # 更新fieldの指定
    fields = ('title','memo','priority','duedate')
    # 更新成功時の戻り名(名前で指定)
    success_url = reverse_lazy('list')

# 削除クラス
class TodoDelete(DeleteView):
    # 削除するhtmlの指定
    template_name = 'delete.html'
    # Modelの指定
    model = TodoModel
    # 更新成功時の戻り名(名前で指定)
    success_url = reverse_lazy('list')

# 更新クラス
class TodoUpdate(UpdateView):
    # 更新するhtmlの指定
    template_name = 'update.html'
    # Modelの指定
    model = TodoModel
    # 更新fieldの指定
    fields = ('title','memo','priority','duedate')
    # 更新成功時の戻り名(名前で指定)
    success_url = reverse_lazy('list')
