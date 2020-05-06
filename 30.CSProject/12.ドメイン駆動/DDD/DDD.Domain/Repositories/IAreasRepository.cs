using DDD.Domain.Entities;
using System.Collections.Generic;

/// <summary>
/// Areaテーブルに対してのリポジトリー（インターフェイス）
/// データ入出力
/// </summary>
namespace DDD.Domain.Repositories {

    /// <summary>
    /// AreaEntityインターフェイス
    /// Areaテーブルから値を取得
    /// DataTableは使わずにAreaEntitiyを使うことでDDDができる
    /// /// </summary>
    public interface IAreasRepository {
        IReadOnlyList<AreaEntity> GetData();
    }
}
