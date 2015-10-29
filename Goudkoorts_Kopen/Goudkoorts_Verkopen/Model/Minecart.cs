using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Minecart
{
	public bool Loaded { get; set; }

	public Minecart()
	{
		Loaded = true;
	}

	public Char ToChar()
	{
		if (!Loaded)
			return 'O';
		return '0';
	}

}

