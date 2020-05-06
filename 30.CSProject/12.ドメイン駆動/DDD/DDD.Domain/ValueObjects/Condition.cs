
using System.Collections.Generic;

namespace DDD.Domain.ValueObjects {

    /// <summary>
    /// コンディションクラス
    /// データベースから変換する処理
    /// １＝晴れとか
    /// データに関する事なのでDomain層に実装する
    /// 区分（ENum）は1か所にまとめる
    /// </summary>
    public sealed class Condition : ValueObject<Condition> {
        
        /// <summary>
        /// 列挙体と同じようになる
        /// 不明
        /// </summary>
        public static readonly Condition None = new Condition(0);

        /// <summary>
        /// 晴れ
        /// </summary>
        public static readonly Condition Sunny = new Condition(1);

        /// <summary>
        /// 曇り
        /// </summary>
        public static readonly Condition Cloudy = new Condition(2);

        /// <summary>
        /// 雨
        /// </summary>
        public static readonly Condition Rain = new Condition(3);

        /// <summary>
        /// 完全コンストラクタ
        /// </summary>
        /// <param name="value"></param>
        public Condition(int value) {
            Value = value;
        }

        /// <summary>
        /// 外部へ公開
        /// </summary>        
        public int Value { get; }

        /// <summary>
        /// ビジネスロジック
        /// コンストラクターの時の値(this)で判断する
        /// </summary>
        public string DisplayValue {
            get {
                if(this == Sunny) {
                    return "晴れ";
                }
                if (this == Cloudy) {
                    return "曇り";
                }
                if (this == Rain) {
                    return "雨";
                }
                return "不明";
            }
        }

        protected override bool EqualsCore(Condition other) {
            return this.Value == other.Value;
        }

        /// <summary>
        /// コンボボックスにしようするためプロパティーを作る
        /// </summary>
        /// <returns></returns>
        public static IList<Condition> ToList() {
            return new List<Condition> {
            None,
            Sunny,
            Cloudy,
            Rain,
            };
        }
    }
}
