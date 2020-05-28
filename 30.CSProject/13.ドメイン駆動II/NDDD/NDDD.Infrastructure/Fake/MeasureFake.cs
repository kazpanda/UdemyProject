using NDDD.Domain.Entities;
using NDDD.Domain.Repositories;
using System;

namespace NDDD.Infrastructure.Fake {

    /// <summary>
    /// Measureテーブルのダミーデータ作成
    /// </summary>
    internal sealed class MeasureFake : IMeasureRepository {

        internal const string FakePath = @"";

        public MeasureEntity GetLatest() {

            // モックのデータを作成
            //return new MeasureEntity(
            //    1,
            //    Convert.ToDateTime("2020/05/27 22:00:00"),
            //    12.341f);

            try {
                var lines = System.IO.File.ReadAllLines(
                    FakePath + "MeasureFake.csv");
                var value = lines[0].Split(',');
                return new MeasureEntity(
                    Convert.ToInt32(value[0]),
                    Convert.ToDateTime(value[1]),
                    Convert.ToSingle(value[2]));
            }
            catch{
                return new MeasureEntity(
                1,
                Convert.ToDateTime("2020/05/27 22:00:00"),
                12.341f);

            }
        }
    }
}
