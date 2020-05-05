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
        /// Moqを使用したTest方法
        /// </summary>
        [TestMethod]
        public void シナリオ１() {

            // Moqを指定しnewする
            var weatherMock = new Mock<IWeatherRepository>();

            // ViewModelに対してテストを行う
            var viewModel = new WeathrLatestViewModel(weatherMock.Object);

            // 初期値のテスト
            Assert.AreEqual("", viewModel.AreaIdText);
            Assert.AreEqual("", viewModel.DataDateText);
            Assert.AreEqual("", viewModel.ConditionText);
            Assert.AreEqual("", viewModel.TemperatureText);

            // Moqによるシナリオテスト
            // 簡単にシナリオが作れる
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
        }


        /// <summary>
        /// シナリオテスト
        /// カスタムクラスを使用したTest方法
        /// </summary>
        [TestMethod]
        public void シナリオ２() {

            // ViewModelに対してテストを行う
            var viewModel = new WeathrLatestViewModel(new WeatherMock());

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
            
            // 違う値のテストを行うためには、カスタムクラスを新に作る必要がある

        }
    }


    /// <summary>
    /// テスト用クラス
    /// ただし値が固定になっている
    /// 違う値にするためには外から値を変更できるようにする必要がある
    /// 代替案としてMoqを使用する
    /// </summary>
    internal class WeatherMock : IWeatherRepository {

        /// <summary>
        /// GetLatest用のモック
        /// </summary>
        /// <param name="areaId"></param>
        /// <returns></returns>
        public WeatherEntity GetLatest(int areaId) {

            // 決まった値を返却するだけ
            return new WeatherEntity(1,
                        Convert.ToDateTime("2019/09/10 23:00:56"),
                        2,
                        12.3f);
        }
    }

}
