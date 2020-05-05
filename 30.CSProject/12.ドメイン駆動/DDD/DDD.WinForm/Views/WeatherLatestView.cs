using DDD.WinForm.ViewsModel;
using System;
using System.Windows.Forms;

namespace DDD.WinForm {

    /// <summary>
    /// View（フォーム）クラス
    /// </summary>
    public partial class WeatherLatestView : Form
    {
        // ViewModelインスタンス
        private WeathrLatestViewModel _viewModel 
            = new WeathrLatestViewModel();

        /// <summary>
        /// コンストラクター
        /// データバインディングを行う
        /// </summary>
        public WeatherLatestView() {　　

            InitializeComponent();

            // データバインディング(ViewModelとのバインディング)
            // nameofが使えない場合は、文字列で指定可能("AreaIdText")
            this.AreaIdTextBox.DataBindings.Add(
                "Text",_viewModel,nameof(_viewModel.AreaIdText));

            this.DataDateLabel.DataBindings.Add(
                "Text", _viewModel, nameof(_viewModel.DataDateText));

            this.ConditionLabel.DataBindings.Add(
                "Text", _viewModel, nameof(_viewModel.ConditionText));

            this.TemperatureLabel.DataBindings.Add(
                "Text", _viewModel, nameof(_viewModel.TemperatureText));
        }


        /// <summary>
        /// ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LatestButton_Click(object sender, EventArgs e) {

            // 通常は引数に与えなければならないが、DataBindしているので引数はいらない
            _viewModel.Search();
        }

       
    }
}
