namespace AnalyzeSample {

    /// <summary>
    /// 本番用データベースコード
    /// </summary>
    public class DataBase : IDataBase {
    
        /// <summary>
        /// 本番用の実装
        /// </summary>
        /// <returns></returns>
        public int GetDataBaseValue() {
            // 実際はデーターベースに接続
            return 200;
        }
    }
}
