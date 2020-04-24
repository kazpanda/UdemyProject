using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1 {


    public class Class1 {
    
        /// <summary>
        /// メソッド
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int Add(int a, int b) {
            
            // この例外が出るかテストしたい
            // aがマイナスならExceptionをスロー
            if (a <0) {
                throw new InputException("マイナス値は入力できません");
            }

            return a + b;
        }
    }
}
