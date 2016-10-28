using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proces;

namespace GoldFever
{
    class Program
    {
        static void Main(string[] args)
        {
            var myController = new GameController();
            myController.runGame();

        }
    }
}
