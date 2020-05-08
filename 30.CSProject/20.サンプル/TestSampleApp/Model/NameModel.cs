using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTestApp.Model {
    public sealed class NameModel {
        public string Name { get; }

        /// <summary>
        /// 完全コンストラクター
        /// </summary>
        /// <param name="pName"></param>
        public NameModel(string pName) {
            Name = pName;
        }

        public NameModel() {
        }
    }
}
