using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using DDD.WinForm.ViewsModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace DDDTest.Tests {

    /// <summary>
    /// ViewModelのテスト
    /// 直接フォームのテストは行わない（privateなのでアクセスできない）
    /// </summary>
    [TestClass]
    public class WeathrLatestViewModelTest {

        /// <summary>
        /// シナリオテスト
        /// Moqを使用したTest方法
        /// </summary>
        [TestMethod]
        public void シナリオ１() {

            // Moqインスタンスの生成
            var weatherMock = new Mock<IWeatherRepository>();
            // Moqのセットアップ
            weatherMock.Setup(x => x.GetLatest(1)).Returns(
                //完全コンストラクターなので値を入れる  
                new WeatherEntity(
                  1,
                  Convert.ToDateTime("2019/09/10 23:00:56"),
                  2,
                  12.3f));
            // Moqのセットアップ
            weatherMock.Setup(x => x.GetLatest(2)).Returns(
                //完全コンストラクターなので値を入れる  
                new WeatherEntity(
                2,
                Convert.ToDateTime("2019/09/13 23:00:27"),
                1,
                22.12f));

            // Moqインスタンスの生成
            var areasMock = new Mock<IAreasRepository>();

            // Moq用のList作成
            var areas = new List<AreaEntity>();
            areas.Add(new AreaEntity(1, "東京"));
            areas.Add(new AreaEntity(2, "大阪"));
            areas.Add(new AreaEntity(3, "福岡"));

            // Moqのセットアップ
            areasMock.Setup(x => x.GetData()).Returns(areas);

            
            // ViewModelに対してテストを行う
            var viewModel = new WeathrLatestViewModel(weatherMock.Object,areasMock.Object);

            // 初期値のテスト
            Assert.IsNull(viewModel.SelectedAreaId);
            Assert.AreEqual("", viewModel.DataDateText);
            Assert.AreEqual("", viewModel.ConditionText);
            Assert.AreEqual("", viewModel.TemperatureText);
            // Areasの件数をテスト
            Assert.AreEqual(3, viewModel.Areas.Count);
            Assert.AreEqual(1, viewModel.Areas[0].AreaId);
            Assert.AreEqual("東京", viewModel.Areas[0].AreaName);
            Assert.AreEqual(2, viewModel.Areas[1].AreaId);
            Assert.AreEqual("大阪", viewModel.Areas[1].AreaName);

            viewModel.SelectedAreaId = 1;
            viewModel.Search();
            Assert.AreEqual(1, viewModel.SelectedAreaId);
            Assert.AreEqual("2019/09/10 23:00:56", viewModel.DataDateText);
            Assert.AreEqual("曇り", viewModel.ConditionText);
            Assert.AreEqual("12.30 ℃", viewModel.TemperatureText);

            viewModel.SelectedAreaId = 2;
            viewModel.Search();
            Assert.AreEqual(2, viewModel.SelectedAreaId);
            Assert.AreEqual("2019/09/13 23:00:27", viewModel.DataDateText);
            Assert.AreEqual("晴れ", viewModel.ConditionText);
            Assert.AreEqual("22.12 ℃", viewModel.TemperatureText);

            viewModel.SelectedAreaId = 3;
            viewModel.Search();
            Assert.AreEqual(3, viewModel.SelectedAreaId);
            Assert.AreEqual("", viewModel.DataDateText);
            Assert.AreEqual("", viewModel.ConditionText);
            Assert.AreEqual("", viewModel.TemperatureText);
        }


        /// <summary>
        /// シナリオテスト
        /// カスタムクラスを使用したTest方法
        /// </summary>
        //[TestMethod]
        //public void シナリオ２() {

        //    //ViewModelに対してテストを行う
        //   var viewModel = new WeathrLatestViewModel(
        //       new WeatherMock(),
        //       new AreaMock());

        //    //初期値のテスト
        //    Assert.AreEqual("", viewModel.SelectedAreaId);
        //    Assert.AreEqual("", viewModel.DataDateText);
        //    Assert.AreEqual("", viewModel.ConditionText);
        //    Assert.AreEqual("", viewModel.TemperatureText);

        //    //検索のテスト(1)
        //    viewModel.SelectedAreaId = "1";
        //    viewModel.Search();
        //    Assert.AreEqual("1", viewModel.SelectedAreaId);
        //    Assert.AreEqual("2019/09/10 23:00:56", viewModel.DataDateText);
        //    Assert.AreEqual("曇り", viewModel.ConditionText);
        //    Assert.AreEqual("12.30 ℃", viewModel.TemperatureText);

        //    //違う値のテストを行うためには、カスタムクラスを新に作る必要がある

        //}
    }


    /// <summary>
    /// テスト用クラス
    /// ただし値が固定になっている
    /// 違う値にするためには外から値を変更できるようにする必要がある
    /// 代替案としてMoqを使用する
    /// </summary>
    //internal class WeatherMock : IWeatherRepository {

    //    / <summary>
    //    / GetLatest用のモック
    //    / </summary>
    //    / <param name = "areaId" ></ param >
    //    / < returns ></ returns >
    //    public WeatherEntity GetLatest(int areaId) {

    //        決まった値を返却するだけ
    //        return new WeatherEntity(1,
    //                    Convert.ToDateTime("2019/09/10 23:00:56"),
    //                    2,
    //                    12.3f);
    //    }
    //}

    /// <summary>
    /// テスト用クラス
    /// ただし値が固定になっている
    /// 違う値にするためには外から値を変更できるようにする必要がある
    /// 代替案としてMoqを使用する
    /// </summary>
    //internal class AreaMock : IAreasRepository {

    //    /// <summary>
    //    /// GetLatest用のモック
    //    /// </summary>
    //    /// <param name="areaId"></param>
    //    /// <returns></returns>
    //    public WeatherEntity GetData(int areaId) {

    //        // 決まった値を返却するだけ
    //        return new WeatherEntity(1,
    //                    Convert.ToDateTime("2019/09/10 23:00:56"),
    //                    2,
    //                    12.3f);
    //    }
    //}

}
