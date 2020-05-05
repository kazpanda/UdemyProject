using System;
using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1 {
    [TestClass]
    public class UnitTest1 {

        [TestMethod]
        public void TestMethod1() {

            // 普通の書き方
            Assert.AreEqual(3,Class1.Add(1, 2));

            // ChainingAssertionを使用した例外のテスト
            AssertEx.Throws<InputException>(()=>Class1.Add(-1,2));
            // 戻り値も取れる
            var ex = AssertEx.Throws<InputException>(() => Class1.Add(-1, 2));
            Assert.AreEqual("マイナス値は入力できません", ex.Message);
            // 構文も分かりやすく書ける
            Class1.Add(1, 2).Is(3);
            ex.Message.Is("マイナス値は入力できません");
        }

        /// <summary>
        /// 例外のテスト
        /// ただし別のテストメソッドになってしまう
        /// 代替案としてChainingAssertionを使用する
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InputException))]
        public void 例外のテスト() {
            Assert.AreEqual(3, Class1.Add(-1, 2));
        }
    }
}
