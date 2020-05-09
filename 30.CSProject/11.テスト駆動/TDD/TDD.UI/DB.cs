namespace TDD.UI {

    /// <summary>
    /// 本番用データベースコード
    /// インターフェイスを継承するので実装が必要
    /// </summary>
    public class DB : IDB {
    
        /// <summary>
        /// 本番用の実装
        /// </summary>
        /// <returns></returns>
        public int GetDBValue() {
            // 実際はデーターベースに接続
            // 実装する
            return 200;
        }
    }
}
