using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KwisspelV3.Database;

namespace KwisspelV3.ViewModel
{
    public class AntwoordenVM : ViewModelBase
    {
        public Antwoord antwoord;

        public String Tekst
        {
            get { return antwoord.Tekst; }
            set
            {
                antwoord.Tekst = value;
                RaisePropertyChanged("Tekst");
            }
        }

        public String Id
        {
            get { return antwoord.Id; }
            set
            {
                antwoord.Id = value;
                RaisePropertyChanged("Id");
            }
        }

        public Boolean GoeieAntwoord
        {
            get { return antwoord.GoeieAntwoord; }
            set
            {
                antwoord.GoeieAntwoord = value;
                RaisePropertyChanged("GoeieAntwoord");
            }
        }

        public AntwoordenVM()
        {
            antwoord = new Antwoord();

        }

        public AntwoordenVM(Antwoord antwoord)
        {
            // TODO: Complete member initialization
            this.antwoord = antwoord;
        }

    }
}
