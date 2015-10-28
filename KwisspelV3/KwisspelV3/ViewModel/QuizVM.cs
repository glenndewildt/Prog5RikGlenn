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
       private MyContext context;


        public String Name
        {
            get { return quiz.Tekst; }
        
               
           set {
                if(quiz.Tekst != null || quiz.Tekst == ""){
                    context.Quizen.Where(v => v.Id.Equals(quiz.Id)).ToList().First().Tekst = value;
                    context.SaveChanges();
                }
      
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
                RaisePropertyChanged(null);
            }
        }

        public List<Vraag> VragenLijst
        {
            get {  return quiz.Vragen; }
            set
            {
                quiz.Vragen= value;
                RaisePropertyChanged(null);
            }
        }





        public QuizVM(MyContext context)
        {
            this.context =context;
            quiz = new Quiz();
        }

        public QuizVM(Quiz quiz,MyContext context)
        {
            // TODO: Complete member initialization
            this.quiz = quiz;
            this.context =context;
        }

    }
}
