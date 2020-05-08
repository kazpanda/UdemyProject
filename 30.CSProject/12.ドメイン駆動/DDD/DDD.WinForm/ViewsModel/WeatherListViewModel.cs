using DDD.Domain.Repositories;
using DDD.Infrastructure.SQLite;
using System.ComponentModel;

namespace DDD.WinForm.ViewsModel {

    /// <summary>
    /// WeatherListViewModelモデルクラス
    /// </summary>
    public class WeatherListViewModel : ViewModelBase {

        private IWeatherRepository _weather;

        /// <summary>
        /// コンストラクター（引数なし）
        /// SQLiteに接続
        /// </summary>
        public WeatherListViewModel() 
            :this(new WeatherSQLite()){
        }


        /// <summary>
        /// コンストラクター（引数あり）
        /// インターフェイスに接続
        /// </summary>
        /// <param name="weather"></param>
        public WeatherListViewModel(IWeatherRepository weather) {
            _weather = weather;

            foreach (var entity in _weather.GetData()) {
                Weathers.Add(new WeatherListViewModelWeather(entity));
            }
        }

        /// <summary>
        /// リスト取得のために公開する
        /// </summary>
        public BindingList<WeatherListViewModelWeather>
            Weathers { get; set; } = new BindingList<WeatherListViewModelWeather>();
    }
}
