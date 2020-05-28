using System;

namespace DDD.Domain.Helpers {

    /// <summary>
    /// フロートチェック用クラス
    /// </summary>
    public static class FloatHelper {

        /// <summary>
        /// 小数点以下を指定桁数四捨五入します
        /// staticにしてどこからでも呼べるように
        /// 拡張メソッドにする
        /// thisを付けることでValueの拡張にRoundStringになる
        /// 書き方が日本語の意味に近くなる？インテリセンスが効く
        /// 無くても良い。可読性がいまいち
        /// </summary>
        /// <param name="value"></param>
        /// <param name="decimalPoint"></param>
        /// <returns></returns>
        public static string RoundString(this float value, int decimalPoint) {
            // thisを付けることで拡張メソッド
            var temp = Convert.ToSingle(Math.Round(value, decimalPoint));
            return temp.ToString("F" + decimalPoint);
        }
    }
}
