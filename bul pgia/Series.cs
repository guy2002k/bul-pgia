using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bul_pgia
{
    public enum Colors
    {
        Yellow=0,
        Orange=1,
        Green=2,
        Blue=3,
        Purple=4,
        Red=5,
        black=6// only for null
    }
    class Series
    {
        private Colors[] colors;

        public Series(Colors c1,Colors c2,Colors c3,Colors c4)
        {
            colors = new Colors[4];
            colors[0] = c1;
            colors[1] = c2;
            colors[2] = c3;
            colors[3] = c4;
        }

        public Series()
        {
            colors = new Colors[4];
            Random rnd = new Random();
            for (int i = 0; i < colors.Length; i++)
            {
                int deColor = rnd.Next(0, 6);
                switch (deColor)
                {
                    case 0:
                        colors[i] = Colors.Yellow;
                        break;
                    case 1:
                        colors[i] = Colors.Orange;
                        break;
                    case 2:
                        colors[i] = Colors.Green;
                        break;
                    case 3:
                        colors[i] = Colors.Blue;
                        break;
                    case 4:
                        colors[i] = Colors.Purple;
                        break;
                    case 5:
                        colors[i] = Colors.Red;
                        break;
                }

            }

            
        }

        public int FoundColor(Colors c)
        {
            for (int i = 0; i < colors.Length; i++)
            {
                if (colors[i] == c)
                    return i;
            }
            return -1;
        }

        public Colors RetColor(int index)
        {
            return colors[index];
        }

        public int BullsGuess(Colors [] partnerColors)
        {
            int counterForBulls = 0;
            for (int i = 0; i < colors.Length; i++)
            {
                if (colors[i] == partnerColors[i])
                    counterForBulls++;
            }
            return counterForBulls;
        }

        public int PgiaGuess(Colors[] partnerColors)
        {
            int counterForPgia = 0;
            bool[] sameColorIndex = {false,false,false,false};
            for (int i = 0; i < colors.Length; i++)
            {
                for (int j = 0; j < partnerColors.Length; j++)
                {
                    if (!sameColorIndex[j])
                    {
                        if (i == j && colors[i] == partnerColors[j])
                        {
                            sameColorIndex[i] = true;
                            counterForPgia = 0;
                            break;
                        }
                        if (i != j && colors[i] == partnerColors[j])
                            counterForPgia++;
                    }

                }
            }
            if (counterForPgia > 4)
                counterForPgia = -2;
            return counterForPgia;
        }

        public Colors[] getSeries()
        {
            return colors;
        }

        public override string ToString()
        {
            string series = "";
            for (int i = 0; i < colors.Length-1; i++)
            {
                series += Convert.ToString(colors[i]) + ",";
            }
            series += Convert.ToString(colors[colors.Length - 1]) + ".";
            return string.Format("The series is {0}", series);
        }

    }
}
