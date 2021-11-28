using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakesAndLaddersLibrary
{
    public class Player
    {

        public int X { get; set; }
        public int Y { get; set; }
        public int WidthAndHight { get; set; }
        public int Position { get; set; }

        public Player(int x, int y, int widthAndHight)
        {
            X = x;
            Y = y;
            WidthAndHight = widthAndHight;
            Position = 0;
        }
    }
}
