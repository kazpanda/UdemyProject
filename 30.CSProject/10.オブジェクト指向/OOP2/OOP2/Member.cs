using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2 {

    /// <summary>
    /// 抽象クラスサンプル
    /// </summary>
    public abstract class Member {
        
        /// <summary>
        /// 直接は呼ばれないようにする
        /// </summary>
        protected abstract float Rate { get; }
        public abstract string GetName();

        /// <summary>
        /// ロジックのサンプル
        /// 呼び出しはこちらを呼ぶ
        /// １０日の時は５０％を返す
        /// </summary>
        /// <returns></returns>
        public float GetRate() {
            if (DateTime.Now.Day == 10) {
                return 0.5f;
            }
            return Rate;
        }
    }

    
    public sealed class SilverMember : Member {

        protected override float Rate => 1.0f;

        public override string GetName(){
            return "シルバー";
        }
    }

    public sealed class GoldMember : Member {

        protected override float Rate => 0.8f;

        public override string GetName() {
            return "ゴールド";
        }

    }

    public sealed class PlatiumMember : Member {

        protected override float Rate => 0.6f;

        public override string GetName() {
            return "プラチナ";
        }
    }

}
