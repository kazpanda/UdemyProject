using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AnalyzeSample;
using System.Collections.Generic;
using AnalyzeSample.ViewsModel;

/// <summary>
/// Arrange:テストの事前条件のセットアップ
/// ACT:テストの対象となるアクション実行
/// Assert：振る舞いが期待どおりであることの検査
/// </summary>
namespace Test.Tests {

    /// <summary>
    /// Moqを使用したモックのサンプル
    /// ChainingAssertionを使用し例外のサンプル
    /// </summary>
    [TestClass]
    public class AnalyzeViewModelTest {

        /// <summary>
        /// AnalyzeViewModelに対するテスト
        /// </summary>
        [TestMethod]
        public void シナリオ_OK() {

            // Moqを使ったモック
            // インターフェイスでインスタンス生成
            var eMock = new Mock<IDataBase>();

            // Moqを使用しメソッドの戻り値を定義
            eMock.Setup(x => x.GetDataBaseValue()).Returns(100);

            // ViewModelはMoqを使用してインスタンスを生成する
            var eViewModel = new AnalyzeViewModel(eMock.Object);

            // テストの実行
            // 初期化テスト
            Assert.AreEqual("", eViewModel.ATextBoxText);
            Assert.AreEqual("", eViewModel.BTextBoxText);
            Assert.AreEqual("", eViewModel.ResultLabelText);

            // 分析ボタンのテスト
            eViewModel.ATextBoxText = "2";
            eViewModel.BTextBoxText = "5";
            eViewModel.Analyze();
            // ①MSTestの構文
            Assert.AreEqual("107", eViewModel.ResultLabelText);
            // ②ChainingAssertionの構文 ①②とも同じだが②が可読性が高い
            eViewModel.ResultLabelText.Is("107");


            // 例外のテスト
            eViewModel.ATextBoxText = "-1";
            eViewModel.BTextBoxText = "5";
            // これだけで例外のテストが出来るが、戻り値からメッセージのテストもできる
            var ex = AssertEx.Throws<InputException>(() => eViewModel.Analyze());
            ex.Message.Is("入力値異常");

        }


        /// <summary>
        /// ビジネスロジックのテスト
        /// </summary>
        [TestMethod]
        public void 合計値のテスト_OK() {
            var val = AnalyzeSample.Analyze.Sum(2, 5);
            Assert.AreEqual(7, val);
        }



        [TestMethod] 
        public void 平均値を取得できる_OK() {
            var list = new List<int> { 1, 2, 3, 4, 5 };
            var result = AnalyzeSample.Analyze.Ave(list);
            Assert.AreEqual(3, result);
        }
    }
       
}
