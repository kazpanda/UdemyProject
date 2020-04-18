using DDD.Domain.Repositories;
using DDD.Infrastructure.SQLite;
using System;

namespace DDD.WinForm.ViewsModel {

    public class WeathrLatestViewModel : ViewModelBase {

        private IWeatherRepository _weather;

        // 2つのコンストラクター

        /// <summary>
        /// 本番時に呼ばれる
        /// </summary>
        public WeathrLatestViewModel()
           : this(new WetherSQLite()) {
        }

        /// <summary>
        /// 評価時にモックを指定して呼ばれる
        /// </summary>
        /// <param name="weather"></param>
        public WeathrLatestViewModel(IWeatherRepository weather) {
            _weather = weather;
        }

        private string _areaIdText = string.Empty;
        public string AreaIdText {
            get { return _areaIdText; }
            set { SetProperty(ref _areaIdText, value); }
        }

        private string _dataDateText = string.Empty;
        public string DataDateText {
            get { return _dataDateText; }
            set { SetProperty(ref _dataDateText, value); }
        }

        private string _conditionText = string.Empty;
        public string ConditionText {
            get { return _conditionText; }
            set { SetProperty(ref _conditionText, value); }
        }

        private string _temperatureText = string.Empty;
        public string TemperatureText {
            get { return _temperatureText; }
            set { SetProperty(ref _temperatureText, value); }
        }


        public void Search() {

            var entity = _weather.GetLatest(Convert.ToInt32(AreaIdText));

            if (entity != null) {

                DataDateText = entity.DataDate.ToString();

                //ConditionText = entity.Condition.ToString();
                ConditionText = entity.Condition.DisplayValue;

                //TemperatureText =
                //    CommonFunc.RoundString(entity.Temperature,
                //    Temperature.DecimalPoint) +" " 
                //    + Temperature.UnitName;
                TemperatureText = entity.Temperature.DisplayValueWithUnitSpace;
            }
        }

    }
}
