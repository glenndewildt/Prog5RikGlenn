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
        public ObservableCollection<VraagCategorienVM> Categorie { get; set; }

        public VraagCategorienVM _selectedCategorie { get; set; }
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
                    
                    if (Antwoorden != null && SelectedVraag != null)
                    {
                        vraagAntwoorden = Antwoorden.Where(a => a.BijVraagId.Equals(_selectedVraag.Id));
                        VraagAntwoorden = new ObservableCollection<AntwoordenVM>(vraagAntwoorden);
                    }
                    RaisePropertyChanged("VraagAntwoorden");
                }
            }
        }

        public AntwoordenVM SelectedAntwoord
        {
            get { return _selectedAntwoord; }
            set
            {
                if (_selectedAntwoord != value)
                {
                    _selectedAntwoord = value;

                    
                    RaisePropertyChanged();
                }
            }
        }
        public VraagCategorienVM SelectedCategorie
        {
            get { return _selectedCategorie; }
            set
            {
               
                    _selectedCategorie = value;
                    IEnumerable<VragenVM> vragen = context.Vragen
                .ToList().Select(g => new VragenVM(g)).Where(v => v.Categorie.Id.Equals(SelectedCategorie.Id));
                    Vragen = new ObservableCollection<VragenVM>(vragen);

                    RaisePropertyChanged("Vragen");
                
            }
        }


        public ICommand ShowAddVraagCommand { get; set; }
        public ICommand SaveVraagCommand { get; set; }
        public ICommand DellVraagCommand { get; set; }
        public ICommand DellAntwoordCommand { get; set; }

        public ICommand ShowAddAntwoordCommand { get; set; }
        public ICommand SaveAntwoordCommand { get; set; }

        public ICommand PlayCommand { get; set; }

        public MainViewModel()
        {
            ShowAddVraagCommand = new RelayCommand(ShowAddVraag);
            SaveVraagCommand = new RelayCommand(SaveVraag);
            DellVraagCommand = new RelayCommand(DellVraag);
            DellAntwoordCommand = new RelayCommand(DellAntwoord);
            ShowAddAntwoordCommand = new RelayCommand(ShowAddAntwoord);
            SaveAntwoordCommand = new RelayCommand(SaveAntwoord);
            PlayCommand = new RelayCommand(PlayGame);
            SelectedVraag = new VragenVM();

            context = new MyContext();

            //1. ophalen vragen
            IEnumerable<VragenVM> vragen = context.Vragen
                .ToList().Select(g => new VragenVM(g));
            Vragen = new ObservableCollection<VragenVM>(vragen);
            //Categorie vragen ophalen
            IEnumerable<VraagCategorienVM> categorie = context.VraagCategorie.ToList().Select(c => new VraagCategorienVM(c));
            Categorie = new ObservableCollection<VraagCategorienVM>(categorie);


            //Antwoorden bij de vragen ophalen
            IEnumerable<AntwoordenVM> antwoorden = context.Antwoorden.ToList().Select(a => new AntwoordenVM(a,context));
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
            SelectedVraag.Categorie = SelectedCategorie.categorie;
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
            SelectedVraag = new VragenVM();
            if (Antwoorden != null && SelectedVraag != null)//refreshed the selectedAntwoorden collection
            {
                vraagAntwoorden = Antwoorden.Where(a => a.BijVraagId.Equals(_selectedVraag.Id));
                VraagAntwoorden = new ObservableCollection<AntwoordenVM>(vraagAntwoorden);
            }
            RaisePropertyChanged("VraagAntwoorden");

            
        }
        private void DellAntwoord()
        {

            if (SelectedAntwoord != null) {
                Antwoorden.Remove(SelectedAntwoord);
                context.Antwoorden.Remove(SelectedAntwoord.antwoord);
                SelectedVraag.AantalAntwoorden = SelectedVraag.AantalAntwoorden - 1;
            }
           
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
            if (_selectedVraag.Tekst != null)
            {
                antwoord.BijVraag = _selectedVraag.vraag;
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
            }
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
            antwoord = new AntwoordenVM(new Antwoord(),context);
            RaisePropertyChanged("SelectedAntwoord");
            addAntwoordWindow = new AddAntwoord();
            addAntwoordWindow.Show();
        }
    }
}