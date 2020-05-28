using System;
using DDD.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DDDTest.Tests {

    /// <summary>
    /// TemperatureTest
    /// </summary>
    [TestClass]
    public class TemperatureTest {

        /// <summary>
        /// テスト名は日本語でOK（呼ばれることがない）
        /// </summary>
        [TestMethod]
        public void 小数点以下2桁で丸めて表示する() {

            // 完全コンストラクターからnewする
            var t = new Temperature(12.3f);
            Assert.AreEqual(12.3f, t.Value);
            Assert.AreEqual("12.30", t.DisplayValue);
            Assert.AreEqual("12.30℃", t.DisplayValueWithUnit);
            Assert.AreEqual("12.30 ℃", t.DisplayValueWithUnitSpace);

            var t1 = new Temperature(12.3f);
            var t2 = new Temperature(12.3f);

            Assert.AreEqual(true, t1.Equals(t2));
        }

        /// <summary>
        /// 参照型のテスト
        /// クラスは参照型
        /// </summary>
        [TestMethod]
        public void 温度Equals() {
            
            var t1 = new Temperature(12.3f);
            var t2 = new Temperature(12.3f);

            Assert.AreEqual(true, t1.Equals(t2));
        }

        /// <summary>
        /// ＝＝と書いた時のテスト
        /// </summary>
        [TestMethod]
        public void 温度EqualsEquals() {

            var t1 = new Temperature(12.3f);
            var t2 = new Temperature(12.3f);

            Assert.AreEqual(true, t1==t2);
        }

        /// <summary>
        /// 値型のテスト
        /// 代入する
        /// </summary>
        [TestMethod]
        public void 値型Equals() {

            float t1 = 12.3f;
            float t2 = 12.3f;

            Assert.AreEqual(true, t1.Equals(t2));
            Assert.AreEqual(true, t1 == t2);
        }
    }
}
