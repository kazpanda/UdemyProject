using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using DDD.WinForm.ViewsModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace DDDTest.Tests {

    /// <summary>
    /// ViewModelのテスト
    /// 直接フォームのテストは行わない（privateなのでアクセスできない）
    /// </summary>
    [TestClass]
    public class WeathrLatestViewModelTest {

        /// <summary>
        /// シナリオテスト
        /// </summary>
        [TestMethod]
        public void シナリオ() {

            // モックを指定しnewする
            var weatherMock = new Mock<IWeatherRepository>();

            //Moqによるシナリオテスト
            weatherMock.Setup(x => x.GetLatest(1)).Returns(
                //完全コンストラクターなので値を入れる  
                new WeatherEntity(
                  1,
                  Convert.ToDateTime("2019/09/10 23:00:56"),
                  2,
                  12.3f));

            // Moqによるシナリオテスト
            weatherMock.Setup(x => x.GetLatest(2)).Returns(
                //完全コンストラクターなので値を入れる  
                new WeatherEntity(
                2,
                Convert.ToDateTime("2019/09/13 23:00:27"),
                1,
                22.12f));

            // ViewModelに対してテストを行う
            var viewModel = new WeathrLatestViewModel(weatherMock.Object);

            // 初期値のテスト
            Assert.AreEqual("", viewModel.AreaIdText);
            Assert.AreEqual("", viewModel.DataDateText);
            Assert.AreEqual("", viewModel.ConditionText);
            Assert.AreEqual("", viewModel.TemperatureText);

            // 検索のテスト(1)
            viewModel.AreaIdText = "1";
            viewModel.Search();
            Assert.AreEqual("1", viewModel.AreaIdText);
            Assert.AreEqual("2019/09/10 23:00:56", viewModel.DataDateText);
            Assert.AreEqual("曇り", viewModel.ConditionText);
            Assert.AreEqual("12.30 ℃", viewModel.TemperatureText);

            // 検索のテスト(2)
            viewModel.AreaIdText = "2";
            viewModel.Search();
            Assert.AreEqual("2", viewModel.AreaIdText);
            Assert.AreEqual("2019/09/13 23:00:27", viewModel.DataDateText);
            Assert.AreEqual("晴れ", viewModel.ConditionText);
            Assert.AreEqual("22.12 ℃", viewModel.TemperatureText);

        }
    }

    /// <summary>
    /// テスト用クラス
    /// 
    /// </summary>
    internal class WeatherMock : IWeatherRepository {
        public WeatherEntity GetLatest(int areaId) {

            return new WeatherEntity(1,
                        Convert.ToDateTime("2019/09/10 23:00:56"),
                        2,
                        12.3f);
        }
    }

}
