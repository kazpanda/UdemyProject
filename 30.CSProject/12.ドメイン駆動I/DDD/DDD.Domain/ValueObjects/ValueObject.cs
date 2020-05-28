namespace DDD.Domain.ValueObjects {

    /// <summary>
    /// ValueObject基底クラス
    /// ValueObject型Tだけを指定できる基底クラス（where T : ValueObject<T>）
    /// </summary>
    public abstract class ValueObject<T> where T : ValueObject<T> {
  
        /// <summary>
        /// "Equal"を制御
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj) {
            var vo = obj as T;
            if (vo == null) {
                return false;
            }
            return EqualsCore(vo);
        }

        /// <summary>
        /// "=="を制御
        /// </summary>
        /// <param name="vo1"></param>
        /// <param name="vo2"></param>
        /// <returns></returns>
        public static bool operator == (ValueObject<T> vo1,
            ValueObject<T> vo2) {
            return Equals(vo1, vo2);
        }

        /// <summary>
        /// "!="を制御
        /// </summary>
        /// <param name="vo1"></param>
        /// <param name="vo2"></param>
        /// <returns></returns>
        public static bool operator !=(ValueObject<T> vo1,
            ValueObject<T> vo2) {
            return !Equals(vo1, vo2);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        protected abstract bool EqualsCore(T other);

        /// <summary>
        /// ToStoringメソッド
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return base.ToString();
        }

        /// <summary>
        /// GetHashメソッド
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }
}
