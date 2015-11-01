using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace GoudKoorts
{
    class Program
    {

       public static Board board;
        public static OutputView Output;
        public static InputView Input;
        static void Main(string[] args)
        {
            board = new Board();
            Output = new OutputView();
            Input = new InputView();

         
        }

 
    }
}
