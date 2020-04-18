using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP3 {

    /// <summary>
    /// 画面の継承サンプル
    /// 基底となる画面の作成
    /// 処理の共通化が可能
    /// </summary>

    public partial class BaseForm : Form {
        public BaseForm() {
            InitializeComponent();

            // 初期値
            this.toolStripProgressBar1.Minimum = 0;
            this.toolStripProgressBar1.Maximum = 100;
            this.toolStripProgressBar1.Value = 0;
            this.toolStripStatusLabel1.Text = "";

            this.StartPosition = FormStartPosition.CenterScreen;

        }

        // procterを使用することで、内部からは設定ができる
        protected void SetStatusLabel(string message) {
            this.toolStripStatusLabel1.Text = message;

        }

        protected void SetPogress(int value) {
            this.toolStripProgressBar1.Value = value;
        }
    }
}
