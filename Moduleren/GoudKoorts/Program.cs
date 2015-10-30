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
            Board board= new Board();
            
            foreach(var track in board.DockPath){
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
