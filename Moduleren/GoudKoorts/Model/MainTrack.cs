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

public class MainTrack
{
	public virtual Minecart Contains{get;set;}

    public MainTrack()
    {
       
    }

	public Boolean IsEmty()
	{
        if (Contains == null)
        {
            return true;
        }
        else {
            return false;
        }
	}

	public bool Place(Minecart cart)
	{
        if (IsEmty())
        {
            Contains = cart;
            return true;
        }

        return false;
	}
    public virtual char ToChar()
    {
        if (Contains == null)
        {
            return '#';
        }
        else
        {
            return Contains.ToChar();
        }
    }

    public bool Move(LinkedList<MainTrack> route, List<MainTrack> usedTracks)
    {

        if (Contains != null)
        {
            if (route.Find(this) == null) {
                return false;
            }
            if (route.Find(this).Next != null)
            {

                if (route.Find(this).Next.Value.IsEmty())
                {
                    route.Find(this).Next.Value.Place(this.Contains);
                    usedTracks.Add(route.Find(this).Next.Value);
                    usedTracks.Remove(route.Find(this).Value);
                    this.Contains = null;
                    return true;
                }
                return false;
            }
        }
        return false;
    }

}

