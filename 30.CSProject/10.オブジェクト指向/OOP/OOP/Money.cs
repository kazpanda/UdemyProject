using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP {

    /// <summary>
    /// Moneyクラス
    /// 通常のクラスの考え方
    /// </summary>
    public class Money {
    
        public Money(decimal value) {
            Value = value;
        }

        public decimal Value { get; }

        public decimal TaxValue {
            get {
                return Value * 1.08m;
            }
        }

    }

}
