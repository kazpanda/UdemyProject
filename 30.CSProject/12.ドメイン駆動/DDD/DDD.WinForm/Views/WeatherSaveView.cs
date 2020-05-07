using DDD.Domain.Repositories;
using DDD.Infrastructure.SQLite;
using System.Windows.Forms;

namespace DDD.WinForm.Views {

    /// <summary>
    /// 
    /// </summary>
    public partial class WeatherSaveView : Form {

        private IWeatherRepository _viewModel;
        private IAreasRepository _areas;

        /// <summary>
        /// 
        /// </summary>
        public WeatherSaveView() : this(new WeatherSQLite(), new AreasSQLite()) {

        }

        /// <summary>
        /// 
        /// </summary>
        public WeatherSaveView(
            IWeatherRepository viewModel,
           IAreasRepository areas
            ) {

            _viewModel = viewModel;
            _areas = areas;

            InitializeComponent();
        }


    }
}
