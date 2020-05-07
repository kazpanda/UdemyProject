using DDD.Domain.Exceptions;

namespace DDD.Domain.Helpers {

    /// <summary>
    /// Guardクラス
    /// </summary>
    public static class Guard {

        /// <summary>
        /// Null判定
        /// </summary>
        /// <param name="o"></param>
        /// <param name="message"></param>
        public static void IsNull(object o,string message)          {
            if (o == null) {
                throw new InputException(message);
            }
        }

        /// <summary>
        /// Floatの判定
        /// </summary>
        /// <param name="text"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static float IsFloat(string text,string message) {
            float floatValue;
            if (!float.TryParse(text, out floatValue)) {
                throw new InputException(message);
            }
            return floatValue;
        }
    }
}
