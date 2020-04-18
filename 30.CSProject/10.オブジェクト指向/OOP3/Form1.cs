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
    public partial class Form1 : BaseForm {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            Class2 c2 = new Class2();
            MessageBox.Show(c2.GetAAA().ToString());
        }


        /// <summary>
        /// バリデーションを実装で行った場合、毎回記載する必要がある
        /// この機能を継承クラスで作成すると共通化できる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_Leave(object sender, EventArgs e) {
            int value = 0;
            if(!int.TryParse(textBox1.Text, out value)) {
                textBox1.Text = "0";
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            using(var f = new Form2()) {
                f.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            base.SetStatusLabel("処理中");
            base.SetPogress(50);
        }

        private void button4_Click(object sender, EventArgs e) {
            base.SetStatusLabel("完了");
            base.SetPogress(100);
        }
    }
}
