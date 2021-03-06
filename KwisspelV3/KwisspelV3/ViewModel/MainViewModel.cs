using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using System.Windows.Input;
using KwisspelV3.Database;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace KwisspelV3.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        //Windows

        public string Vis1;
        public string Vis2;
        public string Vis3;
        public string Vis4;
        private AddVraag addVraagWindow;

        private AddAntwoord addAntwoordWindow;

        private GameWindow addGameWindow;

        private QuizWindow addQuizWindow;

        private AddQuiz addAddQuizWindow;

        private EndGameWindow addEndGameWindow;

        public MyContext context { get; set; }

        public ObservableCollection<VragenVM> Vragen { get; set; }
        public ObservableCollection<VraagCategorienVM> Categorie { get; set; }

        public VraagCategorienVM _selectedCategorie { get; set; }
        public ObservableCollection<AntwoordenVM> Antwoorden { get; set; }
        public ObservableCollection<QuizVM> Quizen { get; set; }
        public ObservableCollection<AntwoordenVM> VraagAntwoorden { get; set; }
        public Vraag SelectedVraagUitQuiz { get; set; }

        public VragenVM _selectedVraag { get; set; }

        public QuizVM _selectedQuiz { get; set; }

        public AntwoordenVM _selectedAntwoord { get; set; }

        public AntwoordenVM[] gameAntwoorden { get; set; }

        public int counterVraag = 0;

        public Vraag currentVraag { get; set; }

        public AntwoordenVM antwoord { get; set; }

        public QuizVM addQuiz { get; set; }

        IEnumerable<AntwoordenVM> vraagAntwoorden = null;

        public int AantalAntwoorden { get; set; }

        public int totaalPunten { get; set; }

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
                        RaisePropertyChanged(null);
                    }
                  
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

                
            }
        }

        public QuizVM SelectedQuiz
        {
            get { return _selectedQuiz; }
            set
            {
                
                _selectedQuiz = value;
                RaisePropertyChanged(null);
            }
        }


        public ICommand ShowAddVraagCommand { get; set; }
        public ICommand SaveVraagCommand { get; set; }
        public ICommand DellVraagCommand { get; set; }
        public ICommand DellAntwoordCommand { get; set; }

        public ICommand DellQuizCommand { get; set; } 

        public ICommand ShowAddAntwoordCommand { get; set; }

        public ICommand AddVraagToQuizCommand { get; set; }
        public ICommand SaveAntwoordCommand { get; set; }

        public ICommand PlayCommand { get; set; }

        public ICommand QuizWindowCommand { get; set; }

        public ICommand AddQuizWindowCommand { get; set; }

        public ICommand AddQuizCommand { get; set; }

        public ICommand DellVraagFromQuizCommand { get; set; }

        public ICommand eersteAntwoord { get; set; }

        public ICommand tweedeAntwoord { get; set; }

        public ICommand derdeAntwoord { get; set; }

        public ICommand vierdeAntwoord { get; set; } 



        public MainViewModel()
        {
            ShowAddVraagCommand = new RelayCommand(ShowAddVraag);
            SaveVraagCommand = new RelayCommand(SaveVraag);
            DellVraagCommand = new RelayCommand(DellVraag);
            DellAntwoordCommand = new RelayCommand(DellAntwoord);
            DellVraagFromQuizCommand = new RelayCommand(DellVraagFromQuiz);
            DellQuizCommand = new RelayCommand(DellQuiz);
            eersteAntwoord = new RelayCommand(EersteAntwoord,CanEersteAntwoord);
            tweedeAntwoord = new RelayCommand(TweedeAntwoord,CanTweedeAntwoord);
            derdeAntwoord = new RelayCommand(DerdeAntwoord,CanDerdeAntwoord);
            vierdeAntwoord = new RelayCommand(VierdeAntwoord,CanVierdeAntwoord);
            ShowAddAntwoordCommand = new RelayCommand(ShowAddAntwoord);
            SaveAntwoordCommand = new RelayCommand(SaveAntwoord);
            AddVraagToQuizCommand = new RelayCommand(AddVraagToQuiz);
            QuizWindowCommand = new RelayCommand(ShowQuizWindow);
            AddQuizWindowCommand = new RelayCommand(ShowAddQuiz);
            AddQuizCommand = new RelayCommand(SaveQuiz);
            PlayCommand = new RelayCommand(PlayGame);
            SelectedQuiz = new QuizVM( context);
            SelectedVraag = new VragenVM(context);
            SelectedCategorie = new VraagCategorienVM();
            currentVraag = new Vraag();
            gameAntwoorden = new AntwoordenVM[10];
            totaalPunten = 0;

            context = new MyContext();

            //1. ophalen vragen
            IEnumerable<VragenVM> vragen = context.Vragen
                .ToList().Select(g => new VragenVM(g, context));
            Vragen = new ObservableCollection<VragenVM>(vragen);

            //Categorie vragen ophalen
          
            if (context.VraagCategorie.Count()== 0)
            {
                context.VraagCategorie.Add(new VraagCategorie() { Id = 1, Name = "Taal" });
                context.VraagCategorie.Add(new VraagCategorie() { Id = 2, Name = "Scheikunde" });
                context.VraagCategorie.Add(new VraagCategorie() { Id = 3, Name = "Wiskunde" });
                context.VraagCategorie.Add(new VraagCategorie() { Id = 4, Name = "Techniek" });
                context.VraagCategorie.Add(new VraagCategorie() { Id = 5, Name = "bier" });
                context.SaveChanges();
            }

            IEnumerable<VraagCategorienVM> categorie = context.VraagCategorie.ToList().Select(c => new VraagCategorienVM(c));
            Categorie = new ObservableCollection<VraagCategorienVM>(categorie);

            // Quizen ophalen
            IEnumerable<QuizVM> quiz = context.Quizen.ToList().Select(c => new QuizVM(c, context));
            Quizen = new ObservableCollection<QuizVM>(quiz);

            //Antwoorden bij de vragen ophalen
            IEnumerable<AntwoordenVM> antwoorden = context.Antwoorden.ToList().Select(a => new AntwoordenVM(a,context));
            Antwoorden = new ObservableCollection<AntwoordenVM>(antwoorden);
            vraagAntwoorden = Antwoorden.Where(a => a.BijVraagId.Equals(_selectedVraag.Id));
            VraagAntwoorden = new ObservableCollection<AntwoordenVM>(vraagAntwoorden);

        }

        private void PlayGame()
        
        {

            if(SelectedQuiz.VragenLijst != null){
                if (SelectedQuiz.VragenLijst.Count > 1)
                {
                    GetVraag();
                    addGameWindow = new GameWindow();
                    addGameWindow.Show();
                }
                else
                {
                    MessageBox.Show("Quiz moet minstens 2 vragen bevatten!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void PlayEndGame()
        {
            addEndGameWindow = new EndGameWindow();
            addEndGameWindow.Show();
            counterVraag = 0;
            totaalPunten = 0;
            counterVraag = 0;
            
        }

        private void GetVraag()
        {

            currentVraag = SelectedQuiz.VragenLijst[counterVraag];
            counterVraag++;

            vraagAntwoorden = Antwoorden.Where(a => a.BijVraagId.Equals(currentVraag.Id));
            VraagAntwoorden = new ObservableCollection<AntwoordenVM>(vraagAntwoorden);

            int tempCounter = 0;
            gameAntwoorden = new AntwoordenVM[10];
            foreach (var e in VraagAntwoorden)
            {
                gameAntwoorden[tempCounter] = e;
                tempCounter = tempCounter + 1;
            }
            eersteAntwoord = new RelayCommand(EersteAntwoord, CanEersteAntwoord);
            tweedeAntwoord = new RelayCommand(TweedeAntwoord, CanTweedeAntwoord);
            derdeAntwoord = new RelayCommand(DerdeAntwoord, CanDerdeAntwoord);
            vierdeAntwoord = new RelayCommand(VierdeAntwoord, CanVierdeAntwoord);
        }

        private void ShowQuizWindow()
        {
            addQuizWindow = new QuizWindow();
            addQuizWindow.Show();
        }

        private void AddVraagToQuiz()
        {
            if (SelectedQuiz != null) {
                if (_selectedVraag != null) {
                    if (SelectedQuiz.VragenLijst == null) {
                        SelectedQuiz.VragenLijst = new List<Vraag>();
                    }
                    if (SelectedQuiz.VragenLijst.Count <= 10 )
                    {
                        for(int i = 0; i < SelectedQuiz.VragenLijst.Count - 1; i++)
                        {
                            if (SelectedVraag.Tekst.Equals(SelectedQuiz.VragenLijst[i].Tekst))
                            {
                                MessageBox.Show("Dubbele Vraag", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                        }
                        SelectedQuiz.quiz.Vragen.Add(SelectedVraag.vraag);

                        context.Quizen.Where(q => q.Id.Equals(SelectedQuiz.Id)).First().Vragen = SelectedQuiz.quiz.Vragen;
                        context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Een Quiz mag maar 10 antwoorden bevatten!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
           
            RaisePropertyChanged(null);
            

        }


        public void SaveVraag()
        {
            
            if (SelectedCategorie != null)
            {
                if (SelectedVraag.Tekst == null || SelectedVraag.Tekst == "")
                {
                    MessageBox.Show("Vul de vraag in het vraagveld in", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    addVraagWindow.Hide();
                    return;
                }
                foreach (var e in Vragen)
                {
                    if(SelectedVraag.Tekst.Equals(e.vraag.Tekst)){
                        MessageBox.Show("Dubbele Vraag", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        addVraagWindow.Hide();
                        return;
                    }
                }
                 
                SelectedVraag.Categorie = SelectedCategorie.categorie;
                Vragen.Add(SelectedVraag);
                context.Vragen.Add(SelectedVraag.vraag);
                context.SaveChanges();
                addVraagWindow.Hide();
            }
            else {
                SelectedVraag.Tekst = null;
                MessageBox.Show("Een Vraag moet een categorie hebben", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveQuiz()
        {
            if (addQuiz.Name == null || addQuiz.Name == "") {
                MessageBox.Show("Een quiz moet een naam hebben", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Quizen.Add(addQuiz);
            context.Quizen.Add(addQuiz.quiz);
            context.SaveChanges();
            addAddQuizWindow.Hide();

        }
        private void DellVraagFromQuiz()
        {
            if (SelectedVraagUitQuiz != null)
            {
                SelectedQuiz.quiz.Vragen.Remove(SelectedVraagUitQuiz);

            }

            context.SaveChanges();
            RaisePropertyChanged(null);
            

        }

        private void DellVraag()
        {
            if (SelectedVraag.Tekst == null)
            {
            return ;
            }
            context.Vragen.Remove(SelectedVraag.vraag);
            Vragen.Remove(SelectedVraag);
            context.SaveChanges();
            SelectedVraag = new VragenVM(context);
            if (Antwoorden != null && SelectedVraag != null)//refreshed the selectedAntwoorden collection
            {
                vraagAntwoorden = Antwoorden.Where(a => a.BijVraagId.Equals(_selectedVraag.Id));
                VraagAntwoorden = new ObservableCollection<AntwoordenVM>(vraagAntwoorden);
            }
            RaisePropertyChanged(null);
   
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
            RaisePropertyChanged(null);

        }

        private void DellQuiz()
        {

            if (SelectedQuiz.Name != null)
            {
                context.Quizen.Remove(SelectedQuiz.quiz);
                Quizen.Remove(SelectedQuiz);

            }

            context.SaveChanges();
            RaisePropertyChanged(null);

        }

        private void SaveAntwoord()
        {
            if(SelectedVraag.AantalAntwoorden < 4){
                if (_selectedVraag.Tekst != null)
                {
                    if (antwoord.Tekst == null || antwoord.Tekst == "")
                    {
                        MessageBox.Show("Een vraag moet tekst bevatten!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
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
                    RaisePropertyChanged(null);
                    addAntwoordWindow.Hide(); // hide window

                }
                else
                {
                    MessageBox.Show("er moet een vraag gesleceteerd zijn", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Een vraag mag maar 4 antwoorden bevatten!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void ShowAddVraag()
        {
            SelectedVraag = new VragenVM(context);
            RaisePropertyChanged(null);
            addVraagWindow = new AddVraag();
            addVraagWindow.Show();
        }

        private void ShowAddAntwoord()
        {
            antwoord = new AntwoordenVM(new Antwoord(),context);
            RaisePropertyChanged(null);
            addAntwoordWindow = new AddAntwoord();
            addAntwoordWindow.Show();
        }

        private void ShowAddQuiz()
        {
            addQuiz = new QuizVM(context);
            RaisePropertyChanged(null);
            addAddQuizWindow = new AddQuiz();
            addAddQuizWindow.Show();
        }

        private void EersteAntwoord()
        {
            if (gameAntwoorden[0].GoeieAntwoord)
            {
                totaalPunten++;
                
            }
            addGameWindow.Hide();

            if (SelectedQuiz.VragenLijst.Count > counterVraag)
            {
                PlayGame();
            }
            else
            {
                PlayEndGame();
            }
        }
        public bool CanEersteAntwoord()
        {

            if (gameAntwoorden[0].Tekst != null)
            {
                Vis2 = "Visble";
                RaisePropertyChanged("Vis1");
                return true;
            }
            Vis2 = "Hidden";
            RaisePropertyChanged("Vis1");
            return false;
        } 

        private void TweedeAntwoord()
        {
            if (gameAntwoorden[1].GoeieAntwoord)
            {
                totaalPunten++;

            }
            addGameWindow.Hide();

            if (SelectedQuiz.VragenLijst.Count > counterVraag)
            {
                PlayGame();
            }
            else
            {
                PlayEndGame();
            }
        }

        public bool CanTweedeAntwoord()
        {

            if (gameAntwoorden[1].Tekst != null)
            {
                Vis2 = "Visble";
                RaisePropertyChanged("Vis2");
                return true;
            }
            Vis2 = "Hidden";
            RaisePropertyChanged("Vis2");
            return false;
        }   

        private void DerdeAntwoord()
        {
            if (gameAntwoorden[2].GoeieAntwoord)
            {
                totaalPunten++;

            }
            addGameWindow.Hide();

            if (SelectedQuiz.VragenLijst.Count > counterVraag)
            {
                PlayGame();
            }
            else
            {
                PlayEndGame();
            }
        }

        public bool CanDerdeAntwoord()
        {

            if (gameAntwoorden[2].Tekst != null)
            {
                Vis2 = "Visble";
                RaisePropertyChanged("Vis3");
                return true;
            }
            Vis2 = "Hidden";
            RaisePropertyChanged("Vis3");
            return false;
        } 

        private void VierdeAntwoord()
        {
            if (gameAntwoorden[3].GoeieAntwoord)
            {
                totaalPunten++;

            }
            addGameWindow.Hide();

            if (SelectedQuiz.VragenLijst.Count > counterVraag)
            {
                PlayGame();
            }
            else
            {
                PlayEndGame();
            }
        }
        public bool CanVierdeAntwoord()
        {

            if (gameAntwoorden[3].Tekst != null)
            {
                Vis2 = "Visble";
                RaisePropertyChanged("Vis4");
                return true;
            }
            Vis2 = "Hidden";
            RaisePropertyChanged("Vis4");
            return false;
        } 
    }
}