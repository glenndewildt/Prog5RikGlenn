﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Console.Write("LOADING BOARDINJECTOR");
            Console.WriteLine();
            Console.Write("DONE.");
            Console.WriteLine();

            while (true)
            {

                if (Console.ReadLine().Equals(" "))
                {
                    board.Move();

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
                }



            }




        }
    }
}
