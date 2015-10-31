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

            int counter = 0;
            Console.WriteLine();
            foreach (var track in board.DockPath)
            {
                if (counter != 5)
                {
                    if (track.GetType() == typeof(DevergingSwtich))
                    {
                        Console.Write(' ');

                    }

                    else if (track.GetType() == typeof(ConvergingSwitch))
                    {

                        Console.Write(' ');
                    }
                    else
                    {
                        Console.Write(track.ToChar());
                    }
                }
                else {
                    Console.Write(' ');
                }
                    counter = counter +1;
                }


            counter = 0;
            Console.WriteLine();
            foreach (var track in board.DockPath)
            {
                if (counter != 5)
                {
                    if (track.GetType() == typeof(DevergingSwtich))
                    {
                        Console.Write(track.ToChar());

                    }

                    else if (track.GetType() == typeof(ConvergingSwitch))
                    {
                        Console.Write(track.ToChar());
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                else {
                    Console.Write(track.ToChar());
                }
                counter++;

            }
            counter = 0;
            Console.WriteLine();
            foreach (var track in board.SecondPath)
            {
                if (counter != 5 && counter != 10)
                {
                    if (track.GetType() == typeof(DevergingSwtich))
                    {
                        Console.Write(' ');

                    }

                    else if (track.GetType() == typeof(ConvergingSwitch))
                    {

                        Console.Write(' ');
                    }
                    else
                    {
                        Console.Write(track.ToChar());
                    }
                }
                else
                {
                    Console.Write(' ');
                }
                counter = counter + 1;


            }
            counter = 0;
            Console.WriteLine();
            foreach (var track in board.SavePath)
            {
                if (counter != 10)
                {
                    if (track.GetType() == typeof(DevergingSwtich))
                    {
                        Console.Write(track.ToChar());

                    }

                    else if (track.GetType() == typeof(ConvergingSwitch))
                    {
                        Console.Write(track.ToChar());
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                else {
                    Console.Write(track.ToChar());

                }
                counter++;
            }
            counter = 0;
            Console.WriteLine();
            foreach (var track in board.SavePath)
            {
                if (counter != 10)
                {
                    if (track.GetType() == typeof(DevergingSwtich))
                    {
                        Console.Write(' ');

                    }

                    else if (track.GetType() == typeof(ConvergingSwitch))
                    {
                        Console.Write(' ');
                    }
                    else
                    {
                        Console.Write(track.ToChar());
                    }
                }
                else { 
                Console.Write(' ');
                }
                counter++;
            }

            Console.WriteLine();
            board.Move();
           
        }
        
    }
}
