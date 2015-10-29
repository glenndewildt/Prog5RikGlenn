﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Board
{
	private BaseTrack OccupiedTracks
	{
		get;
		set;
	}

	private Warehouse Warehouses
	{
		get;
		set;
	}

	private Switch Switches
	{
		get;
		set;
	}

	private int TickSeconds
	{
		get;
		private set;
	}

	private int Score
	{
		get;
		set;
	}

	public virtual Ship Ship
	{
		get;
		set;
	}

	public virtual IEnumerable<Warehouse> Warehouse
	{
		get;
		set;
	}

	public virtual IEnumerable<Switch> Switch
	{
		get;
		set;
	}

	private void Move()
	{
		throw new System.NotImplementedException();
	}

	public virtual void SwitchSwitch(int switchNum)
	{
		throw new System.NotImplementedException();
	}

	public virtual void Tick()
	{
		throw new System.NotImplementedException();
	}

	private void GameOver()
	{
		throw new System.NotImplementedException();
	}

	public virtual void IncreaseScore(int score)
	{
		throw new System.NotImplementedException();
	}

}

