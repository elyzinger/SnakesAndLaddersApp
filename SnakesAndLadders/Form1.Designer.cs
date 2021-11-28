
namespace SnakesAndLadders
{
    partial class SnakesAndLadders
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.throwBtn = new System.Windows.Forms.Button();
            this.rstBtn = new System.Windows.Forms.Button();
            this.logLbl = new System.Windows.Forms.Label();
            this.tileLbl = new System.Windows.Forms.Label();
            this.startBtn = new System.Windows.Forms.Button();
            this.sizeTile = new System.Windows.Forms.ComboBox();
            this.pickLadders = new System.Windows.Forms.ComboBox();
            this.pickSnakes = new System.Windows.Forms.ComboBox();
            this.ladderLbl = new System.Windows.Forms.Label();
            this.snakesLbl = new System.Windows.Forms.Label();
            this.tileBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // throwBtn
            // 
            this.throwBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.throwBtn.Location = new System.Drawing.Point(415, 370);
            this.throwBtn.Name = "throwBtn";
            this.throwBtn.Size = new System.Drawing.Size(100, 32);
            this.throwBtn.TabIndex = 0;
            this.throwBtn.Text = "Throw Dice";
            this.throwBtn.UseVisualStyleBackColor = true;
            this.throwBtn.Click += new System.EventHandler(this.throwBtn_Click);
            // 
            // rstBtn
            // 
            this.rstBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rstBtn.Location = new System.Drawing.Point(650, 370);
            this.rstBtn.Name = "rstBtn";
            this.rstBtn.Size = new System.Drawing.Size(99, 32);
            this.rstBtn.TabIndex = 2;
            this.rstBtn.Text = "Restart Game";
            this.rstBtn.UseVisualStyleBackColor = true;
            this.rstBtn.Click += new System.EventHandler(this.rstBtn_Click);
            // 
            // logLbl
            // 
            this.logLbl.AutoSize = true;
            this.logLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.logLbl.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.logLbl.Location = new System.Drawing.Point(658, 69);
            this.logLbl.MaximumSize = new System.Drawing.Size(200, 0);
            this.logLbl.MinimumSize = new System.Drawing.Size(300, 0);
            this.logLbl.Name = "logLbl";
            this.logLbl.Size = new System.Drawing.Size(300, 25);
            this.logLbl.TabIndex = 1;
            this.logLbl.Text = "Log";
            // 
            // tileLbl
            // 
            this.tileLbl.AutoSize = true;
            this.tileLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tileLbl.Location = new System.Drawing.Point(635, 138);
            this.tileLbl.Name = "tileLbl";
            this.tileLbl.Size = new System.Drawing.Size(129, 36);
            this.tileLbl.TabIndex = 4;
            this.tileLbl.Text = "Tile Size";
            // 
            // startBtn
            // 
            this.startBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startBtn.Location = new System.Drawing.Point(532, 370);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(103, 32);
            this.startBtn.TabIndex = 5;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // sizeTile
            // 
            this.sizeTile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sizeTile.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.sizeTile.FormattingEnabled = true;
            this.sizeTile.Location = new System.Drawing.Point(650, 192);
            this.sizeTile.MinimumSize = new System.Drawing.Size(80, 0);
            this.sizeTile.Name = "sizeTile";
            this.sizeTile.Size = new System.Drawing.Size(80, 39);
            this.sizeTile.TabIndex = 6;
            // 
            // pickLadders
            // 
            this.pickLadders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pickLadders.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.pickLadders.FormattingEnabled = true;
            this.pickLadders.Location = new System.Drawing.Point(404, 192);
            this.pickLadders.MinimumSize = new System.Drawing.Size(80, 0);
            this.pickLadders.Name = "pickLadders";
            this.pickLadders.Size = new System.Drawing.Size(80, 39);
            this.pickLadders.TabIndex = 7;
            // 
            // pickSnakes
            // 
            this.pickSnakes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pickSnakes.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.pickSnakes.FormattingEnabled = true;
            this.pickSnakes.Location = new System.Drawing.Point(532, 192);
            this.pickSnakes.MinimumSize = new System.Drawing.Size(80, 0);
            this.pickSnakes.Name = "pickSnakes";
            this.pickSnakes.Size = new System.Drawing.Size(80, 39);
            this.pickSnakes.TabIndex = 8;
            // 
            // ladderLbl
            // 
            this.ladderLbl.AutoSize = true;
            this.ladderLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ladderLbl.Location = new System.Drawing.Point(381, 135);
            this.ladderLbl.Name = "ladderLbl";
            this.ladderLbl.Size = new System.Drawing.Size(123, 36);
            this.ladderLbl.TabIndex = 9;
            this.ladderLbl.Text = "Ladders";
            // 
            // snakesLbl
            // 
            this.snakesLbl.AutoSize = true;
            this.snakesLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.snakesLbl.Location = new System.Drawing.Point(510, 135);
            this.snakesLbl.Name = "snakesLbl";
            this.snakesLbl.Size = new System.Drawing.Size(114, 36);
            this.snakesLbl.TabIndex = 10;
            this.snakesLbl.Text = "Snakes";
            // 
            // tileBtn
            // 
            this.tileBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tileBtn.Location = new System.Drawing.Point(566, 262);
            this.tileBtn.Name = "tileBtn";
            this.tileBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tileBtn.Size = new System.Drawing.Size(103, 32);
            this.tileBtn.TabIndex = 11;
            this.tileBtn.Text = "Pick Tile";
            this.tileBtn.UseVisualStyleBackColor = true;
            this.tileBtn.Click += new System.EventHandler(this.tileBtn_Click);
            // 
            // SnakesAndLadders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tileBtn);
            this.Controls.Add(this.snakesLbl);
            this.Controls.Add(this.ladderLbl);
            this.Controls.Add(this.pickSnakes);
            this.Controls.Add(this.pickLadders);
            this.Controls.Add(this.sizeTile);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.tileLbl);
            this.Controls.Add(this.rstBtn);
            this.Controls.Add(this.logLbl);
            this.Controls.Add(this.throwBtn);
            this.Name = "SnakesAndLadders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SnakesAndLadders";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SnakesAndLadders_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button throwBtn;
        private System.Windows.Forms.Button rstBtn;
        private System.Windows.Forms.Label logLbl;
        private System.Windows.Forms.Label tileLbl;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.ComboBox sizeTile;
        private System.Windows.Forms.ComboBox pickLadders;
        private System.Windows.Forms.ComboBox pickSnakes;
        private System.Windows.Forms.Label ladderLbl;
        private System.Windows.Forms.Label snakesLbl;
        private System.Windows.Forms.Button tileBtn;
    }
}

