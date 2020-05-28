using System.Configuration;

namespace NDDD.Domain {

    /// <summary>
    /// 共通の変数
    /// </summary>
    public static class Shared {

        // SqlServerかFakeか分かるようにする
        // ここでSqlかFakeか切り替える
        // ここで指定するとコンパイルご変更できない
        public static bool IsFake { get; } = 
            ConfigurationManager.AppSettings["fake"] == "1";
    }
}
