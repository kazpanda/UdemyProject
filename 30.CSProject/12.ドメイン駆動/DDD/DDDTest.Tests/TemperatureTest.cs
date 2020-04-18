﻿using System;
using DDD.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DDDTest.Tests {
    [TestClass]
    public class TemperatureTest {
        [TestMethod]
        public void 小数点以下2桁で丸めて表示する() {
            var t = new Temperature(12.3f);
            Assert.AreEqual(12.3f, t.Value);
            Assert.AreEqual("12.30", t.DisplayValue);
            Assert.AreEqual("12.30℃", t.DisplayValueWithUnit);
            Assert.AreEqual("12.30 ℃", t.DisplayValueWithUnitSpace);

            var t1 = new Temperature(12.3f);
            var t2 = new Temperature(12.3f);

            Assert.AreEqual(true, t1.Equals(t2));
        }

        [TestMethod]
        public void 温度Equals() {
            
            var t1 = new Temperature(12.3f);
            var t2 = new Temperature(12.3f);

            Assert.AreEqual(true, t1.Equals(t2));
        }

        [TestMethod]
        public void 温度EqualsEquals() {

            var t1 = new Temperature(12.3f);
            var t2 = new Temperature(12.3f);

            Assert.AreEqual(true, t1==t2);
        }

        [TestMethod]
        public void 値型Equals() {

            float t1 = 12.3f;
            float t2 = 12.3f;

            Assert.AreEqual(true, t1.Equals(t2));
            Assert.AreEqual(true,t1 == t2);
        }
    }
}
