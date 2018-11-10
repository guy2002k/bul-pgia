using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bul_pgia
{
    class Game
    {
        private Series series;
        private Series[] serieses;
        private int guess;

        public Game() {}
        public void start()
        {
            guess = 8;
            serieses = new Series[guess];
            series = new Series();
        }

        public void AddGuess(Series ser)
        {
            if (guess >= 1)
            {
                serieses[guess - 1] = new Series(ser.RetColor(0), ser.RetColor(1), ser.RetColor(2), ser.RetColor(3));
                guess--;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your don't have more place, sorry");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public int BullsFromSeries()
        {
            if (guess >= 0)
                return series.BullsGuess(serieses[guess].getSeries());
            else
                return -1;
        }

        public int PgiaFromSeries()
        {
            if (guess >= 0)
                return series.PgiaGuess(serieses[guess].getSeries());
            else
                return -1;
        }

        public void PrintGame()
        {
            if (guess >= 0)
                Console.WriteLine(serieses[guess] + "bulls --> {0}, pgia --> {1}", this.BullsFromSeries(), this.PgiaFromSeries());
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("You finished  the game!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }
        }

        public bool IsHeWon()
        {
            if (series.BullsGuess(serieses[guess].getSeries()) == 4)
                return true;
            else
                return false;
        }
    }
}
