﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace GoudKoorts
{
    class OutputView
    {
        
        static Timer aTimer;
        public OutputView(){
            
            aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(ViewBoard);
            aTimer.Interval = 800;
            aTimer.Enabled = true;
        
        }

        private static void ViewBoard(object sender, ElapsedEventArgs e)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(Program.controller.Score);
            Console.WriteLine();

            for (int i = 0; i < 35; i++)
            {

                Console.Write(Program.controller.schipChar[i]);
            }
      


            int counter = 0;
            Console.WriteLine();
            foreach (var track in Program.controller.boardInjector.DockPath)
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
            foreach (var track in Program.controller.boardInjector.DockPath)
            {
                if (counter != 4)
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
            foreach (var track in Program.controller.boardInjector.SecondPath)
            {
                if (counter != 4 && counter != 9)
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
            foreach (var track in Program.controller.boardInjector.SavePath)
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
            foreach (var track in Program.controller.boardInjector.SavePath)
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

            Program.controller.Move();

            if (Program.controller.GameOver)
            {
                aTimer.Enabled = false;
                Console.Clear();
                Console.WriteLine("GAME OVER!");
                Console.WriteLine();
                Console.WriteLine(Program.controller.Score);
                Console.WriteLine();
                Console.WriteLine("Play Again? y/n");
                if (Console.ReadLine().Equals("y"))
                {
                    Program.controller.board = new Board();

                    aTimer.Enabled = true;
                   
                }

            }
        }
    }
}
