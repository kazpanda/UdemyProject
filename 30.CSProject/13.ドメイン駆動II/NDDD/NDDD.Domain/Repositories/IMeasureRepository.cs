using NDDD.Domain.Entities;
using System.Collections.Generic;

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

        // 最新のリスト
        IReadOnlyList<MeasureEntity> GetLatests();

    }
}
