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
                    
                    if (Antwoorden != null)
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

        public ICommand ShowAddAntwoordCommand { get; set; }
        public ICommand SaveAntwoordCommand { get; set; }

        public ICommand PlayCommand { get; set; }

        public MainViewModel()
        {
            ShowAddVraagCommand = new RelayCommand(ShowAddVraag);
            SaveVraagCommand = new RelayCommand(SaveVraag);
            ShowAddAntwoordCommand = new RelayCommand(ShowAddAntwoord);
            SaveAntwoordCommand = new RelayCommand(SaveAntwoord);
            PlayCommand = new RelayCommand(PlayGame);
            SelectedVraag = new VragenVM();

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
            addGameWindow = new GameWindow();
            addGameWindow.Show();
        }

        private void SaveVraag()
        {
            
            Vragen.Add(SelectedVraag);
            context.Vragen.Add(SelectedVraag.vraag);
            context.SaveChanges();
            addVraagWindow.Hide();
        }

        private void SaveAntwoord()
        {
            antwoord.BijVraag = SelectedVraag.vraag;
            antwoord.GoeieAntwoord = false;
            Antwoorden.Add(antwoord);
            context.Antwoorden.Add(antwoord.antwoord);
            context.SaveChanges();
            addAntwoordWindow.Hide();
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