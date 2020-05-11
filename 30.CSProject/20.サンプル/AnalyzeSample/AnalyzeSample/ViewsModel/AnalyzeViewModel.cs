using AnalyzeSample.ViewsModel;
using System;
using System.ComponentModel;

namespace AnalyzeSample {

    /// <summary>
    /// AnalyzeViewのViewModel
    /// AnalyzeViewのコントロールはプライベートなのでViewModelを通じてアクセス
    /// AnalyzeViewのコントロールを作成しバインドすることで同期を図る
    /// ただしこの方法だとフォームごとに毎回記載しなければならない
    /// 解決方法としてViewModelBaseという共通化することで簡素化できる
    /// INotifyPropertyChanged、PropertyChangedEventHandlerはデータバインドにて必要
    /// </summary>
    public class AnalyzeViewModel : INotifyPropertyChanged {

        // インターフェイスを保持する
        private IDataBase eIDataBase;

        // 同期イベントを呼ばれたら実行するようにする
        public event PropertyChangedEventHandler PropertyChanged;

        // テキストボックスAバインド
        private string eATextBoxText = string.Empty;
        public string ATextBoxText {
            get {
                return eATextBoxText;
            }
            set {
                if (eATextBoxText == value) {
                    return;
                }
                eATextBoxText = value;
                // バインド同期
                OnPropertyChanged("ATextBoxText");
            }
        }
        // テキストボックスBバインド
        private string eBTextBoxText = string.Empty;
        public string BTextBoxText {
            get {
                return eBTextBoxText;
            }
            set {
                if (eBTextBoxText == value) {
                    return;
                }
                eBTextBoxText = value;
                // バインド同期
                OnPropertyChanged("BTextBoxText");
            }
        }
        // ラベルバインド
        private string eResultLabelText = string.Empty;
        public string ResultLabelText {
            get {
                return eResultLabelText;
            }
            set {
                if (eResultLabelText == value) {
                    return;
                }
                eResultLabelText = value;
                // バインド同期
                OnPropertyChanged("ResultLabelText");
            }
        }


        /// <summary>
        /// データバインド同期を行う
        /// </summary>
        /// <param name="propertyName"></param>
        public void OnPropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }                                


        /// <summary>
        /// コンストラクター
        /// 引数で選択できるようにする
        /// </summary>
        /// <param name="pIDataBase"></param>
        public AnalyzeViewModel(IDataBase pIDataBase) {
            eIDataBase = pIDataBase;
        }


        /// <summary>
        /// 分析実行ボタン
        /// </summary>
        public void Analyze() {
            
            int eAValue = Convert.ToInt32(ATextBoxText);
            int eBValue = Convert.ToInt32(BTextBoxText);
            
            // インターフェイスを経由する
            int eDataBaseValue = eIDataBase.GetDataBaseValue();
            
            // データのチェック
            if(eAValue < 0) {
                throw new InputException("入力値異常");
            }

            // 分析処理
            // 合計値＋DBの値
            ResultLabelText = (AnalyzeSample.Analyze.Sum(eAValue, eBValue) + eDataBaseValue).ToString();

            // データバインドで同期を図る
            // ただこのやり方は抜けが発生しやすいので共通の基底クラスがベスト
            OnPropertyChanged(string.Empty);
        }
    }
}
