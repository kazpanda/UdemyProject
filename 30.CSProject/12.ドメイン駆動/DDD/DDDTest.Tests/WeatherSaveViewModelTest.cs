using System;
using DDD.WinForm.ViewsModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DDDTest.Tests {
    [TestClass]
    public class WeatherSaveViewModelTest {
        [TestMethod]
        public void 天気登録シナリオ() {

            // モデルをモックとして使用する
            // 値を上書きできるToDateTime
            // テストでは日付の指定で取得し、ViewModelでは現在値が取得できる
            // Returnsで"2020/05/06 22:00:00"を返却する
            // 受けをvirtualにすることでオーバライドでき上書きができる
            // これまではインターフェイスを使用した
            var viewModelMock = new Mock<WeatherSaveViewModel>();
            viewModelMock.Setup(x => x.GetDateTime()).Returns(
                Convert.ToDateTime("2020/05/06 22:00:00"));

            var viewModel = viewModelMock.Object;
           // var viewModel = new WeatherSaveViewModel();
            
            // 初期化のテスト
            viewModel.SelectedAreaId.IsNull();
            viewModel.DataDateValue.Is(Convert.ToDateTime("2020/05/06 22:00:00"));
            viewModel.SelectedCondition.Is(1);
            viewModel.TemperatureText.Is("");


        }
    }
}
