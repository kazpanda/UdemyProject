using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace DDD.Infrastructure.SQLite {

    /// <summary>
    /// SQLiteへのアクセス
    /// インターフェイスを継承
    /// </summary>
    public class WetherSQLite : IWeatherRepository {


        // DataTableは使用せずWethereEntitiyカスタムクラスを返却
        public WeatherEntity GetLatest(int areaId) {
            string sql = @"select DataDate,
                            Condition,
                            Temperature
                            from Weather
                            where AreaId = @AreaId
                            order by DataDate desc
                            LIMIT 1";

            // クエリーの実行
            return SQLiteHelper.QuerySingle<WeatherEntity>(
                sql,
                new List<SQLiteParameter> { new SQLiteParameter("@AreaID", areaId) }.ToArray(),
                reader => {
                    return new WeatherEntity(
                            areaId,
                            Convert.ToDateTime(reader["DataDate"]),
                            Convert.ToInt32(reader["Condition"]),
                            Convert.ToSingle(reader["Temperature"]));
                },
                null);
        }

        public IReadOnlyList<WeatherEntity> GetData() {
           
            string sql = @"select A.AreaId,
	                   ifnull(B.AreaName,'') as AreaName,
	                   A.DataDate,
	                   A.Condition,
	                   A.Temperature
                       from Weather A
                       left outer join Areas B
                       on A.AreaId = B.AreaId";

            return SQLiteHelper.Query(sql,
                //reader => {
                //    return new WeatherEntity(
                //        Convert.ToInt32(reader["AreaId"]),
                //        Convert.ToString(reader["AreaName"]),
                //        Convert.ToDateTime(reader["DataDate"]),
                //        Convert.ToInt32(reader["Condition"]),
                //        Convert.ToInt32(reader["Temperature"]));
                //});
                CreateEntity);
        }

        /// <summary>
        /// Entity生成メソッド
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private WeatherEntity CreateEntity(SQLiteDataReader reader) {
            return new WeatherEntity(
                        Convert.ToInt32(reader["AreaId"]),
                        Convert.ToString(reader["AreaName"]),
                        Convert.ToDateTime(reader["DataDate"]),
                        Convert.ToInt32(reader["Condition"]),
                        Convert.ToInt32(reader["Temperature"]));
        }
    }
}
