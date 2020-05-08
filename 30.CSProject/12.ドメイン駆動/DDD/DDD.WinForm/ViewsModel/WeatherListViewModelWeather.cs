using DDD.Domain.Entities;

namespace DDD.WinForm.ViewsModel {

    /// <summary>
    /// WeatherListViewModelWeatherモデルクラス
    /// </summary>
    public sealed class WeatherListViewModelWeather {

        private WeatherEntity _entity;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="entity"></param>
        public WeatherListViewModelWeather(WeatherEntity entity) {
            _entity = entity;
        }

        // WeatherEntityを公開
        // View側は表示だけなので、シンプルに公開するだけでOK
        // 入力やボタンがあると、バインディングやメソッドが必要
        public string AreaId => _entity.AreaId.DisplayValue;
        public string AreaName => _entity.AreaName.ToString();
        public string DateTime => _entity.DataDate.ToString();
        public string Contition => _entity.Condition.DisplayValue;
        public string Temperature => _entity.Temperature.DisplayValueWithUnitSpace;
    }

}
