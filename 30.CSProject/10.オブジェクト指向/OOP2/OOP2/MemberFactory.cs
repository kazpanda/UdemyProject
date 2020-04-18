using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2 {

    /// <summary>
    /// Factoryの使いどころ
    /// </summary>
    public static class MemberFactory {
        
        /// <summary>
        /// 列挙体
        /// </summary>
        public enum MemberKind {
            Silver,
            Gold,
            Platium,
        }

        /// <summary>
        /// オブジェクトの生成
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public static Member Create(MemberKind member) {

            if(member == MemberKind.Gold) {
                return new GoldMember();
            }

            if (member == MemberKind.Platium  ) {
                return new PlatiumMember();
            }

            if (member == MemberKind.Gold) {
                return new GoldMember();
            }

            return new SilverMember();

        }
    }
}
