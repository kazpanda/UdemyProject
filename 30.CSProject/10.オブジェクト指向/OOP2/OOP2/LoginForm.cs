using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OOP2.MemberFactory;

namespace OOP2 {
    public partial class LoginForm : Form {
        public LoginForm() {
            InitializeComponent();
        }

        MemberKind memberKind = MemberKind.Silver;
        private void ExecutionButton_Click(object sender, EventArgs e) {
            // シルバー ０％
            // ゴールド ２０％
            // プラチナ ４０％


            if (GoldRadioButton.Checked) {
                memberKind = MemberKind.Gold;
            }

            else if (PlatiumRadioButton.Checked){
                memberKind = MemberKind.Platium;
            }

            LoginInfo.Member = MemberFactory.Create(memberKind);

            using (var f = new Form1()) {
                f.ShowDialog();
            }
        }

       }
}
