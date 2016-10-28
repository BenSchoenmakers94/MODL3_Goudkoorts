﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Threading;

namespace Proces
{
	using Model;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public class GameController
	{
	    private int _timer;
	    private Thread _worker;

	    public ViewController ViewController
		{
			get;
			set;
		}

		public Game Game
		{
			get;
			set;
		}

	    public GameController()
	    {
	        ViewController = new ViewController();
	        ViewController.GameController = this;
            Game = new Game();
            Game.InitGame();
            _timer = Game.BaseInterval;
            ThreadStart methodToStart = new ThreadStart(resolveUserInput);
            _worker = new Thread(methodToStart);
	        _worker.Priority = ThreadPriority.Highest;
	    }

	    private void DoCycles()
	    {
            
            int currentInterval = _timer;

            while (true)
            {
                ViewController.ShowComplete();
                Thread.Sleep(1000);
                _timer--;
                ViewController.showCountdownAndScore();
                if (_timer <= 0)
                {
                    currentInterval = Game.GetDynamicInterval;
                    _timer = currentInterval;
                    if (!Game.TryCycle())
                    {
                        ViewController.showGame();
                        return;
                    }
                }
            }
	    }

	    public void resolveUserInput()
	    {
	        while (true)
	        {
	            char a = ViewController.getInput();
                switch (a)
                {
                    case '1':
                        Game.SwitchGate(1);
                        ViewController.ShowComplete();
                        break;
                    case '2':
                        Game.SwitchGate(2);
                        ViewController.ShowComplete();
                        break;
                    case '3':
                        Game.SwitchGate(3);
                        ViewController.ShowComplete();
                        break;
                    case '4':
                        Game.SwitchGate(4);
                        ViewController.ShowComplete();
                        break;
                    case '5':
                        Game.SwitchGate(5);
                        ViewController.ShowComplete();
                        break;
                    case 'q':
                        _timer = 0;
                        ViewController.ShowComplete();
                        break;

                    default:
                        break;
                }
	        }
	    }

	    public void runGame()
	    {
	        ViewController.ShowTitleScreen();
            _worker.Start();
            DoCycles();
            _worker.Abort();
            ViewController.ShowComplete();
            ViewController.showEndScreen();	 
		}

	    public string GetTimer()
	    {
	        if (_timer < 0) _timer = 0;
	        return _timer.ToString();
	    }
	}
}

