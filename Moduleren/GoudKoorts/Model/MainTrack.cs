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
    public virtual Minecart Contains { get; set; }

    public bool GameOver;

    public MainTrack()
    {
        GameOver = false;
    }

    public Boolean IsEmty()
    {
        if (Contains == null)
        {
            return true;
        }
        else
        {
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

    public virtual bool Botsing()
    {
        return true;
    }

    public bool Move(LinkedList<MainTrack> route, List<MainTrack> usedTracks)
    {

        if (Contains != null)
        {
            if (route.Find(this) == null)
            {
                return false;
            }

            if (route.Find(this).Next != null)
            {
                if (route.Find(this).Next.Value.GetType() == typeof(ConvergingSwitch))
                {
                    ConvergingSwitch c = (ConvergingSwitch)route.Find(this).Next.Value;

                    if (route.Find(this).Value.Equals(c.Link1.Value) && !c.IsDown)
                    {
                        if (route.Find(this).Next.Value.IsEmty())
                        {
                            route.Find(this).Next.Value.Place(this.Contains);
                            usedTracks.Add(route.Find(this).Next.Value);
                            usedTracks.Remove(route.Find(this).Value);
                            this.Contains = null;

                            return true;
                        }
                    }
                    else if (route.Find(this).Value.Equals(c.Link2.Value) && c.IsDown)
                    {
                        if (route.Find(this).Next.Value.IsEmty())
                        {
                            route.Find(this).Next.Value.Place(this.Contains);
                            usedTracks.Add(route.Find(this).Next.Value);
                            usedTracks.Remove(route.Find(this).Value);
                            this.Contains = null;
                            

                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }


                }
                if (route.Find(this).Value.GetType() == typeof(DevergingSwitch))
                {
                    DevergingSwitch d = (DevergingSwitch)route.Find(this).Value;

                    if (!d.IsDown)
                    {
                        Console.WriteLine(d.Link1.Value);
                        Console.WriteLine();

                        d.Link1.Value.Place(this.Contains);
                        route.Find(this).Value.Contains = null;
                        usedTracks.Add(d.Link1.Value);
                        usedTracks.Remove(route.Find(this).Value);
                            this.Contains = null;
                            return true;
                        
                    }
                    else if (d.IsDown)
                    {
                        Console.WriteLine(d.Link2.Value);
                        Console.WriteLine();

                        d.Link2.Value.Place(this.Contains);
                        route.Find(this).Value.Contains = null;
                        usedTracks.Add(d.Link2.Value);
                        usedTracks.Remove(route.Find(this).Value);
                            this.Contains = null;
                            return true;
                        
                    }

                    return false;
                }

                if (route.Find(this).Next.Value.IsEmty())
                {
                    route.Find(this).Next.Value.Place(this.Contains);
                    usedTracks.Add(route.Find(this).Next.Value);
                    usedTracks.Remove(route.Find(this).Value);
                    this.Contains = null;
                    return true;
                }
                else
                {
                    if (route.Find(this).Next.Value.GetType() != typeof(SafeTrack))
                    {
                        GameOver = true;
                    }
                    else
                    {
                        Console.WriteLine("NO CRASH");
                    }
                    return false;
                }

            }
        }
        return false;
    }

}

