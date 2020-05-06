using DDD.Domain.Entities;

namespace DDD.WinForm.ViewsModel {
    public sealed class WeatherListViewModelWeather {

        private WeatherEntity _entity;
        public WeatherListViewModelWeather(WeatherEntity entity) {
            _entity = entity;
        }

        public string AreaId => _entity.AreaId.DisplayValue;
        public string AreaName => _entity.AreaName.ToString();
        public string DateTime => _entity.DataDate.ToString();
        public string Contition => _entity.Condition.DisplayValue;
        public string Temperature => _entity.Temperature.DisplayValueWithUnitSpace;
    }

}
