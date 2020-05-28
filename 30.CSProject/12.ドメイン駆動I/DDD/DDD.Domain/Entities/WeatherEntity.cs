using DDD.Domain.ValueObjects;
using System;

namespace DDD.Domain.Entities {

    /// <summary>
    /// Wetherテーブルのエンティティ
    /// sealedにしておく。継承できない
    /// </summary>
    public sealed class WeatherEntity {

        /// <summary>
        /// 完全コンストラクタパターン
        /// 値をコンストラクターで決めてしまう
        /// クラスが生成された時に値が保証される
        /// 出来るだけ完全コンストラクターで作るように
        /// </summary>
        /// <param name="areaId"></param>
        /// <param name="dataDate"></param>
        /// <param name="condition"></param>
        /// <param name="temperature"></param>               
        public WeatherEntity(int areaId,
                             DateTime dataDate,
                            int condition,
                             float temperature) 
            :this(areaId,string.Empty,dataDate,condition,temperature)
            {
            // :this～ 引数（areaName）を追加したコンストラクターをオーバーライドしている
            
            
            //AreaId = areaId;
            //DataDate = dataDate;

            //// ValueObjectを指定
            //// newしたことでValueObjectに変換される
            //Condition = new Condition(condition);
            //Temperature = new Temperature(temperature);
        }

        /// <summary>
        /// 完全コンストラクター
        /// AreaNameを追加した
        /// </summary>
        /// <param name="areaId"></param>
        /// <param name="dataDate"></param>
        /// <param name="condition"></param>
        /// <param name="temperature"></param>               
        public WeatherEntity(int areaId,
                             string areaName,
                             DateTime dataDate,
                            int condition,
                             float temperature) {
            AreaId = new AreaId(areaId);
            AreaName = areaName;
            DataDate = dataDate;

            // ValueObjectを指定
            // newしたことでValueObjectに変換される
            Condition = new Condition(condition);
            Temperature = new Temperature(temperature);
        }

        /// <summary>
        /// プロパティー（DBの項目名）
        /// 完全コンストラクターパターンで値を入れる
        /// getのみにしているので、解析がしやすい
        /// setが入っているとどこかで値が変化する 
        /// C#の型にする
        /// ★ValueObjectを入れる（ロジックは持たせない）
        /// </summary>
        public AreaId AreaId { get; }
        // AreaNameは同じテーブルには無い
        public string AreaName { get; }
        public DateTime DataDate { get; }
        public Condition Condition { get; }
        public Temperature Temperature { get; }


        /// <summary>
        /// メソッドの実装
        /// Entitiyにてメソッドを実装することでロジックが集まる
        /// 仕様が明確になる
        /// </summary>
        /// <returns></returns>
        public bool IsMousho() {
            if (Condition == Condition.Sunny) {
                if (Temperature.Value > 30) {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// メソッドの実装
        /// </summary>
        /// <returns></returns>
        public bool IsOK() {
            if (DataDate < DateTime.Now.AddMonths(-1)) {
                if (Temperature.Value < 10) {
                    return false;
                }

            }
            return true;
        }
    }

}
