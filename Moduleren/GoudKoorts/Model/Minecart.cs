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

public class Minecart
{
	public virtual bool isFull{get;set;}

    public Minecart() {
        isFull = true;
    }
	public virtual bool IsEmpty()
	{
        if (isFull)
        {
            return false;
        }
        return true;
	}

    public void emptyMineCart()
    {
        isFull = false;
    }

    public char ToChar()
    {
        if(!IsEmpty()){
            return '█';
        }
        return '_';
    }

    
}
