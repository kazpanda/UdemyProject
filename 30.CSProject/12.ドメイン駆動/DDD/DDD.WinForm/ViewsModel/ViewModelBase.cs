using DDD.Domain.Repositories;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DDD.WinForm.ViewsModel {

    public abstract class ViewModelBase : INotifyPropertyChanged {

        private IWeatherRepository _weather;

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T field,
            T value, [CallerMemberName]string propertyName = null) {
            if (Equals(field, value)) {
                return false;
            }
            field = value;
            var h = this.PropertyChanged;
            if (h != null) {
                h(this, new PropertyChangedEventArgs(propertyName));

            }
            return true;
        }

    }
}



    