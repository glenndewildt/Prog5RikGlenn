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

public class SafeTrack : MainTrack
{
    public override bool Move(LinkedList<MainTrack> route, List<MainTrack> usedTracks)
    {



        if (route.Find(this).Value.IsEmty().Equals(true) && route.Find(this) != null)
        {
            route.Find(this).Value.Place(route.Find(this).Previous.Value.Contains);
            route.Find(this).Previous.Value.Contains = null;
            usedTracks.Remove(route.Find(this).Previous.Value);
            usedTracks.Add(route.Find(this).Value);
            return true;
        }
     

        return false;
    }

    public override char ToChar()
    {
        if (Contains == null)
        {
            return 'S';
        }
        else
        {
            return Contains.ToChar();
        }
    }

}

