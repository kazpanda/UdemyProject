using System;
using ClassLibrary2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1 {
    
    /// <summary>
    /// サンプルテスト
    /// AxoCoverを使用することでカバレッジを自動取得できる
    /// </summary>
    [TestClass]
    public class UnitTest1 {

        [TestMethod]
        public void メソッドをテストする() {
            // メソッド1
            Assert.AreEqual(3, Class1.Add1(1, 2));
            
            // メソッド2
            Assert.AreEqual(5, Class1.Add2(1, 2,3));
            Assert.AreEqual(7, Class1.Add2(2, 2, 3));

        }
    }
}
