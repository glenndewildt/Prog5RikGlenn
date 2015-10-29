using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class InputView
{
	public char GetMainMenuInput()
	{
		Console.WriteLine();
		Console.WriteLine("Do you want to play a game (y/n)?");
		char returnChar = Console.ReadKey(true).KeyChar;
		Console.Clear();

		return returnChar;
	}

	public char GetGameInput()
	{
		return Console.ReadKey(true).KeyChar;
	}
}

