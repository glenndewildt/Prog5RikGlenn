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

public class Dock : MainTrack
{
	public virtual Board Board{get;set;}

	public virtual Ship ship{get;set;}

    public Dock() {
        ship = new Ship();
    }
    public bool ContainsShip()
    {
        if(ship != null){
            return true;
        }
        return false;
    }


    public void Losse()
    {
        if (ContainsShip() && Contains != null)
        {
            Contains.emptyMineCart();
            //ShipLading ++;
            ship.AddCart();
        }
    }

    public override char ToChar()
    {
        return 'D';
    }
}

