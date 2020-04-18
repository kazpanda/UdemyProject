
namespace DDD.Domain.ValueObjects {

    public sealed class Condition : ValueObject<Condition> {
        
        /// <summary>
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
        public int Value { get; }

        // ビジネスロジック
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
    }
}
