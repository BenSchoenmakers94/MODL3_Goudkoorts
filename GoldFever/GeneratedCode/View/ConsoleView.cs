﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GoldFever.GeneratedCode.Model;
using Proces;

namespace View
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public class ConsoleView
	{

	    public ConsoleView()
	    {
	        Console.OutputEncoding = Encoding.Unicode;
	        Console.SetWindowSize(77,30);
	    }
		public void showGame(ViewController viewController)
		{
		    int ypos = 18;
      
		    for (var y = 0; y < 9; y++)
		    {
                Console.SetCursorPosition(20, ypos);
		        for (var x = 0; x < 12; x++)
		        {
                    Console.ForegroundColor = y == 0 ? ConsoleColor.Blue : ConsoleColor.Yellow;
                    Console.Write(viewController.getStringForIVisitable(y, x));    
		        }
                ypos++;
                Console.Write(Environment.NewLine);
		    }
		}

        public void showEndScreen(ViewController viewController)
	    {
            Console.SetCursorPosition(28, 28);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("▼▼▼▼▼ ▼▼▼▼▼▼▼▼▼ ▼▼▼▼▼");
            Console.SetCursorPosition(28, 29);
            Console.WriteLine("▲▲▲▲▲ GAME OVER ▲▲▲▲▲");
            Console.SetCursorPosition(28, 30);
            Console.WriteLine("YOUR TOTAL SCORE IS :⌠" + viewController.GameController.Game.GameScore + "⌡");
	        Console.Read();
	    }

        public void ShowTitleScreen()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  ██████╗  ██████╗ ██╗     ██████╗ ███████╗███████╗██╗   ██╗███████╗██████╗ ");
            Console.WriteLine(" ██╔════╝ ██╔═══██╗██║     ██╔══██╗██╔════╝██╔════╝██║   ██║██╔════╝██╔══██╗");
            Console.WriteLine(" ██║  ███╗██║   ██║██║     ██║  ██║█████╗  █████╗  ██║   ██║█████╗  ██████╔╝");
            Console.WriteLine(" ██║   ██║██║   ██║██║     ██║  ██║██╔══╝  ██╔══╝  ╚██╗ ██╔╝██╔══╝  ██╔══██╗");
            Console.WriteLine(" ╚██████╔╝╚██████╔╝███████╗██████╔╝██║     ███████╗ ╚████╔╝ ███████╗██║  ██║");
            Console.WriteLine("  ╚═════╝  ╚═════╝ ╚══════╝╚═════╝ ╚═╝     ╚══════╝  ╚═══╝  ╚══════╝╚═╝  ╚═╝");
            Console.WriteLine("=============================================================================");
            Console.WriteLine("  ▀ ▀ ▀ ▀ ▀ ▀ ▀ ▀ ▀ ▀ ▀ ▀ ▀ ▀ ▀ ▀ ▀ ▀ ▀ ▀ ▀ ▀ ▀ ▀ ▀ ▀ ▀ ▀ ▀ ▀ ▀ ▀ ▀ ▀ ▀ ▀ ▀  ");
            Console.WriteLine("  █ Guide the minecarts to the dock and score points!                     █ ");
            Console.WriteLine("  █ Be careful, when 2 carts collide the game is over.                    █ ");
            Console.WriteLine("  █ By pressing 1-5, you can manipulate the switches.                     █ ");
            Console.WriteLine("  █ By pressing the 'Q' key, you can instantly do a cycle                 █ ");
            Console.WriteLine("  █ The game starts slow, but the pace gradually increases.               █ ");
            Console.WriteLine("  █ Have fun and remember:  GET THAT GOLD!                                █ ");          
            Console.WriteLine("  ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ▄ ");
        }

	    public char getInput()
	    {
	        if (Console.KeyAvailable)
	        {
	            return (Console.ReadKey(true).KeyChar);
	        }
	        return '0';
	    }

	    public void ShowCountdownAndScore(string getStringForTimeAndScore)
	    {
            Console.SetCursorPosition(27, 16);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(getStringForTimeAndScore);
	    }

	    public void ShowComplete(ViewController viewController, string getStringForTimeAndScore)
	    {
            Console.Clear();
            ShowTitleScreen();
            ShowCountdownAndScore(getStringForTimeAndScore);
            showGame(viewController);
	    }
	}
}

