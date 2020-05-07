using DDD.Domain.Entities;
using DDD.Domain.Exceptions;
using DDD.Domain.Helpers;
using DDD.Domain.Repositories;
using DDD.Domain.ValueObjects;
using System;
using System.ComponentModel;

namespace DDD.WinForm.ViewsModel {


    public class WeatherSaveViewModel:ViewModelBase {

        private IWeatherRepository _weathr;
        private IAreasRepository _areas;

        /// <summary>
        /// コンストラクター
        /// 起動した時点で現在値を取得する
        /// </summary>
        public WeatherSaveViewModel(
            IWeatherRepository weathr,
            IAreasRepository areas) {

            _weathr = weathr;
            _areas = areas;
           
            DataDateValue = GetDateTime();
            SelectedCondition = Condition.Sunny.Value;
            TemperatureText = string.Empty;
            // データを取得する
            foreach (var area in _areas.GetData()) {
                Areas.Add(new AreaEntity(area.AreaId, area.AreaName));
            }
        }

        public object SelectedAreaId { get; set; }
        // 直接Nowを取得せずコンストラクターに任せる
        public DateTime DataDateValue { get; set; }
        public object SelectedCondition { get; set; }
        public string TemperatureText { get; set; }
        // コンボボックスの公開プロパティー
        public BindingList<AreaEntity> Areas { get; set; }
            = new BindingList<AreaEntity>();
        public BindingList<Condition> Conditions { get; set; }
            = new BindingList<Condition>(Condition.ToList());


        /// <summary>
        /// ボタン処理
        /// </summary>
        public void Save() {

            // コンボボックス入力チェック
            Guard.IsNull(SelectedAreaId,"エリアを指定してください");
            
            // テキストボックス入力チェック
            float temperature = Guard.IsFloat(TemperatureText, "温度の入力に誤りがある");

            // 保存するEntityを作成する
            var entity = new WeatherEntity(
                Convert.ToInt32(SelectedAreaId),
                DataDateValue,
                Convert.ToInt32(SelectedCondition),
                temperature
                );

            // DBへ保存する
            _weathr.Save(entity);

        }

        /// 基底クラスに移動
        /// <summary>
        /// メソッドにすることで上書きできる
        /// </summary>
        /// <returns></returns>
        //public virtual DateTime GetDateTime() {
        //    return DateTime.Now;
        //}
    }
}
