using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TDD.UI;

namespace TDDTest.Tests {
    [TestClass]
    public class Form1ViewModelTest {
        [TestMethod]
        public void シナリオ() {

            // Moqを使ったモック
            var mock = new Mock<IDB>();
            // 変数に割り当てる
            mock.Setup(x => x.GetDBValue()).Returns(100);
            var viewModel = new Form1ViewModel(mock.Object);

            // テストから呼ばれるDBはMockが呼ばれる
            //var viewModel = new Form1ViewModel(new DBMock());
            Assert.AreEqual("", viewModel.ATextBoxText);
            Assert.AreEqual("", viewModel.BTextBoxText);
            Assert.AreEqual("", viewModel.ResultLabelText);

            viewModel.ATextBoxText = "2";
            viewModel.BTextBoxText = "5";
            viewModel.CalculationAction();
            Assert.AreEqual("107", viewModel.ResultLabelText);
        }
    }

    /// <summary>
    /// データベーステスト用モック
    /// テストしか使用しないのでinternal
    /// インターフェイスを継承するので実装が必要
    /// </summary>
    //internal class DBMock : IDB {

    //    /// <summary>
    //    /// テスト用データベース 
    //    /// 実装する
    //    /// </summary>
    //    /// <returns></returns>
    //    public int GetDBValue() {
    //        return 100;
    //    }
    //}
}
