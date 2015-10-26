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

        private AddAntwoord addAntwoordWindow;

        private GameWindow addGameWindow;

        MyContext context;

        public ObservableCollection<VragenVM> Vragen { get; set; }
        public ObservableCollection<AntwoordenVM> Antwoorden { get; set; }
        public ObservableCollection<AntwoordenVM> VraagAntwoorden { get; set; }
        public VragenVM _selectedVraag { get; set; }

        public VragenVM[] gameVragen { get; set; }

        public int counterVraag = 0;

        public VragenVM currentVraag { get; set; }

        public AntwoordenVM _selectedAntwoord { get; set; }

        public AntwoordenVM antwoord { get; set; }


        IEnumerable<AntwoordenVM> vraagAntwoorden = null;

        public int AantalAntwoorden { get; set; }

        public VragenVM SelectedVraag
        {
            get { return _selectedVraag; }
            set
            {
                if (SelectedVraag != value)
                {
                    _selectedVraag = value;
                    
                    if (Antwoorden != null && SelectedVraag != null)
                    {
                        vraagAntwoorden = Antwoorden.Where(a => a.BijVraagId.Equals(_selectedVraag.Id));
                        VraagAntwoorden = new ObservableCollection<AntwoordenVM>(vraagAntwoorden);
                    }
                    RaisePropertyChanged("VraagAntwoorden");
                }
            }
        }


        public ICommand ShowAddVraagCommand { get; set; }
        public ICommand SaveVraagCommand { get; set; }
        public ICommand DellVraagCommand { get; set; }

        public ICommand ShowAddAntwoordCommand { get; set; }
        public ICommand SaveAntwoordCommand { get; set; }

        public ICommand PlayCommand { get; set; }

        public MainViewModel()
        {
            ShowAddVraagCommand = new RelayCommand(ShowAddVraag);
            SaveVraagCommand = new RelayCommand(SaveVraag);
            DellVraagCommand = new RelayCommand(DellVraag);
            ShowAddAntwoordCommand = new RelayCommand(ShowAddAntwoord);
            SaveAntwoordCommand = new RelayCommand(SaveAntwoord);
            PlayCommand = new RelayCommand(PlayGame);
            SelectedVraag = new VragenVM();
            currentVraag = new VragenVM();
            gameVragen = new VragenVM[10];

            context = new MyContext();

            //1. ophalen vragen
            IEnumerable<VragenVM> vragen = context.Vragen
                .ToList().Select(g => new VragenVM(g));
            Vragen = new ObservableCollection<VragenVM>(vragen);

            //dit moeten we zien te fixen
            IEnumerable<AntwoordenVM> antwoorden = context.Antwoorden.ToList().Select(a => new AntwoordenVM(a));
            Antwoorden = new ObservableCollection<AntwoordenVM>(antwoorden);
            vraagAntwoorden = Antwoorden.Where(a => a.BijVraagId.Equals(_selectedVraag.Id));
            VraagAntwoorden = new ObservableCollection<AntwoordenVM>(vraagAntwoorden);


        }

        private void PlayGame()
        {
            GetVraag();
            addGameWindow = new GameWindow();
            addGameWindow.Show();
        }

        private void GetVraag()
        {
            int tempCounter = 0;
            foreach (var e in Vragen)
            {
                gameVragen[tempCounter] = e;
                tempCounter = tempCounter + 1;
            }

            currentVraag = gameVragen[0];
            counterVraag++;
            
        }

        private void SaveVraag()
        {
            Vragen.Add(SelectedVraag);
            context.Vragen.Add(SelectedVraag.vraag);
            context.SaveChanges();
            addVraagWindow.Hide();
        }

        private void DellVraag()
        {

            context.Vragen.Remove(SelectedVraag.vraag);
            Vragen.Remove(SelectedVraag);
            context.SaveChanges();
            if (Antwoorden != null)//refreshed the selectedAntwoorden collection
            {
                vraagAntwoorden = Antwoorden.Where(a => a.BijVraagId.Equals(_selectedVraag.Id));
                VraagAntwoorden = new ObservableCollection<AntwoordenVM>(vraagAntwoorden);
            }
            RaisePropertyChanged("VraagAntwoorden");

        
            
        }

        private void SaveAntwoord()
        {
            antwoord.BijVraag = _selectedVraag.vraag;
            antwoord.GoeieAntwoord = false;
            Antwoorden.Add(antwoord);
            SelectedVraag.AantalAntwoorden = SelectedVraag.AantalAntwoorden + 1;

            context.Antwoorden.Add(antwoord.antwoord);
            context.SaveChanges();

            if (Antwoorden != null)//refreshed the selectedAntwoorden collection
            {
                vraagAntwoorden = Antwoorden.Where(a => a.BijVraagId.Equals(_selectedVraag.Id));
                VraagAntwoorden = new ObservableCollection<AntwoordenVM>(vraagAntwoorden);
            }
            RaisePropertyChanged("VraagAntwoorden");

            addAntwoordWindow.Hide(); // hide window
        }


        private void ShowAddVraag()
        {
            SelectedVraag = new VragenVM();
            RaisePropertyChanged("SelectedVraag");
            addVraagWindow = new AddVraag();
            addVraagWindow.Show();
        }

        private void ShowAddAntwoord()
        {
            antwoord = new AntwoordenVM(new Antwoord());
            RaisePropertyChanged("SelectedAntwoord");
            addAntwoordWindow = new AddAntwoord();
            addAntwoordWindow.Show();
        }
    }
}