namespace DDD.Domain.Entities {

    /// <summary>
    /// AreaEntity
    /// </summary>
    public sealed class AreaEntity {
        
        /// <summary>
        /// 完全コンストラクター
        /// </summary>
        public AreaEntity(int areaId, string areaName) {
            AreaId = areaId;
            AreaName = areaName;
        }
        public int AreaId { get; }
        public string AreaName { get; }
    }
}
