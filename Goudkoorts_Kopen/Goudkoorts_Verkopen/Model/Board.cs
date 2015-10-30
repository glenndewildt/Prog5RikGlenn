using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Board
{
	private List<BaseTrack> OccupiedTracks { get; set; }
	public Warehouse[] Warehouses { get; set; }
	public Switch[] Switches { get; set; }
	public int Score { get; set; }
	public Ship Ship { get; set; }
    public LinkedList<BaseTrack>[] Tracks { get; set; }
    
	public bool GameOver { get; set; }
	private Random RandomGenerator;

	public Board()
	{
		Switches = new Switch[5];
		Warehouses = new Warehouse[3];
		OccupiedTracks = new List<BaseTrack>();
		RandomGenerator = new Random();
		Ship = new Ship();
	}

    public void MakeTracks(Switch[] switches, Warehouse[] warenhouses) { 
    for (wa){
    
    
    }
    }
	public int Tick()
	{
		if (!Ship.IsDocked)
			Ship.Sail();
		
		Move();
		Spawn();
		
		return Score;
	}

	public void SwitchSwitch(int switchNum)
	{
		Switches[switchNum - 1].SwitchSwitch();
	}

	private void Move()
	{
		if (OccupiedTracks.Count > 0)
		{
			for (int i = 0; i < OccupiedTracks.Count(); ++i)
			{
				BaseTrack bt = OccupiedTracks[i];
				try
				{
					if (bt.Next == null)
					{
						if (bt.ToChar(true) == '#')
						{
							bt.Content = null;
						}

						OccupiedTracks.RemoveAt(i);
						--i;
					}
					else if (bt.Next.Place(bt.Content))
						OccupiedTracks[i] = bt.Next;

				}
				catch (JeMoederException)
				{
					GameOver = true;
				}
			}
		}
	}

	private void Spawn()
	{
		Double change = 2.0 + Score / 100.0;
		if (RandomGenerator.NextDouble() * 10.0 <= change)
		{
			int wareHouseNum = RandomGenerator.Next(3);
			try
			{
				Warehouses[wareHouseNum].Next.Place(new Minecart());
			}
			catch (JeMoederException)
			{
				GameOver = true;
			}
			
			OccupiedTracks.Add(Warehouses[wareHouseNum].Next);
		}
	}
}