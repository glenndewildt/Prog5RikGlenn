using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KwisspelV3.Database;

namespace KwisspelV3.ViewModel
{
    public class VragenVM : ViewModelBase
    {
        public Vraag vraag;

        public String Tekst
        {
            get { return vraag.Tekst; }
            set
            {
                vraag.Tekst = value;
                RaisePropertyChanged("Tekst");
            }
        }

        public int Aantal
        {
            get { return vraag.Aantal; }
            set
            {
                vraag.Aantal = value;
                RaisePropertyChanged("Aantal");
            }
        }





        public VraagCategorie Categorie
        {
            get { return vraag.Categorie; }
            set
            {
                vraag.Categorie = value;
                RaisePropertyChanged("Categorie");
            }
        }


        public VragenVM()
        {
            vraag = new Vraag();
            Categorie = new VraagCategorie();
        }

        public VragenVM(Vraag gerecht)
        {
            // TODO: Complete member initialization
            this.vraag = gerecht;
        }

    }
}
