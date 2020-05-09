using System.Collections.Generic;

namespace AnalyzeSample {

    /// <summary>
    /// 分析ロジック
    /// </summary>
    public static class Analyze {

        /// <summary>
        /// 合計を出力
        /// </summary>
        /// <param name="pAValue"></param>
        /// <param name="eBValue"></param>
        /// <returns></returns>
        public static int Sum(int pAValue, int eBValue) {
            return pAValue + eBValue;

        }

        /// <summary>
        /// 平均を出力
        /// </summary>
        /// <param name="pList"></param>
        /// <returns></returns>
        public static int Ave(List<int> pList) {

            int eValues = 0;
            foreach(var val in pList) {
                eValues += val;
            }
            return eValues / pList.Count;
        }
    }
}
