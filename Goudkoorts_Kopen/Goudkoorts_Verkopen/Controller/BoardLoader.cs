using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

	class BoardLoader
	{
		public Board board { get; set; }

		public BoardLoader(Board board)
		{
			this.board = board;
		}

		public void initializeBoard()
		{
			char[][] boardArray = new char[8][];

			boardArray[0] = "#########D##".ToCharArray();
			boardArray[1] = "           #".ToCharArray();
			boardArray[2] = "W### ##### #".ToCharArray();
			boardArray[3] = "   C#I   C##".ToCharArray();
			boardArray[4] = "W### ## ##  ".ToCharArray();
			boardArray[5] = "      C#I   ".ToCharArray();
			boardArray[6] = "W###### ####".ToCharArray();
			boardArray[7] = "LLLLLLLL####".ToCharArray();
			board.FirstRow = new LinkedList<LinkedList<BaseTrack>>();
			for (int i = 0; i < boardArray.Length; i++)
			{
				board.FirstRow.AddLast(new LinkedList<BaseTrack>());

				for (int j = 0; j < boardArray[i].Length; j++)
				{
					BaseTrack track = null;
					switch(boardArray[i][j]) {
						case '#':
							track = new BaseTrack();
							break;
						case 'D':
							track = new Dock(board);
							break;
						case ' ':
							track = new EmptyVoid();
							break;
						case 'W':
							track = new Warehouse();
							break;
						case 'C':
							track = new ConvergingSwitch();
							break;
						case 'I':
							track = new DivergingSwitch();
							break;
						case 'L':
							track = new SafeTrack();
							break;
					}

					board.FirstRow.Last.Value.AddLast(track);
				}
			}

			connectTracks(getAtPosition(2,0), getAtPosition(2,1));
			connectTracks(getAtPosition(2,1), getAtPosition(2,2));
			connectTracks(getAtPosition(2,2), getAtPosition(2,3));
			connectTracks(getAtPosition(3,3), getAtPosition(3,4));
			connectTracks(getAtPosition(3,4), getAtPosition(3,5));
			connectTracks(getAtPosition(3,5), getAtPosition(2,5));
			connectTracks(getAtPosition(2,5), getAtPosition(2,6));
			connectTracks(getAtPosition(2,6), getAtPosition(2,7));
			connectTracks(getAtPosition(2,7), getAtPosition(2,8));
			connectTracks(getAtPosition(2,8), getAtPosition(2,9));
			connectTracks(getAtPosition(2,9), getAtPosition(3,9));
			connectTracks(getAtPosition(3,9), getAtPosition(3,10));
			connectTracks(getAtPosition(3,10), getAtPosition(3,11));
			connectTracks(getAtPosition(3,11), getAtPosition(2,11));
			connectTracks(getAtPosition(2,11), getAtPosition(1,11));
			connectTracks(getAtPosition(1,11), getAtPosition(0,11));
			connectTracks(getAtPosition(0,11), getAtPosition(0,10));
			connectTracks(getAtPosition(0,10), getAtPosition(0,9));
			connectTracks(getAtPosition(0,9), getAtPosition(0,8));
			connectTracks(getAtPosition(0,8), getAtPosition(0,7));
			connectTracks(getAtPosition(0,7), getAtPosition(0,6));
			connectTracks(getAtPosition(0,6), getAtPosition(0,5));
			connectTracks(getAtPosition(0,5), getAtPosition(0,4));
			connectTracks(getAtPosition(0,4), getAtPosition(0,3));
			connectTracks(getAtPosition(0,3), getAtPosition(0,2));
			connectTracks(getAtPosition(0,2), getAtPosition(0,1));
			connectTracks(getAtPosition(0,1), getAtPosition(0,0));

			connectTracks(getAtPosition(4,0), getAtPosition(4,1));
			connectTracks(getAtPosition(4,1), getAtPosition(4,2));
			connectTracks(getAtPosition(4,2), getAtPosition(4,3));
			connectTracks(getAtPosition(4,3), getAtPosition(3,3));

			connectTracks(getAtPosition(4,5), getAtPosition(4,6));			
			connectTracks(getAtPosition(4,8), getAtPosition(4,9));

			connectTracks(getAtPosition(6,0), getAtPosition(6,1));
			connectTracks(getAtPosition(6,1), getAtPosition(6,2));
			connectTracks(getAtPosition(6,2), getAtPosition(6,3));
			connectTracks(getAtPosition(6,3), getAtPosition(6,4));
			connectTracks(getAtPosition(6,4), getAtPosition(6,5));
			connectTracks(getAtPosition(6,5), getAtPosition(6,6));
			connectTracks(getAtPosition(6,6), getAtPosition(5,6));

			connectTracks(getAtPosition(5,6), getAtPosition(5,7));
			connectTracks(getAtPosition(5,7), getAtPosition(5,8));
			connectTracks(getAtPosition(5,8), getAtPosition(6,8));
			
			connectTracks(getAtPosition(6,8), getAtPosition(6,9));
			connectTracks(getAtPosition(6,9), getAtPosition(6,10));
			connectTracks(getAtPosition(6,10), getAtPosition(6,11));

			connectTracks(getAtPosition(6,11), getAtPosition(7,11));
			connectTracks(getAtPosition(7,11), getAtPosition(7,10));
			connectTracks(getAtPosition(7,10), getAtPosition(7,9));
			connectTracks(getAtPosition(7,9), getAtPosition(7,8));
			connectTracks(getAtPosition(7,8), getAtPosition(7,7));
			connectTracks(getAtPosition(7,7), getAtPosition(7,6));
			connectTracks(getAtPosition(7,6), getAtPosition(7,5));
			connectTracks(getAtPosition(7,5), getAtPosition(7,4));
			connectTracks(getAtPosition(7,4), getAtPosition(7,3));
			connectTracks(getAtPosition(7,3), getAtPosition(7,2));
			connectTracks(getAtPosition(7,2), getAtPosition(7,1));
			connectTracks(getAtPosition(7,1), getAtPosition(7,0));

			//Inactives
			getAtPosition(2,3).Next = getAtPosition(3,3); //2,3 is inactive
			getAtPosition(4,6).Next = getAtPosition(5,6); //4,6 is inactive
			getAtPosition(4,9).Next = getAtPosition(3,9); //4,9 is inactive
			getAtPosition(4,8).Previous = getAtPosition(5,8); //4,8 is inactive
			getAtPosition(4,5).Previous = getAtPosition(3,5); //4,5 is inactive

			ConvergingSwitch cSwitch = (ConvergingSwitch)getAtPosition(3,3);
			cSwitch.IsUp = false;
			cSwitch.Inactive = getAtPosition(2,3);
			board.Switches[0] = cSwitch;

			cSwitch = (ConvergingSwitch)getAtPosition(3, 9);
			cSwitch.Inactive = getAtPosition(4, 9);
			board.Switches[4] = cSwitch;

			cSwitch = (ConvergingSwitch)getAtPosition(5, 6);
			cSwitch.IsUp = false;
			cSwitch.Inactive = getAtPosition(4, 6);
			board.Switches[2] = cSwitch;

			DivergingSwitch dSwitch = (DivergingSwitch)getAtPosition(3, 5);
			dSwitch.Inactive = getAtPosition(4, 5);
			board.Switches[1] = dSwitch;

			dSwitch = (DivergingSwitch)getAtPosition(5, 8);
			dSwitch.IsUp = false;
			dSwitch.Inactive = getAtPosition(4, 8);
			board.Switches[3] = dSwitch;

			board.Warehouses[0] = (Warehouse)getAtPosition(2,0);
			board.Warehouses[1] = (Warehouse)getAtPosition(4, 0);
			board.Warehouses[2] = (Warehouse)getAtPosition(6, 0);
		}

		private BaseTrack getAtPosition(int y, int x) {
			return board.FirstRow.ElementAt(y).ElementAt(x);
		}

		private void connectTracks(BaseTrack x, BaseTrack y)
		{
			x.Next = y;
			y.Previous = x;
		}
			
	}
