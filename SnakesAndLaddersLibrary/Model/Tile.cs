using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakesAndLaddersLibrary
{
    public class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int WidthAndHight { get; set; }
        public int TilePosition { get; set; }

        public int SnakeTo{ get; set; }

        public int LadderTo{ get; set; }
        public bool IsGold{ get; set; }


        public Tile(int x, int y , int widthAndHight, int tilePosition, int snakeTo,int ladderTo, bool isGold)
        {
            X = x;
            Y = y;
            WidthAndHight = widthAndHight;
            TilePosition = tilePosition;
            SnakeTo = snakeTo;
            LadderTo = ladderTo;
            IsGold = isGold;
        }
    }
}
