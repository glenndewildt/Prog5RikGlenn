using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

public class OutputView
{
	public void ShowMainMenu()
	{
		Console.ForegroundColor = ConsoleColor.White;
		Console.Clear();
		Console.WriteLine("######################");
		Console.WriteLine("WELCOME TO GOLDFEVER");
		Console.WriteLine("Use the numbers 1-5 to flip switches");
		Console.WriteLine("######################");
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	public void ShowGame(LinkedList<LinkedList<BaseTrack>> list, int score, Ship s)
	{
		Console.SetCursorPosition(0, 0);
		Console.WriteLine("Your score: " + score);
		Console.WriteLine();
		Console.BackgroundColor = ConsoleColor.Blue;

		//Ship animation logic
		Console.WriteLine("            ");
		String boatString = "";
		for (int i = 0; i < 7 + s.Distance; i++)
			boatString += " ";

		int diff = -7 - s.Distance - 1;
		if (s.Distance < -7 && diff > 0)
		{
			boatString += s.DrawShip().Substring(diff, 5 - diff);
		} else {
			if (s.Distance >= -7 && s.Distance < 0)
				boatString += " ";
			boatString += s.DrawShip();
		}

		boatString += "              ";
		Console.WriteLine(boatString.Substring(0, 12));
		//End of ship animation logic

		//Draw board
		Console.BackgroundColor = ConsoleColor.Green;
		Console.ForegroundColor = ConsoleColor.Black;
		foreach (LinkedList<BaseTrack> subList in list) {
			foreach (BaseTrack bt in subList)
			{
				Console.Write(bt.ToChar(false));
			}
			Console.WriteLine();
		}

		//Draw guide
		Console.BackgroundColor = ConsoleColor.Black;
		Console.ForegroundColor = ConsoleColor.White;
		Console.WriteLine();
		Console.WriteLine("Flip switches with 1, 2, 3, 4, and 5. Press 's' to stop.");
	}


	internal void ShowInvalidInputError()
	{
		Console.ForegroundColor = ConsoleColor.Red;
		Console.WriteLine();
		Console.WriteLine("Invalid input!");
		Console.ForegroundColor = ConsoleColor.White;
	}

	public void ShowGameOver(int score)
	{
		Console.Clear();
		Console.WriteLine("Game over! Your final score is " + score);
		Console.WriteLine("Press any key to continue...");
	}
}

