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

	public virtual Boolean IsEmty()
	{
        if (Contains == null)
        {
            return true;
        }
        else {
            return false;
        }
	}

	public virtual bool Place(Minecart cart)
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
        return '#';
    }

}

