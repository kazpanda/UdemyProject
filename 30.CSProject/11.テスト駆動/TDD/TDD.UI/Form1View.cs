using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TDD.UI {
    public partial class Form1View : Form {

        // ViewModelで処理を書くため
        // 本番コードはDBを呼ぶ
        private Form1ViewModel _viewModel = new Form1ViewModel(new DB());

        public Form1View() {
            InitializeComponent();

            // データバインド
            ATextBox.DataBindings.Add("Text", _viewModel, "ATextBoxText");
            BTextBox.DataBindings.Add("Text", _viewModel, "BTextBoxText");
            ResultLabel.DataBindings.Add("Text", _viewModel, "ResultLabelText");
        }

        private void CalculationButton_Click(object sender, EventArgs e) {
            // ViewModelを使わない
            //int a = Convert.ToInt32(ATextBox.Text);
            //int b = Convert.ToInt32(BTextBox.Text);
            //ResultLabel.Text = Calculation.Sum(a, b).ToString();

            // データバインドを使わない
            // バグが混入しやすい
            //_viewModel.ATextBoxText = ATextBox.Text;
            //_viewModel.BTextBoxText = BTextBox.Text;
            
            _viewModel.CalculationAction();

            // this.ResultLabel.Text = _viewModel.ResultLabelText;
        }
    }
}
