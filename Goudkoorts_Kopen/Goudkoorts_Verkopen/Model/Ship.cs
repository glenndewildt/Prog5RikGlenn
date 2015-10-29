using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Ship
{
	public bool IsDocked = true;
	public int Distance { get; set; }
	public int Cargo { get;	set; }

	public void Depart()
	{
		IsDocked = false;
	}

	public void Sail()
	{
		Distance++;

		if (Distance == 6)
		{
			Cargo = 0;
			Distance = -12;
		}

		if (Distance == 0)
			IsDocked = true;
	}

	public string DrawShip()
	{
		return "<" + Cargo + "/8>";
	}
}

