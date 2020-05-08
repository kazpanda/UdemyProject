using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleTestApp.ViewsModel;

namespace Test.Tests {
    [TestClass]
    public class SearchViewTest
        {
        [TestMethod]
        public void フォームのシナリオテスト() {

            // インスタンスの生成
            SearchViewModel eViewModel = new SearchViewModel(); 

            // 初期値のテスト
            Assert.AreEqual("", eViewModel.SearchText);
            Assert.AreEqual("****", eViewModel.SearchLabel);

            // ボタンのテスト
            eViewModel.SearchText = "1";
            Assert.AreEqual("1", eViewModel.SearchText);
            eViewModel.Search();
            Assert.AreEqual("Hit!!!", eViewModel.SearchLabel);


        }
    }
}
