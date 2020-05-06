using DDD.Domain.Entities;
using System.Collections.Generic;

namespace DDD.Domain.Repositories {

    /// <summary>
    /// Weatherテーブルに対してのリポジトリー（インターフェイス）
    /// データ入出力
    /// </summary>
    public interface IWeatherRepository
    {
        /// <summary>
        /// WeatherEntityインターフェイス
        /// Wethereテーブルから値を取得
        /// DataTableは使わずにWethereEntitiyを使うことでDDDができる
        /// </summary>
        /// <param name="areaId"></param>
        /// <returns></returns>
        WeatherEntity GetLatest(int areaId);

        IReadOnlyList<WeatherEntity> GetData();
    }
}
