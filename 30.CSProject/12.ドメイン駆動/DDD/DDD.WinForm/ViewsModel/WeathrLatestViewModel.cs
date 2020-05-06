using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using DDD.Infrastructure.SQLite;
using System;
using System.ComponentModel;

namespace DDD.WinForm.ViewsModel {

    public class WeathrLatestViewModel : ViewModelBase {

        // インターフェイス変数（Newしない）
        private IWeatherRepository _weather;
        private IAreasRepository _areas;

        // 2つのコンストラクター

        /// <summary>
        /// コンストラクター(引数なし)
        /// 引数無しは本番時に呼ばれる
        /// thisをつけると引数ありのコンストラクターを引数なしで呼ぶ
        /// </summary>
        public WeathrLatestViewModel()
           : this(new WetherSQLite(), new AreasSQLite()) {
        }

        /// <summary>
        /// コンストラクター（引数あり）
        /// 呼び出し時に引数で指定し呼ばれる
        /// 評価と本番の切替ができる
        /// </summary>
        /// <param name="weather"></param>
        public WeathrLatestViewModel(IWeatherRepository weather, IAreasRepository areas) {
            // 引数ありも引数なしも、どちらからも呼ばれる
            _weather = weather;
            _areas = areas;

            foreach (var area in _areas.GetData()) {
                Areas.Add(new AreaEntity(area.AreaId, area.AreaName));
            }
        }

        /// <summary>
        /// プロパティー
        /// 基底クラスクラスを使っているので簡素化ができる
        /// </summary>
        private object _selectedAreaId;
        public object SelectedAreaId {
            get { return _selectedAreaId; }
            set { SetProperty(ref _selectedAreaId, value); }
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
        /// AreaEntityはDBから取得したEntity
        /// WinFormは、BindingList
        /// WPFの場合は、ObserverPullCollection
        /// </summary>
        public BindingList<AreaEntity> Areas { get; set; }
        = new BindingList<AreaEntity>();


        /// <summary>
        /// メソッド（検索処理）
        /// テストコードから呼ばれたときはSQLに接続したくない
        /// テストコードと本番環境の切り分けができるようにインターフェイスを通じて呼ぶ
        /// </summary>
        public void Search() {

            // コンストラクターで指定した_weatherに対してメソッドを実行
            // 本番もしくはテスト（インターフェイス）に対して行う
            var entity = _weather.GetLatest(Convert.ToInt32(_selectedAreaId));

            // データ取得後の処理
            // メソッドはValueObjectにすることで、ViewModelにはメソッドはなくなる
            // ViewModelではValueObjectを表示するだけ
            if (entity == null) {
                DataDateText = string.Empty;
                ConditionText = string.Empty;
                TemperatureText = string.Empty;
            } else {
                DataDateText = entity.DataDate.ToString();
                ConditionText = entity.Condition.DisplayValue;
                TemperatureText = entity.Temperature.DisplayValueWithUnitSpace;
            }

        }

    }
}
