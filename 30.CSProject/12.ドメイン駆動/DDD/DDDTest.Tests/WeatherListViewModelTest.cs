using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using DDD.WinForm.ViewsModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace DDDTest.Tests {
    [TestClass]
    public class WeatherListViewModelTest {
        [TestMethod]
        public void 天気一覧画面シナリオ() {

            // Moqインスタンスの生成
            var weatherMock = new Mock<IWeatherRepository>();

            var entities = new List<WeatherEntity>();
            entities.Add(
                new WeatherEntity(
                  1,
                  "東京",
                  Convert.ToDateTime("2019/09/10 23:00:56"),
                  2,
                  12.3f));
            entities.Add(
                new WeatherEntity(
                  2,
                  "大阪",
                  Convert.ToDateTime("2019/09/10 23:00:56"),
                  1,
                  22.1234f));




            // Moqのセットアップ
            weatherMock.Setup(x => x.GetData()).Returns(entities);

            var viewModel = new WeatherListViewModel(weatherMock.Object);

            viewModel.Weathers.Count.Is(2);
            viewModel.Weathers[0].AreaId.Is("0001");
            viewModel.Weathers[0].AreaName.Is("東京");
            viewModel.Weathers[0].DateTime.Is("2019/09/10 23:00:56");
            viewModel.Weathers[0].Contition.Is("曇り");
            viewModel.Weathers[0].Temperature.Is("12.30 ℃");
        }
    }
}
