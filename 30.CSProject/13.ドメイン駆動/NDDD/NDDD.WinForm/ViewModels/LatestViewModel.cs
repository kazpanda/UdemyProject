using NDDD.Domain.Entities;
using NDDD.Domain.Repositories;
using NDDD.Infrastructure;
using System;

namespace NDDD.WinForm.ViewModels {

    /// <summary>
    /// LatestViewModel
    /// </summary>
    public class LatestViewModel : ViewModelBase {

        // インターフェイス
        private IMeasureRepository _measureRepository;

        // 
        // private MeasureEntity _measure;

        // 通知の方法を改善する
        private string _areaIdText = string.Empty;
        private string _measureDateText = string.Empty;
        private string _measureValueText = string.Empty;

        /// <summary>
        /// コンストラクター
        /// 何も指定されていないときは
        /// Factoriesを通じてインスタンスを生成する
        /// </summary>
        public LatestViewModel()
            : this(Factories.CreateMeasure()) { 
        }

        /// <summary>
        /// コンストラクター
        /// 引数が指定されている
        /// 指定されたRepositoriesを参照する
        /// </summary>
        /// <param name="measureRepository"></param>
        public LatestViewModel(IMeasureRepository measureRepository) {
            // 共通のインスタンス
            _measureRepository = measureRepository;
        }

        /// <summary>
        /// AreaIdText
        /// </summary>
        public string AreaIdText {
            get {
                return _areaIdText;
            }
            set {
                // View側に通知する
                SetProperty(ref _areaIdText, value);
            }
        }

        /// <summary>
        /// MeasureDateText
        /// </summary>
        public string MeasureDateText {
            get {
                return _measureDateText;
            }
            set {
                // View側に通知する
                SetProperty(ref _measureDateText, value);
            }


        }

        /// <summary>
        /// MeasureValueText
        /// </summary>
        public string MeasureValueText {
            get {
                return _measureValueText;
            }
            set {
                // View側に通知する
                SetProperty(ref _measureValueText, value);
            }
        }

        /// <summary>
        /// サーチ処理
        /// </summary>
        public void Search() {

            var measure = _measureRepository.GetLatest();

            // Viewへ通知
            // base.OnPropertyChanged();
            
            // プロパティーを通じて更新
            // View側へ通知を行う
            AreaIdText = measure.AreaId.ToString().PadLeft(4, '0');
            MeasureDateText = measure.MeasureDate.ToString("yyyy/MM/dd HH:mm:ss");
            MeasureValueText = Math.Round(measure.MeasureValue, 2) + "℃";

        }
    }
}
