using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using System.Windows.Input;
using KwisspelV3.Database;
using System.Linq;
using System.Collections.Generic;

namespace KwisspelV3.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        //Windows
        private AddVraag addVraagWindow;

        MyContext context;

        public ObservableCollection<VragenVM> Vragen { get; set; }
        public ObservableCollection<AntwoordenVM> Antwoorden { get; set; }

        public VragenVM SelectedVraag { get; set; }

        public ICommand ShowAddVraagCommand { get; set; }
        public ICommand SaveVraagCommand { get; set; }

        public MainViewModel()
        {
            ShowAddVraagCommand = new RelayCommand(ShowAddVraag);
            SaveVraagCommand = new RelayCommand(SaveVraag);
            SelectedVraag = new VragenVM();

            context = new MyContext();

            //1. ophalen vragen
            IEnumerable<VragenVM> vragen = context.Vragen
                .ToList().Select(g => new VragenVM(g));
            Vragen = new ObservableCollection<VragenVM>(vragen);


            //dit moeten we zien te fixen
            IEnumerable<AntwoordenVM> antwoorden = context.Antwoorden.ToList().Select(a => new AntwoordenVM(a));
            Antwoorden = new ObservableCollection<AntwoordenVM>(antwoorden);


        }

        private void SaveVraag()
        {
            Vragen.Add(SelectedVraag);
            context.Vragen.Add(SelectedVraag.vraag);
            context.SaveChanges();
            //Voeg ook toe aan de database
            addVraagWindow.Hide();
        }

        private void ShowAddVraag()
        {
            SelectedVraag = new VragenVM();
            RaisePropertyChanged("SelectedGerecht");
            addVraagWindow = new AddVraag();
            addVraagWindow.Show();
        }


    }
}