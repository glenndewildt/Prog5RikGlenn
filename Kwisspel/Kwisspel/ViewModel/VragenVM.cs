using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwisspel.ViewModel
{
   public class VragenVM : ViewModelBase
    {
        private Model.Vraag vraag;
        public int Id {
            get {
                return vraag.Id;
            }
            set {
                vraag.Id = value;
                RaisePropertyChanged("Id");
            }
        }

        public string Vraag
        {
            get
            {
                return vraag.StringVraag;
            }
            set
            {
                vraag.StringVraag = value;
                RaisePropertyChanged("Vraag");
            }
        }

        public string Soort
        {
            get
            {
                return vraag.Soort;
            }
            set
            {
                vraag.Soort = value;
                RaisePropertyChanged("Soort");
            }
        }

         public VragenVM(Model.Vraag vraag)
        {
            // TODO: Complete member initialization
            this.vraag = vraag;
        }

        public VragenVM()
        {
            vraag = new Model.Vraag();
        }

        public Model.Vraag ToVraag()
        {
            return vraag;
        }

    }
}
