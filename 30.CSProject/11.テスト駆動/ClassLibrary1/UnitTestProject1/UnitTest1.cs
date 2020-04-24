using System;
using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1 {
    [TestClass]
    public class UnitTest1 {
        
        [TestMethod]
        public void TestMethod1() {
            // 通常の書き方
            Assert.AreEqual(3,Class1.Add(1, 2));

        }

        /// <summary>
        /// 例外が出るかテストを行う
        /// ただしメソッドと例外テストが別々のテストが必要
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InputException))]
        public void 例外のテスト() {
            Assert.AreEqual(3, Class1.Add(-1, 2));
        }

        /// <summary>
        /// ChainingAssertionだけで書く
        /// メソッドのテストと例外のテストが行える
        /// </summary>
        [TestMethod]
        public void TestMethod2() {
            Class1.Add(1, 2).Is(3);
            var ex = AssertEx.Throws<InputException>(() => Class1.Add(-1, 2));
            // 通常Assert.AreEqualから下記の様に書き換えができる（文脈がわかりやすい）
            ex.Message.Is("マイナス値は入力できません");
        }
      
    }
}
