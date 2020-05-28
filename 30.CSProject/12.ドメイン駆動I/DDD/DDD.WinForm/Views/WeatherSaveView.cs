using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using DDD.Domain.ValueObjects;
using DDD.Infrastructure.SQLite;
using DDD.WinForm.ViewsModel;
using System;
using System.Windows.Forms;

namespace DDD.WinForm.Views {

    /// <summary>
    /// WeatherSaveViewフォームクラス
    /// </summary>
    public partial class WeatherSaveView : Form {

        private WeatherSaveViewModel _viewModel = new WeatherSaveViewModel();

        /// <summary>
        /// コンストラクター
        /// バインディングを行う
        /// </summary>
        public WeatherSaveView() {

            InitializeComponent();

            // Form側のコントロール
            //private System.Windows.Forms.Button SaveButton;
            //private System.Windows.Forms.ComboBox AreaIdComboBox;
            //private System.Windows.Forms.DateTimePicker DateTimeTextBox;
            //private System.Windows.Forms.ComboBox ConditionComboBox;
            //private System.Windows.Forms.ComboBox TemperatureTextBox;
            //private System.Windows.Forms.Label UnitLabel;


            // データバインディング(ViewModelとのバインディング)
            // nameofが使えない場合は、文字列で指定可能("AreaIdText")
            // DoropBox AreaIdComboBox
            this.AreaIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.AreaIdComboBox.DataBindings.Add(
                "SelectedValue", _viewModel, nameof(_viewModel.SelectedAreaId));
            this.AreaIdComboBox.DataBindings.Add(
                "DataSource", _viewModel, nameof(_viewModel.Areas));
            this.AreaIdComboBox.ValueMember = nameof(AreaEntity.AreaId);
            this.AreaIdComboBox.DisplayMember = nameof(AreaEntity.AreaName);

            // DateTimePicker
            DateTimeTextBox.DataBindings.Add("Value", _viewModel, nameof(_viewModel.DataDateValue));

            // DoropBox ConditionComboBox
            this.ConditionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ConditionComboBox.DataBindings.Add(
                "SelectedValue", _viewModel, nameof(_viewModel.SelectedCondition));
            this.ConditionComboBox.DataBindings.Add(
                "DataSource", _viewModel, nameof(_viewModel.Conditions));
            this.ConditionComboBox.ValueMember = nameof(Condition.Value);
            this.ConditionComboBox.DisplayMember = nameof(Condition.DisplayValue);

            // TextBox TemperatureTextBox
            TemperatureTextBox.DataBindings.Add(
                "Text", _viewModel, nameof(_viewModel.TemperatureText));

            // Lavel UnitLabel
            UnitLabel.DataBindings.Add(
                "Text", _viewModel, nameof(_viewModel.TemperatureUnitName));

            // Button SaveButton
            SaveButton.Click += (_, __) => {
                try {
                    _viewModel.Save();
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            };

        }


    }
}
