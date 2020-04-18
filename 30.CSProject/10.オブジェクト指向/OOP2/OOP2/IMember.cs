using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2 {

    /// <summary>
    /// インターフェイスの実装
    /// インターフェイスにより、使用される側の処理を共通化
    /// ワンポイント エラーが出たら、CTL＋.にて推奨対策
    /// </summary>
    public interface IMember {
        float Rate { get; }
        string GetName();
    }

    // インターフェイス時には下記を使用する
    //public sealed class SilverMember : IMember {
    //    public float Rate => 1.0f;

    //    public string GetName() {
    //        return "シルバー";
    //    }
    //}

    //public sealed class GoldMember : IMember {
    //    public float Rate => 0.8f;

    //    public string GetName() {
    //        return "ゴールド";
    //    }
    //}

    //public sealed class PlatiumMember : IMember {
    //    public float Rate => 0.6f;

    //    public string GetName() {
    //        return "プラチナ";
    //    }
    //}


}
