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
        static Timer aTimer;
        static void Main(string[] args)
        {

            // timer

            aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(timer_Tick);
            aTimer.Interval = 800;
            aTimer.Enabled = true;
            //end timer

            while (true)
            {
                var a = Console.ReadKey();

                Console.WriteLine(a.Key);
                if (a.KeyChar.Equals('q')) {
                    board.Switch('1');
                }
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
                if (counter != 4)
                {
                    if (track.GetType() == typeof(DevergingSwitch))
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
            foreach (var track in board.DockPath)
            {
                if (counter != 3)
                {
                    if (track.GetType() == typeof(DevergingSwitch))
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
                else
                {
                    Console.Write(track.ToChar());
                }
                counter++;

            }
            counter = 0;
            Console.WriteLine();
            foreach (var track in board.SecondPath)
            {
                if (counter != 5 && counter != 9)
                {
                    if (track.GetType() == typeof(DevergingSwitch))
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
                if (counter != 9)
                {
                    if (track.GetType() == typeof(DevergingSwitch))
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
                else
                {
                    Console.Write(track.ToChar());

                }
                counter++;
            }
            counter = 0;
            Console.WriteLine();
            foreach (var track in board.SavePath)
            {
                if (counter != 9)
                {
                    if (track.GetType() == typeof(DevergingSwitch))
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
                counter++;
            }

            board.Move();

            if (board.GameOver)
            {
                aTimer.Enabled = false;
                Console.Clear();
                Console.WriteLine("GAME OVER!");
                Console.WriteLine();
                Console.WriteLine(board.Score);
                Console.WriteLine();
                Console.WriteLine("Play Again? y/n");
                if (Console.ReadLine().Equals("y"))
                {
                    board = new Board();

                    aTimer.Enabled = true;
                }

            }
        }

    }
}
