using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KwisspelV3.Database;
using System.Windows.Input;

namespace KwisspelV3.ViewModel
{
    public class QuizVM : ViewModelBase
    {
        public Quiz quiz;



        public String Name
        {
            get { return quiz.Tekst; }
            set
            {
                quiz.Tekst = value;
                RaisePropertyChanged("Name");
            }
        }

        public int Id
        {
            get { return quiz.Id; }
            set
            {
                quiz.Id = value;
                RaisePropertyChanged("Id");
            }
        }

        public List<Vraag> VragenLijst
        {
            get {  return quiz.Vragen; }
            set
            {
                quiz.Vragen= value;
                RaisePropertyChanged("VragenLijst");
            }
        }





        public QuizVM()
        {
            quiz = new Quiz();
        }

        public QuizVM(Quiz quiz)
        {
            // TODO: Complete member initialization
            this.quiz = quiz;
        }

    }
}
