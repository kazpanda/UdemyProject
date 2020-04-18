using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP3 {

    /// <summary>
    /// コントロールの継承
    /// </summary>
    public sealed class TextBoxEx:TextBox {

        /// <summary>
        /// バリデーションチェック機能
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLeave(EventArgs e) {
           
            // バリデーション
            int value = 0;
            if (!int.TryParse(this.Text, out value)) {
                this.Text = "0";
            }

            // デフォルトで生成される
            base.OnLeave(e);
        }
    }
}
