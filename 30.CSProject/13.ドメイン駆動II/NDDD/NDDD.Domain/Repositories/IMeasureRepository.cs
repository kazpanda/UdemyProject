using NDDD.Domain.Entities;

/// <summary>
/// インターフェイス
/// </summary>
namespace NDDD.Domain.Repositories {

    /// <summary>
    /// Measureインターフェイス
    /// </summary>
    public interface IMeasureRepository {

        // 最新の取得
        MeasureEntity GetLatest();

    }
}
