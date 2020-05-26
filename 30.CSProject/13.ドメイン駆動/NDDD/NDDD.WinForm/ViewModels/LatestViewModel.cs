using NDDD.Domain.Entities;
using NDDD.Domain.Repositories;
using System;

namespace NDDD.WinForm.ViewModels {

    public class LatestViewModel : ViewModelBase {

        private IMeasureRepository _measureRepository;
        private MeasureEntity _measure;


        public LatestViewModel(IMeasureRepository measureRepository) {
            _measureRepository = measureRepository;
        }

        public string AreaIdText {
            get {
                if (_measure == null) {
                    return string.Empty;
                }
                return _measure.AreaId.ToString().PadLeft(4, '0');
            }
        }

        public string MeasureDateText {
            get {
                if (_measure == null) {
                    return string.Empty;
                }
                return _measure.MeasureDate.ToString("yyyy/MM/dd HH:mm:ss"); 
                }
        }

        public string MeasureValueText {
            get {
                if(_measure == null) {
                    return string.Empty;
                }
                return Math.Round(_measure.MeasureValue, 2) + "℃";
            }
        }

        public void Search() {
            _measure = _measureRepository.GetLatest();
        }
    }
}
