using NDDD.Domain;
using NDDD.Domain.Entities;
using NDDD.Domain.Exceptions;
using NDDD.Domain.Repositories;
using System;

namespace NDDD.Infrastructure.Fake {

    /// <summary>
    /// Measureテーブルのダミーデータ作成
    /// </summary>
    internal sealed class MeasureFake : IMeasureRepository {


        public MeasureEntity GetLatest() {

            // モックのデータをファイルから作成
            try {
                var lines = System.IO.File.ReadAllLines(
                    Shared.FakePath + "MeasureFake.csv");
                var value = lines[0].Split(',');
                return new MeasureEntity(
                    Convert.ToInt32(value[0]),
                    Convert.ToDateTime(value[1]),
                    Convert.ToSingle(value[2]));
            }
            catch(Exception ex){

                // ①ファイルが無かったらデフォルトを返す
                //return new MeasureEntity(
                //1,
                //Convert.ToDateTime("2020/05/27 22:00:00"),
                //12.341f);

                // ②ファイルが無かったら例外を渡す
                // Exception情報も渡す
                throw new FakeException("MeasureFakeの取得に失敗しました。",ex);

            }
        }
    }
}
