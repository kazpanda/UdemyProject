using NDDD.Domain;
using System.Windows.Forms;

namespace NDDD.WinForm.Views {

    /// <summary>
    /// Form用基底クラス
    /// 共通のステータスバー表示制御
    /// </summary>
    public partial class BaseForm : Form {


        /// <summary>
        /// コンストラクター
        /// </summary>
        public BaseForm() {

            InitializeComponent();

            toolStripStatusLabel1.Visible = false;

#if DEBUG
            // デバッグビルド時の表示
            toolStripStatusLabel1.Visible = true;

#endif
            // BaseFormにStatic変数を表示させる
            UserIdLabel.Text = Shared.LoginId;

        }
    }
}
