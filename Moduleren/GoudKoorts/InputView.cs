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
       while (true)
            {

                var a = Console.ReadKey();

                Console.WriteLine(a.Key);
                if (a.KeyChar.Equals('q'))
                {
                    Program.board.Switch('1');
                }
                if (a.KeyChar.Equals('w'))
                {
                    Program.board.Switch('2');
                }
                if (a.KeyChar.Equals('e'))
                {
                    Program.board.Switch('3');
                }
                if (a.KeyChar.Equals('r'))
                {
                    Program.board.Switch('4');
                } if (a.KeyChar.Equals('y'))
                {
                    Program.board.Switch('5');
                }


            }
    
    }
    }
}
