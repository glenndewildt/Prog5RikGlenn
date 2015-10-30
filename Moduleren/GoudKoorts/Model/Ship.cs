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

public class Ship
{
    public bool IsFull { get; set; }
    public bool IsEmpty { get; set; }
    public bool IsHalfFull { get; set; }
    public int aantal = 0;
    public char[] shipH { get; set; }
    public char[] shipE { get; set; }
    public char[] shipV { get; set; }


    public Ship() {
       
        IsFull = false;
        IsHalfFull = false;
        IsEmpty = true;
    }

   
    public void AddCart() {
        ++aantal;

        if (aantal == 1) {
            IsFull = true;
            IsEmpty = false;
            IsHalfFull= false;
        }
        if (aantal == 4)
        {
            IsHalfFull = true;
            IsFull = false;
            IsEmpty = false;
        }
        if (aantal == 0)
        {
            IsEmpty = true;
            IsFull = false;
            IsHalfFull = false;
        }
    }

    public char[] getChars() { 
     shipE = new char[5];
        shipE[0] = '<';
        shipE[1]= '(';
        shipE[2] = 'E';
        shipE[3] = ')';
        shipE[4]= '>';
     shipV = new char[5];
        shipV[0] = '<';
        shipV[1]= '(';
        shipV[2] = 'V';
        shipV[3] = ')';
        shipV[4]= '>';

     shipH = new char[5];
        shipH[0] = '<';
        shipH[1]= '(';
        shipH[2] = 'H';
        shipH[3] = ')';
        shipH[4] = '>';

        if(IsFull == true){
            return shipV;
        }
         if(IsHalfFull == true){
            return shipH;
        }
         if(IsEmpty == true){
            return shipE;
        }
         return null;
    }
}

