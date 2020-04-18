using DDD.WinForm.ViewsModel;
using System;
using System.Windows.Forms;

namespace DDD.WinForm {

    public partial class WeatherLatestView : Form
    {
        private WeathrLatestViewModel _viewModel 
            = new WeathrLatestViewModel();

        public WeatherLatestView() {　　

            InitializeComponent();

            // データバインディング
            this.AreaIdTextBox.DataBindings.Add(
                "Text",_viewModel,nameof(_viewModel.AreaIdText));

            this.DataDateLabel.DataBindings.Add(
                "Text", _viewModel, nameof(_viewModel.DataDateText));

            this.ConditionLabel.DataBindings.Add(
                "Text", _viewModel, nameof(_viewModel.ConditionText));

            this.TemperatureLabel.DataBindings.Add(
                "Text", _viewModel, nameof(_viewModel.TemperatureText));
        }

        private void LatestButton_Click(object sender, EventArgs e) {

            // 通常は引数に与えなければならないが、DataBindしているので引数はいらない
            _viewModel.Search();
        }

       
    }
}
