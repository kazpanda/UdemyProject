using NDDD.Infrastructure.Fake;
using NDDD.WinForm.ViewModels;
using System.Windows.Forms;

namespace NDDD.WinForm.Views {

    /// <summary>
    /// LatestView
    /// </summary>
    public partial class LatestView : Form {

        // ViewModelを参照する
        private LatestViewModel _viewModel = new LatestViewModel(new MeasureFake());
       
        /// <summary>
        /// コンストラクター
        /// </summary>
        public LatestView() {
            InitializeComponent();

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
