using DDD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.WinForm.ViewsModel {
    public class WeatherSaveViewModel:ViewModelBase {

        /// <summary>
        /// コンストラクター
        /// 起動した時点で現在値を取得する
        /// </summary>
        public WeatherSaveViewModel() {
            DataDateValue = GetDateTime();
            SelectedCondition = Condition.Sunny.Value;
            TemperatureText = string.Empty;
        }

        public object SelectedAreaId { get; set; }
        // 直接Nowを取得せずコンストラクターに任せる
        public DateTime DataDateValue { get; set; }
        public object SelectedCondition { get; set; }
        public string TemperatureText { get; set; }

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
