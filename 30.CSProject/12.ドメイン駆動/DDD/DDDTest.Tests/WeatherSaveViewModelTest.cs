using System;
using System.Collections.Generic;
using DDD.Domain.Entities;
using DDD.Domain.Exceptions;
using DDD.Domain.Repositories;
using DDD.WinForm.ViewsModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DDDTest.Tests {

    /// <summary>
    /// 保存画面用テストクラス
    /// </summary>
    [TestClass]
    public class WeatherSaveViewModelTest {

        /// <summary>
        /// シナリオ
        /// </summary>
        [TestMethod]
        public void 天気登録シナリオ() {

            // WeatherMock用Moqインスタンス
            var weatherMock = new Mock<IWeatherRepository>();

            // Moqインスタンスの生成
            var areasMock = new Mock<IAreasRepository>();

            // Moq用のList作成
            var areas = new List<AreaEntity>();
            areas.Add(new AreaEntity(1, "東京"));
            areas.Add(new AreaEntity(2, "大阪"));

            // Moqのセットアップ
            areasMock.Setup(x => x.GetData()).Returns(areas);



            // モデルをモックとして使用する
            // 値を上書きできるToDateTime
            // テストでは日付の指定で取得し、ViewModelでは現在値が取得できる
            // Returnsで"2020/05/06 22:00:00"を返却する
            // 受けをvirtualにすることでオーバライドでき上書きができる
            // これまではインターフェイスを使用した
            var viewModelMock = new Mock<WeatherSaveViewModel>(weatherMock.Object,areasMock.Object);
            viewModelMock.Setup(x => x.GetDateTime()).Returns(
                Convert.ToDateTime("2020/05/06 22:00:00"));

            var viewModel = viewModelMock.Object;
           // var viewModel = new WeatherSaveViewModel();
            
            // 初期化のテスト
            viewModel.SelectedAreaId.IsNull();
            viewModel.DataDateValue.Is(Convert.ToDateTime("2020/05/06 22:00:00"));
            viewModel.SelectedCondition.Is(1);
            viewModel.TemperatureText.Is("");
            viewModel.TemperatureUnitName.Is("℃");

            // コンボボックスのテスト
            viewModel.Areas.Count.Is(2);
            viewModel.Conditions.Count.Is(4);

            // ボタン処理のテスト
            //viewModel.Save();
            var ex=AssertEx.Throws<InputException>(() => viewModel.Save());
            ex.Message.Is("エリアを指定してください");

            // 入力値のチェック
            viewModel.SelectedAreaId = 2;
            ex = AssertEx.Throws<InputException>(() => viewModel.Save());
            ex.Message.Is("温度の入力に誤りがある");

            viewModel.TemperatureText = "12.345";
            // 保存するためにはWethereEntitiyにアクセス必要（weatherMock生成）

            // Entityのチェックを行う
            weatherMock.Setup(x => x.Save(It.IsAny<WeatherEntity>())).
                Callback<WeatherEntity>(saveValue => {
                    saveValue.AreaId.Value.Is(2);
                    saveValue.DataDate.Is(
                        Convert.ToDateTime("2020/05/06 22:00:00"));
                    saveValue.Condition.Value.Is(1);
                    saveValue.Temperature.Value.Is(12.345f);
                });

            viewModel.Save();
            // Saveのテスト漏れを防ぐ
            // Saveメソッドの実装がされていなかった場合は、Entityのチェックが走らないので
            weatherMock.VerifyAll();

        }
    }
}
