using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bul_pgia
{
    class Program
    {
        /// <summary>
        /// This function change strings to series
        /// </summary>
        /// <param name="colors"></param>
        /// <returns></returns>
        public static  Series ChangeToSeries(string [] colors)
        {
            Colors[] newColors = new Colors[colors.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                switch(colors[i].ToUpper())
                {
                    //
                    case "YELLOW":
                        newColors[i] = Colors.Yellow;
                        break;
                    //
                    case "RED":
                        newColors[i] = Colors.Red;
                        break;
                    //
                    case "PURPLE":
                        newColors[i] = Colors.Purple;
                        break;
                    //
                    case "ORANGE":
                        newColors[i] = Colors.Orange;
                        break;
                    //
                    case "GREEN":
                        newColors[i] = Colors.Green;
                        break;
                    //
                    case "BLUE":
                        newColors[i] = Colors.Blue;
                        break;
                }
            }

            return new Series(newColors[0],newColors[1],newColors[2],newColors[3]);
        }
        /// <summary>
        /// This function the user function if his answer is valid
        /// </summary>
        /// <param name="colors"></param>
        /// <returns></returns>
        public static bool CheckAnswer(string [] colors) 
        {
            for (int i = 0; i < colors.Length; i++)
            {
                if ((colors[i].ToLower() != "yellow") && (colors[i].ToLower() != "purple") && (colors[i].ToLower() != "orange") && (colors[i].ToLower() != "green") && (colors[i].ToLower() != "blue") && (colors[i].ToLower() != "red"))
                    return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            Game game=new Game();
            int guesses = 8;
            bool answerIsCorrect = false;
            string answer = "";
            bool hasWon = false;
            int nextWord = 0;
            string[] colors = new string[4];
            Series series;
            Console.WriteLine("Hola senior/ta are you ready to play?");
            Console.ReadLine();
            game.start();
            while(guesses>0 && !hasWon)
            {
                while (!answerIsCorrect)
                {
                    Console.WriteLine("what your series?(please write all your colors in one row)");
                    Console.WriteLine("(You have only the colors : Yellow, Orange, Green, Blue, Purple and Red)");
                    answer = Console.ReadLine();

                    for (int i = 0; i < answer.Length; i++)
                    {
                        if (answer[i] == ',' || answer[i] == ' ')
                        {
                            nextWord++;
                            i++;
                        }


                        if (nextWord < 4)
                            colors[nextWord] += answer[i];
                        else
                            break;
                    }
                    answerIsCorrect = CheckAnswer(colors);
                    nextWord = 0;
                    for (int i = 0; i < colors.Length; i++)
                    {
                        colors[i] = "";
                    }
                }

                answerIsCorrect = false;

                series = ChangeToSeries(colors);

                game.AddGuess(series);

                game.PrintGame();

                if (game.IsHeWon())
                    hasWon = true;
                guesses--;
            }
            if (hasWon == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Congrats  you  Won !!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Try again, maybe next time");
            }

            Console.ReadLine();
                
        }
    }
}
