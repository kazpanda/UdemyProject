using System;
using System.Windows.Forms;

namespace AnalyzeSample {


    public partial class AnalyzeView : Form {

        // ViewModelで処理を書くため
        // 本番コードはDBを呼ぶ
        private AnalyzeViewModel eViewModel = new AnalyzeViewModel(new DataBase());

        public AnalyzeView() {
            InitializeComponent();

            // データバインド
            ATextBox.DataBindings.Add("Text", eViewModel, "ATextBoxText");
            BTextBox.DataBindings.Add("Text", eViewModel, "BTextBoxText");
            ResultLabel.DataBindings.Add("Text", eViewModel, "ResultLabelText");
        }

        private void AnalyzeButton_Click(object sender, EventArgs e) {
            // ViewModelを使わない
            //int a = Convert.ToInt32(ATextBox.Text);
            //int b = Convert.ToInt32(BTextBox.Text);
            //ResultLabel.Text = Calculation.Sum(a, b).ToString();

            // データバインドを使わない
            // バグが混入しやすい
            //_viewModel.ATextBoxText = ATextBox.Text;
            //_viewModel.BTextBoxText = BTextBox.Text;

            eViewModel.Analyze();

            // this.ResultLabel.Text = _viewModel.ResultLabelText;
        }

       
    }
}
