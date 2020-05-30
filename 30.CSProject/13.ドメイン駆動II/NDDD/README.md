# 13.ドメイン駆動
* ドメイン駆動学習用

## 1.プロジェクト構成
* プロジェクトを分ける理由は、可読性を高める、保守性高める
* 新しいテクノロジーが出てきたとき、プロジェクトを変更するの載せ替えられる

### Domain
* ビジネスロジック
* どこも参照しない。見られるだけ
* C#プレーンなコードを書く


### Infrastructure
* アプリケーションの外側と接触するもの
* Domainを参照する
* SQL、ファイルアクセス、通信 外部のテクノロジーが変化したらここだけ変更する
* Applicationは必要か？冗長化になる、ビジネスロジック、ViewModelどちらか迷う


### WinForm
* 画面
* DomainとInfrastructure
* 時代とともに変化する ここだけ変更する


### NDDDTest.Tests
* ユニットテスト
* 全て参照


## 2.Domainのフォルダー構成

### Entities
* 一意なデータの塊、データベース１行、行の中で完結するロジックの置き場所


### Exceptions
* Exceptionを継承した例外クラスの集まり
* 基本的に異常は例外で表す
* 戻り値をboolにして判断しない
* 呼び元にifを書かせない
* 値が戻ったら正常、エラー時はcatchで


### Helpers
* staticでどこにあってもいいもの
* 害がないもの。桁を揃えるとか
* マイクロソフトが作ってくれたら不要だったよ！的なもの
* ビジネスロジックが無い[Logicsとの比較]
　

### Repositories
* アプリケーションの外部と接触する部分は全てインターフェイスを作る
* テストの容易性


### ValueObjects
* 値として扱うクラス
* 数字の「3」等をそのまま扱うとビジネスロジックが散らばるためValueObjectの「3」として扱う
* データベースの列のValueObject化が有効


### StaticValues
* 値をキャッシュとして保存する場合


### Logics
* Staticでビジネスロジックを含むもの
* 診断ロジックなど


## 3.Infrastructureのフォルダー構成

* 外部機器と接触するもの

### なぜ外部との接触を集めるのか？

* 外部の影響を局所化する
* テスト容易性

### フォルダー構成

*テクノロジーごとにフォルダーを分ける
* 外部にアクセス部分のロジックのみを記述
* Domain層のRepositoryにあるインターフェースを使う
* SQLServer
* Csv
* 外部機器
* Fake ダミーデータ
* Factoryパターン 本番コードとFakeパターンを切り替える


## 4.WinFormのフォルダー構成

### ユーザーインターフェース層

* 時代の変化とともに変化する部分

### ビジネスロジックとの分離

* MVVMパターンの適応
* ドメイン層やインフラストラクチャー層の機能を選ぶ

### フォルダー構成

* ViewModels
* Views
* BackgroundWorkers


### タイマーイベントはどこに入れる？

* イベントはユーザーインターフェイス層でのみ発生させる
* 理由：保守性を上げるため。修正時に追いやすいコード
* 勝手に動いているものがあると大変


## 5.Testsのフォルダー構成
* テストコードのみを書く

### フォルダー構成
* 本番コードの構成
* Domain.ValueObjects.MeasureValueクラスなら
  Domain.ValueObjects.MeasureValueTestsのテストクラスを作る
 

### ViewModelへのテスト
* 基本的にViewModelに対してテストを書けばOK

### Infrastructureのテスト
* 不要
* Moqにて代用

### 画面のテスト
* 不要
* ViewModelに対してテストを書けばOK
* 実際の画面は目で見てテストする

### ChainingAssertion
* お勧めの支援ツール


## 6.インスタンスを生成する
* インスタンスの生成はFactoriesに集約する
* Factories経由でしか生成できなくする publicではなくinternal

## 7.設定の外部ファイル化
* 参照からSystem.Configurationを追加
* App.configの変更
* NDDD.configの追加

## 8.ValueObjectについて
* ValueObjectは、値＋ロジック
* 値にビジネスロジックがあればValueObject化する
* 問題点
* ValueObjectはクラスなので、値が同じでもイコールにはならない（参照型なので）
* 抽象クラスを用意して、イコールイコール問題を対処する

## 9.オブジェクト指向の自動化
1.DBの列をすべてValueObjectにする
  ビジネスロジックが無ければ不要かもしれない
2.DBの値を運ぶ形でEntityにする（モデル）
  Select分相当のEntityにValueObjectに乗せる
3.外部接触部はリポジトリーにする
  リポジトリー経由で値をとってくる
  ここまでで、8割のクラス分けができる
  複合的ValueObjectなビジネスロジックはEntityにて書く

## 10.Repositoryの具象クラス
* DBから取ってきた値にビジネスロジックを書く場合、ViewModelに書くとロジックが散らばる
* SQLで取ってきて加工して渡すだけなら、Repositoryの具族クラスに書くことも検討

Infrastructure層はシンプルに値だけをとる

