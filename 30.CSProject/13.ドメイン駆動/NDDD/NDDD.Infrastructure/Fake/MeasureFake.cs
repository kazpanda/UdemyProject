using NDDD.Domain.Entities;
using NDDD.Domain.Repositories;
using System;

namespace NDDD.Infrastructure.Fake {

    /// <summary>
    /// Measureテーブルのダミーデータ作成
    /// </summary>
    internal sealed class MeasureFake : IMeasureRepository {


        public MeasureEntity GetLatest() {

            // モックのデータを作成
            return new MeasureEntity(
                1,
                Convert.ToDateTime("2020/05/27 22:00:00"),
                12.341f);
        }
    }
}
