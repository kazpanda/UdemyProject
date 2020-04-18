from django.shortcuts import render,redirect
from django.contrib.auth.models import User
from django.contrib.auth import authenticate,login, logout
from .models import BoardModel
from django.contrib.auth.decorators import login_required
from django.views.generic import CreateView
from django.urls import reverse_lazy


# サインアップ関数
def signupfunc(request):
    if request.method =='POST':
        # フォームで入力されたユーザー名の取得
        username2 = request.POST['username']
        # フォームで入力されたパスワードの取得
        password2 = request.POST['password']
        try:
            # Userクラスのユーザー取得メソッドでユーザーが存在しない場合はExceptionが発生する
            User.objects.get(username = username2)
            return render(request,'signup.html',{'error':'このユーザーは登録されています'})
        except:
            user = User.objects.create_user(username2,'',password2)
            return render(request,'signup.html',{'some':100})
    # renderメソッドでのテンプレートとモデルに該当
    return render(request, 'signup.html', {'some':100})


# ログイン関数
def loginfunc(request):
    if request.method =='POST':
        # フォームで入力されたユーザー名の取得
        username2 = request.POST['username']
        # フォームで入力されたパスワードの取得
        password2 = request.POST['password']
        # 認証
        user = authenticate(request, username=username2, password=password2)
        if user is not None:
            login(request, user)
            return redirect('list')
        else:
            return redirect('login')
    return render(request,'login.html')


# リスト関数
# ログインの確認
@login_required
def listfunc(request):
    # 全てのオブジェクトを取得
    object_list = BoardModel.objects.all()
    return render(request,'list.html',{'object_list':object_list})


# ログアウト関数
def logoutfunc(request):
    logout(request)
    return redirect('login')


# 詳細関数
def detailfunc(request,pk):
    # 引数のpkで指定されたidのオブジェクトを取得
    object = BoardModel.objects.get(pk=pk)
    return render(request, 'detail.html',{'object':object}) 


# いいね関数
def goodfunc(request,pk):
    # 引数のpkで指定されたidのオブジェクトを取得
    post = BoardModel.objects.get(pk=pk)
    # DBオブジェクトの変更
    post.good = post.good + 1
    # DBオブジェクトの保存
    post.save()
    return redirect('list')


# 既読関数
def readfunc(request, pk):
    # 引数のpkで指定されたidのオブジェクトを取得
    post = BoardModel.objects.get(pk=pk)
    # ログインしているユーザーの取得
    post2 = request.user.get_username()
    # readtextの中にpost2が含まれているか?    
    if post2 in post.readtext:
        return redirect('list')
    else:
        # DBオブジェクトの変更
        post.read += 1
        post.readtext = post.readtext + ' ' + post2
        # DBオブジェクトの保存
        post.save()
        return redirect('list')    


# 新規作成クラス
# CreateViewを継承
class BoardCreate(CreateView):
    # テンプレートを指定
    template_name = 'create.html'
    # モデルを指定
    model = BoardModel
    # データ入力するフィールドを指定
    fields = ('title','content','author','images')
    # 戻りurlを指定
    success_url = reverse_lazy('list')
    