
using NDDD.Domain;
using NDDD.Domain.Repositories;
using NDDD.Infrastructure.Fake;
using NDDD.Infrastructure.SqlServer;

namespace NDDD.Infrastructure {

    /// <summary>
    /// システム全体にてインスタンスを生成する箇所を集約する
    /// </summary>
    public static class Factories {

        /// <summary>
        /// Factoryパターン
        /// インスタンスを生成する
        /// SqlServerかFakeか切り替える
        /// </summary>
        /// <returns></returns>
        public static IMeasureRepository CreateMeasure() {

// リリースでは走らないようにする
#if DEBUG
            if (Shared.IsFake) {
                return new MeasureFake();
            }
#endif
            return new MeasureSqlServer();

        }
    }
}
