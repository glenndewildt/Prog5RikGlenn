using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Dock : BaseTrack
{
	public Ship Ship { get; set; }
	public Board Board { get; set; }

	public Dock(Board b) {
		Ship = b.Ship;
		Board = b;
	}

	public override bool Place(Minecart mc)
	{
		Content = mc;
		Previous.Content = null;

		if (Ship.IsDocked)
		{
			Content.Loaded = false;
			Board.Score += 1;
			Ship.Cargo += 1;

			if (Ship.Cargo == 8)
			{
				Ship.Depart();
				Board.Score += 10;
			}
		}

		return true;
	}

	public override Char ToChar(bool rawChar)
	{
		if (!rawChar && !IsEmpty())
			return Content.ToChar();

		return 'D';
	}

}

