using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace GoudKoorts
{
    class Controller
    {
        public virtual int Score { get; set; }
        public virtual bool GameOver { get; set; }
        public Board board {get; set;}

        public Ship ship { get; set; }

        public List<MainTrack> UsedTracks { get; set; }
        public BoardInjector boardInjector;

        public Char[] schipChar { get; set; }
        public int schipSpace { get; set; }
        public bool schipDock { get; set; }

        public Timer aTimer;


        public Controller() {
            // timer
            aTimer = new Timer();
            boardInjector = new BoardInjector();
            aTimer.Elapsed += new ElapsedEventHandler(timer_Tick);
            aTimer.Interval = 8000;
            aTimer.Enabled = true;
            //end timer
           board = new Board();
            UsedTracks = new List<MainTrack>();
            GameOver = false;

            schipChar = new Char[50];
            schipSpace = 18;
            schipDock = false;
            Score = 0;


            ship = new Ship();
            boardInjector.MakePath();
            Spawn();
            this.schipSpaced();
            schipSpace++;
        
        
        }
        public void Switch(char c)
        {
            if (c.Equals('1'))
            {
                if (boardInjector.ConSwitch[0].IsDown == true)
                {
                    boardInjector.ConSwitch[0].IsDown = false;
                }
                else
                {
                    boardInjector.ConSwitch[0].IsDown = true;
                }

            }
            if (c.Equals('2'))
            {
                if (boardInjector.ConSwitch[1].IsDown == true)
                {
                    boardInjector.ConSwitch[1].IsDown = false;
                }
                else
                {
                    boardInjector.ConSwitch[1].IsDown = true;
                }

            }
            if (c.Equals('3'))
            {
                if (boardInjector.ConSwitch[2].IsDown == true)
                {
                    boardInjector.ConSwitch[2].IsDown = false;
                }
                else
                {
                    boardInjector.ConSwitch[2].IsDown = true;
                }

            }
            if (c.Equals('4'))
            {
                if (boardInjector.DevSwitch[0].IsDown == true)
                {
                    boardInjector.DevSwitch[0].IsDown = false;
                }
                else
                {
                    boardInjector.DevSwitch[0].IsDown = true;
                }

            }

            if (c.Equals('5'))
            {
                if (boardInjector.DevSwitch[1].IsDown == true)
                {
                    boardInjector.DevSwitch[1].IsDown = false;
                }
                else
                {
                    boardInjector.DevSwitch[1].IsDown = true;
                }

            }
        }
        public virtual void Move()
        {
            if (schipDock && boardInjector.dock.ContainsShip() && boardInjector.dock.Contains != null)
            {
                boardInjector.dock.Losse(ship);
                Score++;
            }
            this.schipSpaced();



            for (int x = UsedTracks.Count - 1; x >= 0; x--)
            {


                if (boardInjector.DockPath.Find( UsedTracks.ElementAt(x)) != null)
                {
                    if (boardInjector.DockPath.Find(UsedTracks.ElementAt(x)).Next != null)
                    {
                        boardInjector.DockPath.Find(UsedTracks.ElementAt(x)).Next.Value.Move(boardInjector.DockPath, UsedTracks);
                    
                    }
                   

                    if (boardInjector.DockPath.Last.Value.Contains != null)
                    {
                        boardInjector.DockPath.Last.Value.Contains = null;

                    }


                }
                else if (boardInjector.SavePath.Find(UsedTracks.ElementAt(x)) != null)
                {
                    boardInjector.SavePath.Find(UsedTracks.ElementAt(x)).Next.Value.Move(boardInjector.SavePath, UsedTracks);


                    if (boardInjector.SavePath.Last.Value.Contains != null)
                    {
                       

                    }


                }
                else if (boardInjector.SecondPath.Find(UsedTracks.ElementAt(x)) != null)
                {
                    boardInjector.SecondPath.Find(UsedTracks.ElementAt(x)).Next.Value.Move(boardInjector.SecondPath, UsedTracks);


                    if (boardInjector.SecondPath.Last.Value.Contains != null)
                    {


                    }


                }
                else
                {
                    if (UsedTracks.ElementAt(x).GameOver)
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
            int random = 0;
            if (random == 0)
            {
                boardInjector.DockPath.First.Next.Value.Place(mineCart);
                UsedTracks.Add(boardInjector.DockPath.First.Next.Value);
            }
            else if (random == 1)
            {
                boardInjector.SecondPath.First.Next.Value.Place(mineCart);
                UsedTracks.Add(boardInjector.SecondPath.First.Next.Value);
            }
            else if (random == 2)
            {
                boardInjector.SavePath.First.Next.Value.Place(mineCart);
                UsedTracks.Add(boardInjector.SavePath.First.Next.Value);
            }


        }

        void timer_Tick(object sender, EventArgs e)
        {
            aTimer.Interval = (8000 - (Score * 1000));
            if (aTimer.Interval <= 1000)
            {
                aTimer.Interval = 1000;
            }
           
            Spawn();

        }

    }
}
