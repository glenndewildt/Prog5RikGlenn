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

public class ConvergingSwitch : Switch
{
	public bool IsUp = true;

	public BaseTrack Inactive
	{
		get;
		set;
	}

	public override bool Place(Minecart mc)
	{
		if (IsEmpty())
		{
			if (Previous.Content != null && Content == null)
			{
				Content = Previous.Content;
				Previous.Content = null;
				return true;
			}
		}

		return false;
	}

	public override Char ToChar(bool rawChar)
	{
		if (!rawChar)
		{
			if (Content != null)
			{
				return Content.ToChar();
			}
		}

		if (IsUp)
			return '╚';

		return '╔';
	}

	public override void SwitchSwitch()
	{
		if (Content != null)
			return;
		if (!IsUp)
			IsUp = true;
		else
			IsUp = false;

		BaseTrack tempTrack = Inactive;
		Inactive = Previous;
		Previous = tempTrack;
	}

}

