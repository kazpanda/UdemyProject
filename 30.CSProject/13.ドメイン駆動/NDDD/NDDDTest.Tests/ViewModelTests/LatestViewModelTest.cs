﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NDDD.Domain.Entities;
using NDDD.Domain.Repositories;
using NDDD.WinForm.ViewModels;

namespace NDDDTest.Tests.ViewModelTests {
    [TestClass]
    public class LatestViewModelTest {

        [TestMethod]
        public void シナリオ() {

            // モックのデータを作成
            var entity = new MeasureEntity(
                1,
                Convert.ToDateTime("2020/05/26 22:00:00"),
                12.341f);

            // Moqセット
            var measureMock = new Mock<IMeasureRepository>();
            measureMock.Setup(x => x.GetLatest()).Returns(entity);
            
            var vm = new LatestViewModel(measureMock.Object);
            // エリアID
            // 計測日時
            // 計測値
            vm.Search();
            vm.AreaIdText.Is("0001");
            vm.MeasureDateText.Is("2020/05/26 22:00:00");
            vm.MeasureValueText.Is("12.34℃");


        }
    }
}
