namespace DDD.Domain.ValueObjects {

    /// <summary>
    /// AreaId
    /// </summary>
    public sealed class AreaId : ValueObject<AreaId> {
        
        /// <summary>
        /// 完全コンストラクター
        /// </summary>
        /// <param name="value"></param>
        public AreaId(int value) {
            Value = value;
        }

        public int Value { get; }

        /// <summary>
        /// 値の比較
        /// ValueObjectにて継承している実装
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        protected override bool EqualsCore(AreaId other) {
            return Value == other.Value;
        }

        /// <summary>
        /// 表示用実装
        /// </summary>
        public string DisplayValue {
            get {
                return Value.ToString().PadLeft(4, '0');
            }
        }
    }
}
