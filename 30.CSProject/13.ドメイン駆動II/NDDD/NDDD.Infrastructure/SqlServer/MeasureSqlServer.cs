using NDDD.Domain.Entities;
using NDDD.Domain.Repositories;
using System;

namespace NDDD.Infrastructure.SqlServer {

    /// <summary>
    /// SqlServer
    /// internalにしFactoris以外からはNewできなくする
    /// </summary>
    internal sealed class MeasureSqlServer : IMeasureRepository {
       
        public MeasureEntity GetLatest() {
            throw new NotImplementedException();
        }
    }
}
