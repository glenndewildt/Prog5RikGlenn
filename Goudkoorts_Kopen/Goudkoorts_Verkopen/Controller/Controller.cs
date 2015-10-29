using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

public class Controller
{
	//Objects
	private Board board;
	private InputView inputView;
	private OutputView outputView;
	private Timer timer;
	private BoardLoader bLoader;

	//Primitives
	private const int TIMER_DEFAULT_INTERVAL = 1000;
	private double timerInterval;
	private bool inputValid = true, game_started = false, app_started = true;
	
	public Controller() {
		//Prepare views
		inputView = new InputView();
		outputView = new OutputView();

		//Start input loop
		Start();
	}

	public void Start()
	{
		//Prepare variables
		char inputKey = ' ';
		
		while (app_started)
		{
			//Main menu input loop
			do {
				MainMenuInput(inputKey);
			} while (!inputValid);

			//Prepare game if user wants to play
			if (game_started)
			{
				//Create objects
				board = new Board();
				bLoader = new BoardLoader(board);
				timer = new Timer();

				//Initialize board
				bLoader.initializeBoard();
				
				//Set timer
				timerInterval = TIMER_DEFAULT_INTERVAL;
				timer.Interval = TIMER_DEFAULT_INTERVAL;
				timer.Elapsed += Tick;
				timer.Start();
			}

			//Game input loop
			while (game_started)
				GameInput(inputKey);
		}
	}

	private void GameInput(char inputKey)
	{
		outputView.ShowGame(board.FirstRow, board.Score, board.Ship);
		inputKey = inputView.GetGameInput();

		if (inputKey == 's')
		{
			game_started = false;
			timer.Stop();
		}
		else
		{
			int result = 0;
			if (int.TryParse(inputKey.ToString(), out result))
				if (result > 0 && result <= 5)
					board.SwitchSwitch(result);
		}
	}

	private void MainMenuInput(char inputKey)
	{
		outputView.ShowMainMenu();

		if (!inputValid)
			outputView.ShowInvalidInputError();

		inputKey = inputView.GetMainMenuInput();
		inputValid = true;

		if (inputKey == 'y')
			game_started = true;
		else if (inputKey == 'n')
			app_started = false;
		else
			inputValid = false;
	}

	//Game tick loop
	private void Tick(Object source, ElapsedEventArgs e)
	{
		int score = board.Tick();

		if (board.GameOver)
		{
			timer.Stop();
			outputView.ShowGameOver(score);
			game_started = false;
		}
		else
		{
			//Make game go faster the higher the user's score is (up to a certain speed)
			if (TIMER_DEFAULT_INTERVAL - score * 3 >= 200)
				timerInterval = TIMER_DEFAULT_INTERVAL - score * 3;
			else
				timerInterval = 200;

			timer.Interval = timerInterval;

			outputView.ShowGame(board.FirstRow, score, board.Ship);
		}

		
	}

}

