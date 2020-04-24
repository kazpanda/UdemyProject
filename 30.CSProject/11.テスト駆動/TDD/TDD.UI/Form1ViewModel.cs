using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.UI {

    /// <summary>
    /// Form1のViewModel
    /// Form1のコントロールはプライベートなのでViewModelを通じてアクセス
    /// Form1のコントロールを作成しバインドすることで同期を図る
    /// ただしこの方法だとフォームごとに毎回記載しなければならない
    /// 解決方法としてViewModelBaseという共通化することで簡素化できる
    /// INotifyPropertyChanged、PropertyChangedEventHandlerはデータバインドにて必要
    /// </summary>
    public class Form1ViewModel : INotifyPropertyChanged {

        // Form1にて使用しているコントロール
        //private System.Windows.Forms.TextBox ATextBox;
        //private System.Windows.Forms.TextBox BTextBox;
        //private System.Windows.Forms.Label ResultLabel;
        //private System.Windows.Forms.Button CalculationButton;

        // 同期イベントを呼ばれたら実行するようにする

        // テキストボックスA
        private string _aTextBoxText = string.Empty;
        public string ATextBoxText {
            get {
                return _aTextBoxText;
            }
            set {
                if (_aTextBoxText == value) {
                    return;
                }
                _aTextBoxText = value;
                // バインド同期
                OnPropertyChanged("ATextBoxText");
            }
        }
        // テキストボックスB
        private string _bTextBoxText = string.Empty;
        public string BTextBoxText {
            get {
                return _bTextBoxText;
            }
            set {
                if (_bTextBoxText == value) {
                    return;
                }
                _bTextBoxText = value;
                // バインド同期
                OnPropertyChanged("BTextBoxText");
            }
        }
        // ラベル
        private string _resultLabelText = string.Empty;
        public string ResultLabelText {
            get {
                return _resultLabelText;
            }
            set {
                if (_resultLabelText == value) {
                    return;
                }
                _resultLabelText = value;
                // バインド同期
                OnPropertyChanged("ResultLabelText");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// データバインド同期を行う
        /// </summary>
        /// <param name="propertyName"></param>
        public void OnPropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // インターフェイスを保持する
        private IDB _db;
        /// <summary>
        /// コンストラクター
        /// 引数で選択できるようにする
        /// </summary>
        /// <param name="db"></param>
        public Form1ViewModel(IDB db) {
            _db = db;
        }


        /// <summary>
        /// 計算実行ボタン
        /// </summary>
        public void CalculationAction() {
            int a = Convert.ToInt32(ATextBoxText);
            int b = Convert.ToInt32(BTextBoxText);

            // データベースからデータを取得する
            //var db = new DB();
            
            // インターフェイスを経由する
            int dbValue = _db.GetDBValue();
            // メソッド
            ResultLabelText = (Calculation.Sum(a, b) + dbValue).ToString();
            //ResultLabelText = Calculation.Sum(a, b).ToString();

            // データバインドで同期を図る
            // ただこのやり方は抜けが発生しやすい
            //OnPropertyChanged(string.Empty);
        }






    }
}
