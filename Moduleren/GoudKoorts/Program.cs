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

       public static Controller controller;
        public static OutputView Output;
        public static InputView Input;
        static void Main(string[] args)
        {
            controller = new Controller();
            Output = new OutputView();
            Input = new InputView();
        }
    }
}
