using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace DDD.Infrastructure.SQLite {

    /// <summary>
    /// SQLiteへのアクセス
    /// Areaデータ取得
    /// インターフェイスを継承し実装が必要
    /// </summary>
    public sealed class AreasSQLite : IAreasRepository {
       
        /// <summary>
        /// データ取得メソッド
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<AreaEntity> GetData() {
            string sql = @"select AreaId, AreaName from Areas";
            // クエリーの実行
            return SQLiteHelper.Query<AreaEntity>(
                sql,                
                CreateEntity);
        }

        /// <summary>
        /// Entity生成メソッド
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private AreaEntity CreateEntity(SQLiteDataReader reader) {
            return new AreaEntity(Convert.ToInt32(reader["AreaId"]),
                Convert.ToString(reader["AreaName"]));
        }
    }
}

