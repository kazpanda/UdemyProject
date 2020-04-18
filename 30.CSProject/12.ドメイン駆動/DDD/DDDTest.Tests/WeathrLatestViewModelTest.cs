using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using DDD.WinForm.ViewsModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace DDDTest.Tests {
    [TestClass]
    public class WeathrLatestViewModelTest {

        [TestMethod]
        public void シナリオ() {

            var weatherMock = new Mock<IWeatherRepository>();

            // Moqによるシナリオテスト
            weatherMock.Setup(x => x.GetLatest(1)).Returns(
                new WeatherEntity(
                1,
                Convert.ToDateTime("2019/09/10 23:00:56"),
                2,
                12.3f));

            // Moqによるシナリオテスト
            weatherMock.Setup(x => x.GetLatest(2)).Returns(
                new WeatherEntity(
                2,
                Convert.ToDateTime("2019/09/13 23:00:27"),
                1,
                22.12f));

            var viewModel = new WeathrLatestViewModel(weatherMock.Object);

            Assert.AreEqual("", viewModel.AreaIdText);
            Assert.AreEqual("", viewModel.DataDateText);
            Assert.AreEqual("", viewModel.ConditionText);
            Assert.AreEqual("", viewModel.TemperatureText);

            viewModel.AreaIdText = "1";
            viewModel.Search();
            Assert.AreEqual("1", viewModel.AreaIdText);
            Assert.AreEqual("2019/09/10 23:00:56", viewModel.DataDateText);
            Assert.AreEqual("曇り", viewModel.ConditionText);
            Assert.AreEqual("12.30 ℃", viewModel.TemperatureText);

            viewModel.AreaIdText = "2";
            viewModel.Search();
            Assert.AreEqual("2", viewModel.AreaIdText);
            Assert.AreEqual("2019/09/13 23:00:27", viewModel.DataDateText);
            Assert.AreEqual("晴れ", viewModel.ConditionText);
            Assert.AreEqual("22.12 ℃", viewModel.TemperatureText);

        }

    }

    //internal class WeatherMock : IWeatherRepository {
    //    public WeatherEntity GetLatest(int areaId) {

    //        return new WeatherEntity(1,
    //                    Convert.ToDateTime("2019/09/10 23:00:56"),
    //                    2,
    //                    12.3f);
    //    }
    //}

}
