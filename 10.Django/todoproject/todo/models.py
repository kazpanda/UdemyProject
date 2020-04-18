from django.db import models

# Create your models here.

# タプル型にて定数を割り当てる
PRIORITY = (('danger','high'),('info','normal'),('success','low'))
# モデルの生成
class TodoModel(models.Model):
    # titleフィールド
    title = models.CharField(max_length=100)
    # memoフィールド
    memo = models.TextField()
    # priorityフィールド
    priority = models.CharField(
        max_length = 50,
        choices = PRIORITY
    )
    # duedateフィールド
    duedate = models.DateField()
    # 戻り値にtitleの文字を返却する   
    def __str__(self):
        return self.title