using System;

namespace DDD.Domain.Exceptions {

    /// <summary>
    /// 入力エラー例外クラス
    /// </summary>
    public sealed class InputException : Exception {

        /// <summary>
        /// 入力エラー
        /// </summary>
        /// <param name="message"></param>
        public InputException(string message) : base(message) {

        }
    }
}
