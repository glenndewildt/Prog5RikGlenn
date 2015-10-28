using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KwisspelV3.Database;
using System.Windows.Input;

namespace KwisspelV3.ViewModel
{
    public class VragenVM : ViewModelBase
    {
        public Vraag vraag;
        private MyContext content;
      

        public String Tekst
        {
            get { return vraag.Tekst; }
            set
            {
                content.Vragen.Where(v => v.Id.Equals(vraag.Id)).ToList().First().Tekst = value; 
                vraag.Tekst = value;
                content.SaveChanges();
                RaisePropertyChanged("Tekst");
            }
        }

        public int Id
        {
            get { return vraag.Id; }
            set
            {
                vraag.Id = value;
                RaisePropertyChanged("Aantal");
            }
        }

        public int AantalAntwoorden
        {
            get
            {
                return vraag.AantalAntwoorden;
            }
            set
            {
                
                vraag.AantalAntwoorden = value;
                RaisePropertyChanged("AantalAntwoorden");
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


        public VragenVM(MyContext content)
        {
            this.content = content;
            vraag = new Vraag();
            Categorie = new VraagCategorie();
        }

        public VragenVM(Vraag gerecht, MyContext content)
        {
            this.content = content;
            this.vraag = gerecht;
        }

    }
}
