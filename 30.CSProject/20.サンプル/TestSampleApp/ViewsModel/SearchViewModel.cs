using System;
using SampleTestApp.Model;

namespace SampleTestApp.ViewsModel {

    public sealed class SearchViewModel {

        public SearchViewModel() {
        }

        private NameModel eModel = new NameModel();

        private string eSearchText = string.Empty;
        public string SearchText {
            get {
                return this.eSearchText;
            }
            set {
                this.eSearchText = value;
            }
        }

        private string eSearchLabel = "****";
        public string SearchLabel {
            get {
                return this.eSearchLabel;
            }
            set {
                this.eSearchLabel = value;
            }
        }



        public void Search() {
            SearchLabel = "Hit!!!";

        }
    }
}
