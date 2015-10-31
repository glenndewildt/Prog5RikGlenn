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
        static Board board = new Board();
        static void Main(string[] args)
        {

            // timer

            Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(timer_Tick);
            aTimer.Interval = 800;
            aTimer.Enabled = true;
            //end timer

            while (true) { 
            
            }




        }

        private static void timer_Tick(object sender, ElapsedEventArgs e)
        {
            Console.Clear();
            for (int i = 0; i < 35; i++)
            {
                
                Console.Write(board.schipChar[i]);
            }
            Console.WriteLine();
            foreach (var track in board.DockPath)
            {
                if (track.ToChar() == 'C')
                {
                    Console.Write(' ');
                    
                }
           
               
                else if (track.ToChar() == 'I')
                {
                    Console.Write(' ');
                    
                }
                else {
                    Console.Write(track.ToChar());
            }
                
            }
            Console.WriteLine();
            foreach (var track in board.DockPath)
            {
                if (track.ToChar() == 'C')
                {
                    Console.Write('C');

                }


                else if (track.ToChar() == 'I')
                {
                    Console.Write('I');

                }
                else
                {
                    Console.Write(' ');
                }

            }
            Console.WriteLine();
            foreach (var track in board.SecondPath)
            {
                if (track.GetType() == typeof(DevergingSwtich))
                {
                    Console.Write(' ');

                }


            

                else if (track.GetType() == typeof(ConvergingSwitch)) {
                    Console.Write(' ');
                }
                else
                {
                    Console.Write(track.ToChar());
                }
            }

            Console.WriteLine();
            foreach (var track in board.SavePath)
            {
                if (track.ToChar() == 'C')
                {
                    Console.Write('C');

                }


                else if (track.ToChar() == 'I')
                {
                    Console.Write('I');

                }
               
                else
                {
                    Console.Write(' ');
                }

            }

            Console.WriteLine();
            foreach (var track in board.SavePath)
            {
                if (track.ToChar() == 'C')
                {
                    Console.Write(' ');

                }


                else if (track.ToChar() == 'I')
                {
                    Console.Write(' ');

                }
                else
                {
                    Console.Write(track.ToChar());
                }
            }
            Console.WriteLine();
            board.Move();
           
        }
        
    }
}
