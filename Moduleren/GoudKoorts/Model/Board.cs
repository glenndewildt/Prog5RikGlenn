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
using System.Timers;

public class Board
{
    public Dock dock { get; set; }
    public virtual int Score { get; set; }
    public virtual bool GameOver { get; set; }
    public MainTrack MainTrack { get; set; }
    public Warehouse[] Warehouses { get; set; }
    public ConvergingSwitch[] ConSwitch { get; set; }
    public DevergingSwtich[] DevSwitch { get; set; }
    public MainTrack[] Basis { get; set; }
    public Ship ship { get; set; }
    public LinkedList<MainTrack> DockPath { get; set; }
    public LinkedList<MainTrack> SavePath { get; set; }
    public LinkedList<MainTrack> SecondPath { get; set; }
    public List<MainTrack> DockUsedTracks { get; set; }
    public List<MainTrack> SecondUsedTracks { get; set; }
    public List<MainTrack> SaveUsedTracks { get; set; }
    public Char[] schipChar { get; set; }
    public int schipSpace { get; set; }
    public bool schipDock { get; set; }


    public Board()
    {
        // timer

        Timer aTimer = new System.Timers.Timer();
        aTimer.Elapsed += new ElapsedEventHandler(timer_Tick);
        aTimer.Interval = 3000;
        aTimer.Enabled = true;
        //end timer
        dock = new Dock();
        DockUsedTracks = new List<MainTrack>();
        SecondUsedTracks = new List<MainTrack>();
        SaveUsedTracks = new List<MainTrack>();
        DockPath = new LinkedList<MainTrack>();
        SavePath = new LinkedList<MainTrack>();
        SecondPath = new LinkedList<MainTrack>();
        schipChar = new Char[50];
        schipSpace = 18;
        schipDock = false;
        Score = 0;

        ConSwitch = new ConvergingSwitch[5];
        for (int x = 0; x < ConSwitch.Length; x++ )
        {
            ConSwitch[x] = new ConvergingSwitch();
        }
        DevSwitch = new DevergingSwtich[5];
        for (int x = 0; x < DevSwitch.Length; x++)
        {
            DevSwitch[x] = new DevergingSwtich();
        }
        Basis  = new MainTrack[10];
        for (int x = 0; x < Basis.Length; x++)
        {
            Basis[x] = new MainTrack();
        }
        Warehouses = new Warehouse[3];
        for (int x = 0; x < Warehouses.Length; x++)
        {
            Warehouses[x] = new Warehouse();
        }
        ship = new Ship();
        MakePath();
        Spawn();
        this.schipSpaced();
        schipSpace++;
    }

    public void MakePath()
    {
        bool end = false;
        
        for (int x = 0; x <= 2; x++)
        {
            for (int i = 0; i < 25; i++)
            {
              
                if (x == 0)
                {
                    if (i == 20) {
                        DockPath.AddLast(dock);
                    }
                   else if (i == 0)
                   {
                        DockPath.AddLast(Warehouses[0]);
                   }
                   else if (i == 3)
                   {
                       ConSwitch[0].addLink(DockPath.Last);
                       DockPath.AddLast(ConSwitch[0]);
                       DockPath.AddLast(Basis[0]);
                       DockPath.AddLast(DevSwitch[0]);

                   }
                    else if (i == 9)
                    {
                        ConSwitch[2].addLink(DockPath.Last);
                        DockPath.AddLast(ConSwitch[2]);

                    }
                    else
                    {
                        DockPath.AddLast(new MainTrack());
                    }
                }
                if (x == 1)
                {
                   
                    if (i == 7) {
                        ConSwitch[2].addLink(SecondPath.Last);
                        SecondPath.AddLast(ConSwitch[2]);
                        end = true;
                    }
                    else if (i == 6)
                    {
                        ConSwitch[1].addLink(SecondPath.Last);
                        SecondPath.AddLast(ConSwitch[1]);
                        SecondPath.AddLast(Basis[1]);
                        SecondPath.AddLast(DevSwitch[1]);

                    }
                    else if (i == 3)
                    {
                        ConSwitch[0].addLink(SecondPath.Last);
                        SecondPath.AddLast(ConSwitch[0]);
                        SecondPath.AddLast(Basis[0]);
                        SecondPath.AddLast(DevSwitch[0]);
                    }
                    else if (i == 0)
                    {
                        SecondPath.AddLast(Warehouses[1]);
                    }
                    else if(end == false)
                    SecondPath.AddLast(new MainTrack());
                }
                if (x == 2)
                {
                    if (i == 8) {
                        ConSwitch[1].addLink(SavePath.Last);
                        SavePath.AddLast(ConSwitch[1]);
                        SavePath.AddLast(Basis[1]);
                        SavePath.AddLast(DevSwitch[1]);
                    
                    }
                    else if (i == 0)
                    {
                        SavePath.AddLast(Warehouses[2]);
                    }
                    else if (i < 17)
                    {
                        SavePath.AddLast(new MainTrack());
                    }
                    else
                    {
                        SavePath.AddLast(new SafeTrack());
                    }
                }
            }

        }
    }

    public virtual void Move()
    {
        if (schipDock && dock.ContainsShip() && dock.Contains != null)
        {
            dock.Losse(ship);
            Score++;
        }
        this.schipSpaced();



        for (int x = DockUsedTracks.Count - 1; x >= 0; x--)
        {

            if (DockUsedTracks.ElementAt(x).Move(DockPath, DockUsedTracks))
            {
                if (DockPath.Last.Value.Contains != null)
                {
                    DockPath.Last.Value.Contains = null;
                }
            }
            else
            {
                if (DockUsedTracks.ElementAt(x).GameOver)
                {
                    GameOver = true;
                }
            }
        }
        for (int x = SecondUsedTracks.Count-1; x >= 0; x--) {
            if (SecondUsedTracks.ElementAt(x).Move(SecondPath, SecondUsedTracks))
            {
                if (SecondPath.Last.Value.Contains != null)
                {
                    //SecondPath.Last.Value.Contains = null;
                }
            }
            else
            {
                if (SecondUsedTracks.ElementAt(x).GameOver)
                {
                    GameOver = true;
                }
            }
            
        }
        for (int x = SaveUsedTracks.Count - 1; x >= 0; x--)
        {
            if (SaveUsedTracks.ElementAt(x).Move(SavePath, SaveUsedTracks))
            {
                if (SavePath.Last.Value.Contains != null)
                {
                    //SavePath.Last.Value.Contains = null;
                }
            }
            else
            {
                if (SaveUsedTracks.ElementAt(x).GameOver)
                {
                    GameOver = true;
                }
            }
        }

        
    }

    public void schipSpaced()
    {

        if (schipSpace == 20)
        {
            schipDock = true;
        }
        if (schipSpace == 36)
        {
            ship.aantal = 0;
            schipSpace = 0;
            ship.IsEmpty = true;
            ship.IsFull = false;
        }

        if (!schipDock)
        {
            for (int i = 0; i < 35; i++)
            {
                schipChar[i] = ' ';
            }
            
            for (int j = 0; j < 5; j++)
            {
                char[] temp = ship.getChars();
                schipChar[schipSpace + j] = temp[j];
            }
            schipSpace++;
        }
        else
        {
            for (int i = 0; i < 35; i++)
            {
                schipChar[i] = ' ';
            }

            for (int j = 0; j < 5; j++)
            {
                char[] temp = ship.getChars();
                schipChar[schipSpace + j] = temp[j];
            }

            if (ship.IsFull == true)
            {
                Score = Score + 10;
                schipDock = false;
                schipSpace++;
            }
        }
    }

    public virtual void Spawn()
    {
        Minecart mineCart = new Minecart();
        Random randomPath = new Random();
        int random = 1;
        if (random == 0)
        {
            DockPath.First.Next.Value.Place(mineCart);
            DockUsedTracks.Add(DockPath.First.Next.Value);
        }
        else if (random == 1)
        {
            SecondPath.First.Next.Value.Place(mineCart);
            SecondUsedTracks.Add(SecondPath.First.Next.Value);
        }
        else if (random == 2)
        {
            SavePath.First.Next.Value.Place(mineCart);
            SaveUsedTracks.Add(SavePath.First.Next.Value);
        }
        
        
    }

    void timer_Tick(object sender, EventArgs e)
    {
        Spawn();
       
    }

}

