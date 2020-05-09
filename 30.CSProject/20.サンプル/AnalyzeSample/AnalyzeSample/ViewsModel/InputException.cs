using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzeSample.ViewsModel {

    /// <summary>
    /// カスタム例外
    /// </summary>
   public sealed class InputException:Exception {

        /// <summary>
        /// 入力エラー
        /// </summary>
        /// <param name="pMessage"></param>
        public InputException(string pMessage) : base(pMessage) {

        }

    }
}
