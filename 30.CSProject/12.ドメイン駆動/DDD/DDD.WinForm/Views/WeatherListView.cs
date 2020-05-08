using DDD.WinForm.ViewsModel;
using System.Windows.Forms;

namespace DDD.WinForm.Views {

    /// <summary>
    /// WeatherListViewフォーム
    /// </summary>
    public partial class WeatherListView : Form {

        private WeatherListViewModel _viewModel = new WeatherListViewModel();

        /// <summary>
        /// コンストラクター
        /// </summary>
        public WeatherListView() {
            InitializeComponent();

            //データバインディング
            WeathersDataGrid.DataBindings.Add(
                "DataSource", _viewModel, nameof(_viewModel.Weathers));

        }
    }
}
