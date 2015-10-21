using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Thuisbezorgd_EF.Domain;
using System.Linq;
using System.Collections.Generic;

namespace Thuisbezorgd_EF.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        //Windows
        private AddGerecht addGerechtWindow;

        MyContext context;

        public ObservableCollection<VragenVM> Vragen { get; set; }

        public VragenVM SelectedVraag { get; set; }

        public ICommand ShowAddGerechtCommand { get; set; }
        public ICommand SaveGerechtCommand { get; set; }

        public MainViewModel()
        {
            ShowAddGerechtCommand = new RelayCommand(ShowAddGerecht);
            SaveGerechtCommand = new RelayCommand(SaveGerecht);
            SelectedVraag = new VragenVM();

            context = new MyContext();

            //1. ophalen gerechten
            IEnumerable<VragenVM> vragen = context.Vragen
                .ToList().Select(g => new VragenVM(g));
            Vragen = new ObservableCollection<VragenVM>(vragen);

        }

        private void SaveGerecht()
        {
            Vragen.Add(SelectedVraag);
            context.Vragen.Add(SelectedVraag.vraag);
            context.SaveChanges();
            //Voeg ook toe aan de database
            addGerechtWindow.Hide();
        }

        private void ShowAddGerecht()
        {
            SelectedVraag = new VragenVM();
            RaisePropertyChanged("SelectedGerecht");
            addGerechtWindow = new AddGerecht();
            addGerechtWindow.Show();
        }


    }
}