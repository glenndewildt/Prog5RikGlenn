using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KwisspelV3.Database;
using System.Windows.Input;

namespace KwisspelV3.ViewModel
{
    public class VraagCategorienVM : ViewModelBase
    {
        public VraagCategorie categorie;



        public String SoortName
        {
            get { return categorie.Name; }
            set
            {
                categorie.Name = value;
                RaisePropertyChanged("Tekst");
            }
        }

        public int Id
        {
            get { return categorie.Id; }
            set
            {
                categorie.Id = value;
                RaisePropertyChanged("Aantal");
            }
        }





        public VraagCategorienVM()
        {
            categorie = new VraagCategorie();
        }

        public VraagCategorienVM(VraagCategorie gerecht)
        {
            // TODO: Complete member initialization
            this.categorie = gerecht;
        }

    }
}
