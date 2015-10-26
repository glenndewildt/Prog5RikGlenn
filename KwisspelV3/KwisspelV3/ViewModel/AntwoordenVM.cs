using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KwisspelV3.Database;
using System.Data.Entity;

namespace KwisspelV3.ViewModel
{
    public class AntwoordenVM : ViewModelBase
    {
        public Antwoord antwoord;
        private MyContext context;

        public String Tekst
        {
            get { return antwoord.Tekst; }
            set
            {

                antwoord.Tekst = value;
                RaisePropertyChanged("Tekst");
            }
        }

        public int Id
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
                context.Antwoorden.Find(this.antwoord).GoeieAntwoord = value;
                antwoord.GoeieAntwoord = value;
                context.SaveChanges();
                RaisePropertyChanged("GoeieAntwoord");
            }
        }
        public Vraag BijVraag
        {
            get { return antwoord.BijVraag; }
            set
            {
                antwoord.BijVraag = value;
                RaisePropertyChanged("Categorie");
            }
        }

        public int BijVraagId
        {
            get { return antwoord.BijvraagId; }
            set
            {
                antwoord.BijvraagId = value;
                RaisePropertyChanged("Categorie");
            }
        }

        public AntwoordenVM(MyContext context)
        {
            this.context = context;
            antwoord = new Antwoord();

        }

        public AntwoordenVM(Antwoord antwoord, MyContext context)
        {
            // TODO: Complete member initialization
            this.antwoord = antwoord;
            this.context = context;
        }

    }
}
