# 12.ドメイン駆動開発
ドメイン駆動開発

## プロジェクト構成
### Domain
・Repositories
  データの永続化
  インターフェイスを提供
  ・IWeatherEntitiy
    DataTableを使用せずカスタムクラス（Entitiy）を使用する

・ValueObject
  フォルダー名は分かりやすく。機能毎やシステム毎など





・Entities
  データの運び方
  一意性のあるデータのひとかたまり
  SQLなどで取得するデータ1行分
  型はDBの型をC#の型に置き換えたもの

  ・WethereEntity
    DataTableは使わない→カスタムクラスを使う
      遅い
      スペルミスをしてもコンパイルエラーにならない
      テストコードが書きにくい
    値とロジックを持つことで、ビジネスが集約される

・Helpers


・ValueObject
  値として扱うクラス
  完全コンストラクタパターン（これは絶対）
  値とロジックを一体化させる
  現場でバグが生まれるのは値を基本の型で動かすから
  現場でロジックが散らばる原因は値を基本の型で動かすから
  DBの項目はすべてValueObjectにできるが、全てはできない
  ビジネスロジックがあるものは全てValueObjectにする
  DBからintで取ってきたものは、できるだけ早くValueObject（値とロジック）にする



### Infrastructure
・
・
・
・


### WinForm
・ViewとViewModelに分類する
・TestはViewModelに対して行う
・
  ・WeathrLatestViewModel
    2つのコンストラクターで評価と本番の切替ができる
    メソッドはValueObjectにすることで、ViewModelにはメソッドはなくなる
    ViewModelではValueObjectを表示するだけ


### Test.Tests
・すべてのプロジェクトのテストを行う
・
・
・

## その他
・parameterizedtestは便利ツール
  テスト引数をパラメータ化できる
・クラスの型を作ってパラメータ化する。可読性が良くなる
  質問と回答を変数化し引数で渡してあげる

## ゴール
・コード内に仕様がわかる
・必要なコードのみになる
・リファクタリングが可能。心配しなくてよい

## TDDについて
・後からテストを書くと必要なパターンが漏れる
・カバレッジは抜けても分からない
・privateはどうする？
  publicにする




