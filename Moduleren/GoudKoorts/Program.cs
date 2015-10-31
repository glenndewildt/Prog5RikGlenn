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
            Console.WriteLine();
            Console.WriteLine(board.Score);
            Console.WriteLine();
            for (int i = 0; i < 35; i++)
            {
                Console.Write(board.schipChar[i]);
            }
            Console.WriteLine();
            foreach (var track in board.DockPath)
            {
                Console.Write(track.ToChar());
            }
            Console.WriteLine();
            foreach (var track in board.SecondPath)
            {
                Console.Write(track.ToChar());
            }
            Console.WriteLine();
            foreach (var track in board.SavePath)
            {
                Console.Write(track.ToChar());
            }
            Console.WriteLine();
            board.Move();
           
        }
        
    }
}
