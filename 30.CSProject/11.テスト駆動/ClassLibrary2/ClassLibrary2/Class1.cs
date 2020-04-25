using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    /// <summary>
    /// サンプルクラス
    /// </summary>
    public class Class1
    {
        /// <summary>
        /// メソッド１
        /// 処理が一つの場合
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int Add1(int a,int b) {
            // 処理1
            return a + b;
        }

        /// <summary>
        /// メソッド２
        /// 処理が複数の場合
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int Add2(int a , int b,int c) {

            // 処理1
            if(a == 1) {
                return b + c;
            }
            // 処理2
            return a + b + c;
        }
    }
}
