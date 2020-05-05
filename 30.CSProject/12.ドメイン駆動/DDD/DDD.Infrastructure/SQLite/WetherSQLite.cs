using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using System;
using System.Data.SQLite;

namespace DDD.Infrastructure.SQLite {

    /// <summary>
    /// SQLiteへのアクセス
    /// インターフェイスを継承
    /// </summary>
    public class WetherSQLite : IWeatherRepository {

        // DataTableは使用せずWethereEntitiyカスタムクラスを返却
        public WeatherEntity GetLatest(int areaId) {
            string sql = @"
select DataDate,
Condition,
Temperature
from Weather
where AreaId = @AreaId
order by DataDate desc
LIMIT 1";

            using (var connection = new SQLiteConnection(SQLiteHelper.ConnenctionString))
            using (var command = new SQLiteCommand(sql, connection)) {
                connection.Open();
                command.Parameters.AddWithValue("@AreaId", areaId);
                using (var reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        return new WeatherEntity(
                            areaId,
                            Convert.ToDateTime(reader["DataDate"]),
                            Convert.ToInt32(reader["Condition"]),
                            Convert.ToSingle(reader["Temperature"]));
                    }
                }
            }
            return null;
        }
    }
}
