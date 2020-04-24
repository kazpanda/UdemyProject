using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.UI {

    /// <summary>
    /// データベース用インターフェイス
    /// 実装はしない
    /// </summary>
    public interface IDB {
        int GetDBValue();
    }
}
