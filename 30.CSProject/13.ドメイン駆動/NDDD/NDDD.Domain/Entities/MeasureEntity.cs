using System;

namespace NDDD.Domain.Entities {
    public sealed class MeasureEntity {


        /// <summary>
        /// 完全コンストラクター
        /// </summary>
        /// <param name="areaId"></param>
        /// <param name="measureDate"></param>
        /// <param name="measureValue"></param>
        public MeasureEntity(
            int areaId,
            DateTime measureDate,

            float measureValue) {

            AreaId = areaId;
            MeasureDate = measureDate;
            MeasureValue = measureValue;


        }

        public int AreaId { get; }
        public DateTime MeasureDate { get; }
        public float MeasureValue { get; }
    }
}
