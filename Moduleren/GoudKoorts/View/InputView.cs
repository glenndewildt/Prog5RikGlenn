using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts
{

    class InputView
    {
      
        public InputView() {
           
            GetInput();
        
        }

        public void GetInput (){
            while (!Program.controller.GameOver)
            {

                var a = Console.ReadKey();

                if (a.KeyChar.Equals('q'))
                {
                    Program.controller.Switch('1');
                }
                if (a.KeyChar.Equals('w'))
                {
                    Program.controller.Switch('2');
                }
                if (a.KeyChar.Equals('e'))
                {
                    Program.controller.Switch('3');
                }
                if (a.KeyChar.Equals('r'))
                {
                    Program.controller.Switch('4');
                } if (a.KeyChar.Equals('t'))
                {
                    Program.controller.Switch('5');
                }


            }
    
    }
    }
}
