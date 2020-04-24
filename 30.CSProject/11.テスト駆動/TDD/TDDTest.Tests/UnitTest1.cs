using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDDTest.Tests {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestMethod1() {
            var val = TDD.UI.Calculation.Sum(2, 5);
            Assert.AreEqual(7, val);

        }
        
        [TestMethod] // これを書かないとテストしてくれない
        public void 平均値を取得できる_OK() {
            var list = new List<int> { 1, 2, 3, 4, 5 };
            var result=TDD.UI.Calculation.Ave(list);
            Assert.AreEqual(3, result);
        }

    }
}
  