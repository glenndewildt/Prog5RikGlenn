using System;
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
            while (true)
            {
                
                if (Console.ReadLine().Equals(" "))
                {

                    
                    for (int i = 0; i < 25; i++)
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
    }
}
