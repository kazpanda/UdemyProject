using DDD.Domain.Helpers;

namespace DDD.Domain.ValueObjects {

    public sealed class Temperature : ValueObject<Temperature> {

        public const string UnitName = "℃";
        public const int DecimalPoint = 2;

        // 完全コンストラクタ
        public Temperature(float value) {
            Value = value;
        }
        // 変更できるのはコンストラクタのみ
        public float Value { get; }

        public string DisplayValue {
            get {
                // 何でValue.RoundStringが出来るの?拡張メソッド?
                return Value.RoundString(DecimalPoint);
                // return FloatHelper.RoundString(Value, DecimalPoint);
            }
        }

        public string DisplayValueWithUnit {
            get {
                return Value.RoundString(DecimalPoint) + UnitName;
                //return FloatHelper.RoundString(Value, DecimalPoint) + UnitName;
            }
        }

        public string DisplayValueWithUnitSpace {
            get {
                return Value.RoundString(DecimalPoint) + " " + UnitName;
                //return FloatHelper.RoundString(Value, DecimalPoint) + " " + UnitName;
            }
        }

        protected override bool EqualsCore(Temperature other) {
            return Value == other.Value;
        }
    }
}
