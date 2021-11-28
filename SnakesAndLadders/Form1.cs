using SnakesAndLaddersLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SnakesAndLadders
{
   

    public partial class SnakesAndLadders : Form
    {
        // private delegate void DoPaint(object sender, PaintEventArgs e);
        int hight;
        int width;
        int btnSpace;
        int[] tileSizesOptions;
        int[] snakesOptions;
        int[] ladderOptions;
        int playerTurn;
        GameCreator gc;
        List<Tile> tiles;
        List<Tile> ladderOrSnakeTiles;
        List<Tile> goldTiles;

        Graphics graphics;
        Pen blackpPen;
        SolidBrush playerColor;
        List<Rectangle> players;
        Rectangle playerOneRec;
        Rectangle playerTwoRec;
        Random rd = new Random();
       

        public SnakesAndLadders()
        {
            InitializeComponent();          
            StartManu();
        }
        private void tileBtn_Click(object sender, EventArgs e)
        {
            try
            {
                
                logLbl.Text = "Pick amount of snakes and ladder.";
                startBtn.Enabled = true;
                snakesLbl.Visible = true;
                ladderLbl.Visible = true;
                pickLadders.Visible = true;
                pickSnakes.Visible = true;
                tileLbl.Visible = false;
                sizeTile.Visible = false;
                tileBtn.Visible = false;
                startBtn.BackColor = Color.Orange;
                switch (sizeTile.SelectedItem)
                {
                    case 25:
                        {
                            snakesOptions = new int[3] { 5, 10, 15 };
                            ladderOptions = new int[3] { 5, 10, 15 };
                            pickSnakes.DataSource = snakesOptions;
                            pickLadders.DataSource = ladderOptions;
                            break;
                        }

                    case 50:
                        {
                            snakesOptions = new int[3] { 3, 5, 8 };
                            ladderOptions = new int[3] { 3, 5, 8 };
                            pickSnakes.DataSource = snakesOptions;
                            pickLadders.DataSource = ladderOptions;
                            break;
                        }
                    case 100:
                        {
                            snakesOptions = new int[3] { 1, 2, 3 };
                            ladderOptions = new int[3] { 1, 2, 3 };
                            pickSnakes.DataSource = snakesOptions;
                            pickLadders.DataSource = ladderOptions;
                            break;
                        }
                    default: break;


                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void throwBtn_Click(object sender, EventArgs e)
        {
            try
            {

            
            int throwNum = rd.Next(1, 7);
            if (playerTurn == 1)
            {
              
                gc.MovePlayer(playerTurn, throwNum);

                players[0] = new Rectangle(gc.PlayerOne.X, gc.PlayerOne.Y, gc.PlayerOne.WidthAndHight, gc.PlayerOne.WidthAndHight);
                players[1] = new Rectangle(gc.PlayerTwo.X + gc.PlayerOne.WidthAndHight, gc.PlayerTwo.Y, gc.PlayerTwo.WidthAndHight, gc.PlayerTwo.WidthAndHight);
                logLbl.Text = $"Player one throw {throwNum}, {gc.Log}";
                
                if (gc.PlayerOne.Position == tiles.Count - 1)
                {
                    logLbl.Text = $"Player one throw {throwNum}, {gc.Log} ";
                    throwBtn.Enabled = false;
                    throwBtn.BackColor = Color.Gray;
                }

                playerTurn = 2;

            }
            else
            {

               gc.MovePlayer(playerTurn, throwNum);
                players[0] = new Rectangle(gc.PlayerOne.X, gc.PlayerOne.Y, gc.PlayerOne.WidthAndHight, gc.PlayerOne.WidthAndHight);
                players[1] = new Rectangle(gc.PlayerTwo.X+ gc.PlayerOne.WidthAndHight, gc.PlayerTwo.Y, gc.PlayerTwo.WidthAndHight, gc.PlayerTwo.WidthAndHight);   
                logLbl.Text = $"Player two throw {throwNum}, {gc.Log}";
                if (gc.PlayerTwo.Position == tiles.Count - 1)
                {
                    logLbl.Text = $"Player two throw {throwNum}, {gc.Log} ";
                    throwBtn.Enabled = false;
                    throwBtn.BackColor = Color.Gray;
                }
                playerTurn = 1;
            }

            Refresh();
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

}
        private  void  startBtn_Click(object sender, EventArgs e)
        {
            try
            {
                logLbl.Text = $"You pick tileSize:{(int)sizeTile.SelectedItem},  snakes: { (int)pickSnakes.SelectedValue}, ladders: {(int)pickLadders.SelectedValue}. good luck!";
                snakesLbl.Visible = false;
                ladderLbl.Visible = false;
                pickLadders.Visible = false;
                pickSnakes.Visible = false;
                gc = new GameCreator(hight, width, (int)sizeTile.SelectedItem, (int)pickSnakes.SelectedValue, (int)pickLadders.SelectedValue);
                BuildMap(gc);
                GetTilesWithLadderOrSnake();
                throwBtn.Enabled = true;
                throwBtn.BackColor = Color.Green;
                rstBtn.Enabled = true;
                rstBtn.BackColor = Color.Red;
                startBtn.Enabled = false;
                startBtn.BackColor = Color.Gray;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
        }
      
     
        private void rstBtn_Click(object sender, EventArgs e)
        {
            try
            {
                tiles.Clear();
                Refresh();
                logLbl.Text = "Game Started";
                StartManu();
                startBtn.Enabled = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

          
        }
        private void SnakesAndLadders_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            
            this.DoubleBuffered = true;
            if (tiles.Count != 0)
            {
                foreach (Tile t in tiles)
                {

                    SolidBrush tileBrush = t.TilePosition % 2 == 0 ? new SolidBrush(Color.Azure) : new SolidBrush(Color.Green);
                    Font f = new Font("Arial", t.WidthAndHight / 3, FontStyle.Bold | FontStyle.Italic);
                    Rectangle rect = new Rectangle(t.X, t.Y, t.WidthAndHight, t.WidthAndHight);
                        graphics.FillRectangle(tileBrush, rect);
                        graphics.DrawRectangle(blackpPen, rect);
                        graphics.DrawString($"{t.TilePosition}", f, blackBrush, t.X, t.Y);
                    tileBrush.Dispose();
                }
                foreach(Tile t in goldTiles)
                {
                    SolidBrush goldBrush = new SolidBrush(Color.Gold);
                    Rectangle rect = new Rectangle(t.X, t.Y, t.WidthAndHight, t.WidthAndHight);
                    Font f = new Font("Arial", t.WidthAndHight / 3, FontStyle.Bold | FontStyle.Italic);
                    graphics.FillRectangle(goldBrush, rect);
                    graphics.DrawRectangle(blackpPen, rect);
                    graphics.DrawString($"{t.TilePosition}", f, blackBrush, t.X, t.Y);
                    goldBrush.Dispose();
                }
                foreach(Tile t in ladderOrSnakeTiles)
                {
                    
                        Pen pen;
                        if (t.SnakeTo > 0)
                        {
                            Tile tileTo = tiles[t.SnakeTo-1];
                            pen = new Pen(Color.Black, 3);
                            int x1 = (t.X + t.X + t.WidthAndHight) / 2;
                            int y1 = (t.Y + t.Y + t.WidthAndHight) / 2;
                            int x2 = (tileTo.X + tileTo.X + tileTo.WidthAndHight) / 2;
                            int y2 = (tileTo.Y + tileTo.Y + tileTo.WidthAndHight) / 2;
                            graphics.DrawLine(pen, x1, y1, x2, y2);
                       
                        }
                        else
                        {
                            Tile tileTo = tiles[t.LadderTo-1];
                            pen = new Pen(Color.Blue, 6);
                            int x1 = (t.X + t.X + t.WidthAndHight) / 2;
                            int y1 = (t.Y + t.Y + t.WidthAndHight) / 2;
                            int x2 = (tileTo.X + tileTo.X + tileTo.WidthAndHight) / 2;
                            int y2 = (tileTo.Y + tileTo.Y + tileTo.WidthAndHight) / 2;
                            graphics.DrawLine(pen, x1, y1, x2, y2);
                        }
                        pen.Dispose();

                    
                }
            
                foreach (Rectangle r in players)
                {                  
                    playerColor = players[0].X == r.X ? new SolidBrush(Color.Black) : new SolidBrush(Color.Yellow);
                    graphics.FillEllipse(playerColor, r);
                }
               
            }
            else
            {
                graphics.DrawRectangle(blackpPen, 50, 50, width, hight);
            }

        }
        private void BuildMap(GameCreator gm)
        {
            
            tiles = gm.GetTiles();
            graphics.Clear(Color.AliceBlue);
            tileLbl.Visible = false;
            sizeTile.Visible = false;
            Refresh();

            GetPlayers();
          
        }
        private void StartManu()
        {

            logLbl.Text = "Snakes And Ladders , pick tile size.";
            goldTiles = new List<Tile>();
            ladderOrSnakeTiles = new List<Tile>();
            players = new List<Rectangle>();
            tiles = new List<Tile>();
            Size = new Size(1100, 750);
            graphics = CreateGraphics();
            hight = 500;
            width = 500;
            btnSpace = 120;
            playerTurn = 1;
            tileLbl.Visible = true;
            sizeTile.Visible = true;
            tileBtn.Visible = true;
            snakesLbl.Visible = false;
            ladderLbl.Visible = false;
            pickLadders.Visible = false;
            pickSnakes.Visible = false;
            startBtn.Enabled = false;
            throwBtn.Enabled = false;
            rstBtn.Enabled = false;
            tileBtn.Enabled = true;           
            blackpPen = new Pen(Color.Black, 3);     
            throwBtn.Size = new Size(btnSpace, btnSpace / 2);
            rstBtn.Size = new Size(btnSpace, btnSpace / 2);
            startBtn.Size = new Size(btnSpace, btnSpace / 2);
            throwBtn.BackColor = Color.Gray;
            rstBtn.BackColor = Color.Gray;
            startBtn.BackColor = Color.Gray;
                     

            logLbl.Location = new Point(width + 150, hight / 3);
            throwBtn.Location = new Point(width + btnSpace, btnSpace * 4);
            rstBtn.Location = new Point(width + btnSpace * 3, btnSpace * 4);
            startBtn.Location = new Point(width + btnSpace * 2, btnSpace * 4);
            tileLbl.Location = new Point(width / 2 -25, hight / 3 );
            sizeTile.Location = new Point(width / 2, hight / 2);
            tileBtn.Location = new Point(width / 2 - 10, (hight / 2) +70 );
            snakesLbl.Location = new Point(width / 2 + 80, hight / 3);
            ladderLbl.Location = new Point(width / 2 - 120, hight / 3);
            pickSnakes.Location = new Point(width / 2 + 100, hight / 2);
            pickLadders.Location = new Point(width / 2 - 100, hight / 2 );
            tileSizesOptions = new int[3] { 50, 25, 100 };
            sizeTile.DataSource = tileSizesOptions;
            graphics.DrawRectangle(blackpPen, 50, 50, width, hight);
        }
        private void sizeTile_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar);
        }
        private void GetPlayers()
        {           
             playerOneRec = new Rectangle(gc.PlayerOne.X, gc.PlayerOne.Y, gc.PlayerOne.WidthAndHight, gc.PlayerOne.WidthAndHight);
             playerTwoRec = new Rectangle(gc.PlayerTwo.X + gc.PlayerTwo.WidthAndHight, gc.PlayerTwo.Y, gc.PlayerTwo.WidthAndHight, gc.PlayerTwo.WidthAndHight);
            players.Add(playerOneRec);
            players.Add(playerTwoRec);
            Refresh();
        }
        public void GetTilesWithLadderOrSnake()
        {
            
            foreach (Tile t in tiles)
            {
                if (t.LadderTo > 0 || t.SnakeTo > 0)
                    ladderOrSnakeTiles.Add(t);
                if (t.IsGold)
                    goldTiles.Add(t);
            }

        }
        

     
    }
}
