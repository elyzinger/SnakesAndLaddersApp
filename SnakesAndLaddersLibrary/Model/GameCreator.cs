using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakesAndLaddersLibrary
{
   public class GameCreator
    {
        private readonly int rows;
        private readonly int columns;
        private readonly int tileLength;

        Dictionary<int, int> snakes = new Dictionary<int, int>();
        Dictionary<int, int> ladders = new Dictionary<int, int>();
        List<Tile> tiles = new List<Tile>();
        List<int> snakeAndLadders = new List<int>();

        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }
       
        Random rd = new Random();
        public int Hight { get; set; }
        public int Width { get; set; }    
        public int TileSize { get; set; }
        public string Log { get; set; }
        public int  NumOfSnakes{ get; set; }
        public int NumOfLadders { get; set; }


        public GameCreator(int hight, int width, int tileSize, int numOfSnakes, int numOfLadders)
        {
            Hight = hight;
            Width = width;
            TileSize = tileSize;
            NumOfSnakes = numOfSnakes;
            NumOfLadders = numOfLadders;

            rows = Hight / TileSize;
            columns = Width / TileSize;
            tileLength = rows * columns;
           

        }

        // create the tiles location on the board
        public List<Tile> GetTiles()
        {
            GetSnakeTile();
            GetLedderTiles();
            tiles = new List<Tile>();

            Tile tile;
            int x = TileSize;
            int y = Hight;
            int direction = 1;
            List<int> goldenTiles = new List<int>();
          
            while (goldenTiles.Count < 2)
            {
               int rnd = rd.Next(2, tileLength);
                if (!snakeAndLadders.Contains(rnd))
                {
                    goldenTiles.Add(rnd);
                }
            }

            for (int i = 1; i <= tileLength; i++)
            {      
                tile = new Tile(x, y, TileSize, i,0,0,false);
                if (snakes.ContainsKey(i) || ladders.ContainsKey(i) || goldenTiles.Contains(i))
                {
                    if (goldenTiles.Contains(i))
                    {
                        tile.IsGold = true;
                    }
                    else if(snakes.ContainsKey(i))
                    {
                        tile.SnakeTo = snakes[i];
                    }
                    else
                    {
                        tile.LadderTo = ladders[i];
                    }
                }
                tiles.Add(tile);
                x += TileSize * direction;
                if (x >= Width+TileSize || (x < TileSize && i > 0))
                {
                    direction *= -1;
                    x += TileSize * direction;
                    y = y <= Hight+TileSize ? y -= TileSize : y;
                }

            }
            PlayerOne = new Player(tiles[0].X, tiles[0].Y, tiles[0].WidthAndHight / 2);
            PlayerTwo = new Player(tiles[0].X, tiles[0].Y, tiles[0].WidthAndHight / 2);
            return tiles;
        }

      
        public void MovePlayer(int turn, int Number)
        {
            Player otherPlayer = turn == 1 ? PlayerTwo : PlayerOne;
            Player player = turn == 1 ? PlayerOne : PlayerTwo;
            int nextTile = player.Position + Number;
           

            Log = $" Moved From tile-{player.Position+1} to tile-{nextTile + 1}";
            if (nextTile < tiles.Count - 1)
            {
                Tile t = tiles[nextTile];
                if(t.SnakeTo > 0)
                {
                    Log = $" Moved From tile-{player.Position+1}. snake on tile-{nextTile+1}, moves to tile-{t.SnakeTo} ";
                    player.Position = t.SnakeTo-1;
                    player.X = tiles[player.Position].X;
                    player.Y = tiles[player.Position].Y;
                    if (turn == 1)
                    {
                        PlayerOne = player;
                    }
                    else
                    {
                        PlayerTwo = player;
                    }
                    
                }
                else if (t.LadderTo > 0)
                {
                    Log = $" Moved From tile-{player.Position + 1}. ladder on tile-{nextTile + 1}, moves to tile-{t.LadderTo} ";
                    player.Position = t.LadderTo - 1;
                    player.X = tiles[player.Position].X;
                    player.Y = tiles[player.Position].Y;
                    if (turn == 1)
                    {
                        PlayerOne = player;
                    }
                    else
                    {
                        PlayerTwo = player;
                    }
                 
                }
                else if (t.IsGold)
                {
                    if (nextTile < otherPlayer.Position)
                    {
                        if(turn == 1)
                        {
                            Log = $"Moved From tile-{player.Position + 1} to a gold tile-{nextTile + 1} and switched";
                            PlayerOne.Position = PlayerTwo.Position;
                            PlayerOne.X = tiles[PlayerOne.Position].X;
                            PlayerOne.Y = tiles[PlayerOne.Position].Y;
                            PlayerTwo.Position = nextTile;
                            PlayerTwo.X = tiles[PlayerTwo.Position].X;
                            PlayerTwo.Y = tiles[PlayerTwo.Position].Y;
                        }
                        else 
                        {
                            Log = $"Moved From tile-{player.Position + 1} to a gold tile-{nextTile + 1} and switched";
                            PlayerTwo.Position = PlayerOne.Position;
                            PlayerTwo.X = tiles[PlayerTwo.Position].X;
                            PlayerTwo.Y = tiles[PlayerTwo.Position].X;
                            PlayerOne.Position = nextTile;
                            PlayerOne.X = tiles[PlayerOne.Position].X;
                            PlayerOne.Y = tiles[PlayerOne.Position].Y;
                        }
                    }
                    else
                    {
                        Log = $"Moved From tile-{player.Position + 1} to tile-{nextTile+1} ";
                        player.Position = nextTile;
                        player.X = tiles[player.Position].X;
                        player.Y = tiles[player.Position].Y;
                     
                 
                    }
                }
                else
                {
                        player.Position = nextTile;
                        player.X = tiles[player.Position].X;
                        player.Y = tiles[player.Position].Y;
                    
                    if (turn == 1)
                    {
                        PlayerOne = player;
                    }
                    else
                    {
                        PlayerTwo = player;
                    }

                }              
            }
            else
            {
                Log = $"Moved From tile-{player.Position + 1} to tile-{nextTile} and wins";
                player.Position = tiles.Count-1;
                player.X = tiles[player.Position].X;
                player.Y = tiles[player.Position].Y;
                player.WidthAndHight = tiles[player.Position].WidthAndHight / 2;
                if (turn == 1)
                {
                    PlayerOne = player;
                }
                else
                {
                    PlayerTwo = player;
                }

            }
          
        
         
        }

        // creating the tiles with snakes
         public void GetSnakeTile()
        {
           
            snakeAndLadders = new List<int>();
            int snakeStartPoint = (Hight / TileSize) + 1;
            
            int tileLine = Hight / TileSize;

            while (snakes.Count < NumOfSnakes)
            {
                int rnd = rd.Next(snakeStartPoint, tileLength);
                if (!snakeAndLadders.Contains(rnd))
                {
                    snakeAndLadders.Add(rnd);
                    int key = rnd;
                    
                    int SnakeEndPoint = rnd - ((rnd % (tileLine)));
                    SnakeEndPoint = SnakeEndPoint != rnd ? SnakeEndPoint : SnakeEndPoint - tileLine;

                    while (snakeAndLadders.Contains(rnd))
                    {
                        rnd = rd.Next(1, SnakeEndPoint);
                    }
                    snakeAndLadders.Add(rnd);
                    snakes.Add(key, rnd);

                }
            }        

            
        }
        //creating the ladders tiles
        public void GetLedderTiles()
        {
            
         
            int ladderStartPoint = tileLength - (Hight / TileSize);
       
            int tileLine = Hight / TileSize;

            while (ladders.Count < NumOfLadders)
            {
                int rnd = rd.Next(2, ladderStartPoint);
                if (!snakeAndLadders.Contains(rnd))
                {
                    snakeAndLadders.Add(rnd);
                    int key = rnd;
                    int ladderEndPoint =rnd + (((rnd % (tileLine)) - tileLine)*-1)+1 ;
                    
                    while (snakeAndLadders.Contains(rnd))
                    {
                        rnd = rd.Next(ladderEndPoint, tileLength - 1);      
                    }
                    snakeAndLadders.Add(rnd);
                    ladders.Add(key, rnd);
                }
            }
            
        }
        

    }
}
