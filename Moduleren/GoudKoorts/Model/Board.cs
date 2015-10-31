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
    public List<MainTrack> UsedTracks { get; set; }
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
        UsedTracks = new List<MainTrack>();
        DockPath = new LinkedList<MainTrack>();
        SavePath = new LinkedList<MainTrack>();
        SecondPath = new LinkedList<MainTrack>();
        schipChar = new Char[50];
        schipSpace = 0;
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
                   if (i == 0)
                   {
                        DockPath.AddLast(Warehouses[0]);
                   }
                   if (i == 3)
                   {
                       DockPath.AddLast(ConSwitch[0]);
                       DockPath.AddLast(Basis[0]);
                       DockPath.AddLast(DevSwitch[0]);

                   }

                   if (i == 9)
                   {
                       DockPath.AddLast(ConSwitch[2]);

                   }
                   DockPath.AddLast(new MainTrack());
                }
                if (x == 1)
                {
                   
                    if (i == 6) {
                        SecondPath.AddLast(ConSwitch[2]);
                        end = true;
                    }
                    if (i == 5)
                    {
                        SecondPath.AddLast(ConSwitch[1]);
                        SecondPath.AddLast(Basis[1]);
                        SecondPath.AddLast(DevSwitch[1]);

                    }
                    if (i == 3)
                    {
                        SecondPath.AddLast(ConSwitch[0]);
                        SecondPath.AddLast(Basis[0]);
                        SecondPath.AddLast(DevSwitch[0]);
                    }
                    if (i == 0)
                    {
                        SecondPath.AddLast(Warehouses[1]);
                    }
                    if(end == false)
                    SecondPath.AddLast(new MainTrack());
                }
                if (x == 2)
                {
                    if (i == 8) {
                        SavePath.AddLast(ConSwitch[1]);
                        SavePath.AddLast(Basis[1]);
                        SavePath.AddLast(DevSwitch[1]);
                    
                    }
                    if (i == 0)
                    {
                        SavePath.AddLast(Warehouses[2]);
                    }
                    SavePath.AddLast(new MainTrack());
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

  

        for (int x = UsedTracks.Count-1; x >= 0; x--) {

            if (UsedTracks.ElementAt(x).Move(DockPath, UsedTracks))
            {

                if (DockPath.Last.Value.Contains != null) {
                    DockPath.Last.Value.Contains = null;
                }
            }
            if (UsedTracks.ElementAt(x).Move(SecondPath, UsedTracks))
            {

            }
            if (UsedTracks.ElementAt(x).Move(SavePath, UsedTracks))
            {

            }
        }

        
    }

    public void schipSpaced()
    {

        if (schipSpace == 24)
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

            Console.Write(ship.aantal);
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
        int random = randomPath.Next(3);
        if (random == 0)
        {
            DockPath.First.Next.Value.Place(mineCart);
            UsedTracks.Add(DockPath.First.Next.Value);
        }
        else if (random == 1)
        {
            SecondPath.First.Next.Value.Place(mineCart);
            UsedTracks.Add(SecondPath.First.Next.Value);
        }
        else if (random == 2)
        {
            SavePath.First.Next.Value.Place(mineCart);
            UsedTracks.Add(SavePath.First.Next.Value);
        }
        
        
    }

    void timer_Tick(object sender, EventArgs e)
    {
        Spawn();
       
    }

}

