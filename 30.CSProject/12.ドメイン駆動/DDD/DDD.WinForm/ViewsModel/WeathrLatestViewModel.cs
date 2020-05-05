using DDD.Domain.Repositories;
using DDD.Infrastructure.SQLite;
using System;

namespace DDD.WinForm.ViewsModel {

    public class WeathrLatestViewModel : ViewModelBase {

        // インターフェイス変数（Newしない）
        private IWeatherRepository _weather;

        // 2つのコンストラクター

        /// <summary>
        /// コンストラクター(引数なし)
        /// 引数無しは本番時に呼ばれる
        /// thisをつけると引数ありのコンストラクターを引数なしで呼ぶ
        /// </summary>
        public WeathrLatestViewModel()
           : this(new WetherSQLite()) {
        }

        /// <summary>
        /// コンストラクター（引数あり）
        /// 呼び出し時に引数で指定し呼ばれる
        /// 評価と本番の切替ができる
        /// </summary>
        /// <param name="weather"></param>
        public WeathrLatestViewModel(IWeatherRepository weather) {
            // 引数ありも引数なしも、どちらからも呼ばれる
            _weather = weather;
        }

        /// <summary>
        /// プロパティー
        /// 基底クラスクラスを使っているので簡素化ができる
        /// </summary>
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


        /// <summary>
        /// メソッド（検索処理）
        /// テストコードから呼ばれたときはSQLに接続したくない
        /// テストコードと本番環境の切り分けができるようにインターフェイスを通じて呼ぶ
        /// </summary>
        public void Search() {

            // コンストラクターで指定した_weatherに対してメソッドを実行
            // 本番もしくはテスト（インターフェイス）に対して行う
            var entity = _weather.GetLatest(Convert.ToInt32(AreaIdText));

            // データ取得後の処理
            // メソッドはValueObjectにすることで、ViewModelにはメソッドはなくなる
            // ViewModelではValueObjectを表示するだけ
            if (entity != null) {
                DataDateText = entity.DataDate.ToString();
                ConditionText = entity.Condition.DisplayValue;
                TemperatureText = entity.Temperature.DisplayValueWithUnitSpace;
            }
        }

    }
}
