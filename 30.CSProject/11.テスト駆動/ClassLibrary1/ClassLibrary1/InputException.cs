using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1 {
    
    /// <summary>
    /// 例外クラス
    /// </summary>
    public sealed class InputException:Exception {
        
        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="message"></param>
        public InputException(string message) : base(message) {

        }
    }
}
