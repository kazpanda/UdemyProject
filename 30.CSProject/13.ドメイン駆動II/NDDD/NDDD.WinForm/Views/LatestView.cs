using NDDD.Infrastructure;
using NDDD.Infrastructure.Fake;
using NDDD.WinForm.ViewModels;
using System.Windows.Forms;

namespace NDDD.WinForm.Views {

    /// <summary>
    /// LatestView
    /// </summary>
    public partial class LatestView : Form {

        // ViewModelを参照する
        // インスタンス生成はFactoriesで生成する
        // 設定はSheardにて行う
        private LatestViewModel _viewModel = new LatestViewModel();
       
        /// <summary>
        /// コンストラクター
        /// </summary>
        public LatestView() {
            InitializeComponent();

            toolStripStatusLabel1.Visible = false;
#if DEBUG
            toolStripStatusLabel1.Visible = true;
#endif
            // データバインド
            AreaIdTextBox.DataBindings.Add(
                "Text",
                _viewModel,
                nameof(_viewModel.AreaIdText));

            // データバインド
            MeasureDateTextBox.DataBindings.Add(
                "Text",
                _viewModel,
                    nameof(_viewModel.MeasureDateText));

            // データバインド
            MeasureValueTextBox.DataBindings.Add(
                "Text",
                _viewModel,
                 nameof(_viewModel.MeasureValueText));
        }

        /// <summary>
        /// ボタンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click(object sender, System.EventArgs e) {
            _viewModel.Search();
        }
    }
}
