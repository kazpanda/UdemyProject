using DDD.Domain.Helpers;

namespace DDD.Domain.ValueObjects {

    /// <summary>
    /// TemperatureValueObject
    /// sealedにて継承させない
    /// DBからとってくるときはFloat型
    /// </summary>
    public sealed class Temperature : ValueObject<Temperature> {

        // 温度に関する単位なのValueObjectに入れる（共通ConstからValueObject）
        public const string UnitName = "℃";
        public const int DecimalPoint = 2;

        // 完全コンストラクタ
        public Temperature(float value) {
            Value = value;
        }
        // 変更できるのはコンストラクタのみ
        public float Value { get; }


        /// <summary>
        /// フォーム表示メソッド
        /// </summary>
        public string DisplayValue {
            get {
                // 何でValue.RoundStringが出来るの?拡張メソッド?
                return Value.RoundString(DecimalPoint);
                // return FloatHelper.RoundString(Value, DecimalPoint);
            }
        }

        /// <summary>
        /// フォーム表示単位付きメソッド
        /// </summary>
        public string DisplayValueWithUnit {
            get {
                return Value.RoundString(DecimalPoint) + UnitName;
                //return FloatHelper.RoundString(Value, DecimalPoint) + UnitName;
            }
        }

        /// <summary>
        /// メソッド
        /// </summary>
        public string DisplayValueWithUnitSpace {
            get {
                return Value.RoundString(DecimalPoint) + " " + UnitName;
                //return FloatHelper.RoundString(Value, DecimalPoint) + " " + UnitName;
            }
        }

        /// <summary>
        /// メソッド
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        protected override bool EqualsCore(Temperature other) {
            return Value == other.Value;
        }
    }
}
