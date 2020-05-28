
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace DDD.Infrastructure.SQLite {

    /// <summary>
    /// SQLit全般で使う機能
    /// アクセスはinternalで十分
    /// </summary>
    internal class SQLiteHelper {

        // 接続文字
        internal const string ConnenctionString = @"Data Source = DDD.db;Version=3;";


        /// <summary>
        /// クエリー実行（コマンドパラメータなし）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="createEntity"></param>
        /// <returns></returns>
        internal static IReadOnlyList<T> Query<T>(
            string sql,
            Func<SQLiteDataReader, T> createEntity) {
            return Query<T>(sql, null, createEntity);
        }

        /// <summary>
        /// クエリー実行（コマンドパラメータあり）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="createEntity"></param>
        /// <returns></returns>
        internal static IReadOnlyList<T> Query<T>(
            string sql,
            SQLiteParameter[] parameters,
            Func<SQLiteDataReader, T> createEntity) {

            var result = new List<T>();
            using (var connection = new SQLiteConnection(SQLiteHelper.ConnenctionString))
            using (var command = new SQLiteCommand(sql, connection)) {
                connection.Open();
                if (parameters != null) {
                    command.Parameters.AddRange(parameters);
                }
                using (var reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        result.Add(createEntity(reader));
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// クエリー実行（コマンドパラメータなし）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="createEntity"></param>
        /// <param name="nullEntity"></param>
        /// <returns></returns>
        internal static T QuerySingle<T>(
            string sql, Func<SQLiteDataReader, T> createEntity,
            T nullEntity) {
            return QuerySingle<T>(sql, null, createEntity, nullEntity);
        }

        /// <summary>
        /// クエリー実行（コマンドパラメータあり）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="createEntity"></param>
        /// <param name="nullEntity"></param>
        /// <returns></returns>
        internal static T QuerySingle<T>(
            string sql,
            SQLiteParameter[] parameters,
            Func<SQLiteDataReader, T> createEntity,
            T nullEntity) {

            using (var connection = new SQLiteConnection(SQLiteHelper.ConnenctionString))
            using (var command = new SQLiteCommand(sql, connection)) {
                connection.Open();
                if (parameters != null) {
                    command.Parameters.AddRange(parameters);
                }
                using (var reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        return createEntity(reader);
                    }
                }
            }
            return nullEntity;
        }


        /// <summary>
        /// コマンド実行（追加、更新）共通関数
        /// </summary>
        /// <param name="insert"></param>
        /// <param name="update"></param>
        /// <param name="args"></param>
        internal static void Execute(
            string insert,
            string update,
            SQLiteParameter[] parameters
            ) {

            // UpdateとInsert
            using (var connection = new SQLiteConnection(SQLiteHelper.ConnenctionString))
            using (var command = new SQLiteCommand(update, connection)) {
                connection.Open();
                if (parameters != null) {
                    command.Parameters.AddRange(parameters);
                }
                // 戻り値から件数を取得し件数が無かったらUpdateにする
                if (command.ExecuteNonQuery() < 1) {
                    command.CommandText = insert;
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// コマンド実行（コマンド）共通関数
        /// </summary>
        /// <param name="insert"></param>
        /// <param name="update"></param>
        /// <param name="args"></param>
        internal static void Execute(
            string sql,
            SQLiteParameter[] parameters) {

            // SQLコマンドの実行
            using (var connection = new SQLiteConnection(SQLiteHelper.ConnenctionString))
            using (var command = new SQLiteCommand(sql, connection)) {
                connection.Open();
                if (parameters != null) {
                    command.Parameters.AddRange(parameters);
                }

                command.ExecuteNonQuery();
            }
        }

    }
}
