using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CrossZero
{
    public partial class Form1 : Form
    {
        int Player = 0;
        static Random rnd = new Random();
        int zeroWins = 0;
        int crossWins = 0;
        int[,] board = new int[3, 3];
        int row;
        int column;
        int time = 5;

        public Form1() { InitializeComponent(); }

        private void Form1_Load(object sender, EventArgs e) { GameStart(); }

        private void UpdateTime()
        {
            time = 5;
            label5.Text = "Time: " + time.ToString() + " seconds left";
            timer1.Enabled = true;
        }

        private void GameStart()
        {
            for (int i = 0; i < 3; i++)
            { for (int j = 0; j < 3; j++)
                { board[i, j] = 3; }
            }
            Player = rnd.Next(0, 2);
            UpdateTime();
        }

        private void ChangePicture(PictureBox x)
        {
            int potentionalWinner = Player;
                if (Player == 0)
            {
                x.Image = Image.FromFile("zero.png");
                Player = 1;
            }
            else
            {
                x.Image = Image.FromFile("cross.png");
                Player = 0;
            }
            x.Enabled = false;
            UpdateTime();
            searchForWinner(potentionalWinner);
        }

        private void searchForWinner(int currentPlayer)
        {
            if (checkRow(currentPlayer, row) || 
                checkColumn(currentPlayer, column) || 
                checkDiagonalMain(currentPlayer) || 
                checkDiagonalReverse(currentPlayer))
            {
                if (currentPlayer == 0)
                { zeroWins++; timer1.Enabled = false; MessageBox.Show("The Winner is ZERO!!!"); }
                else { { crossWins++; timer1.Enabled = false; MessageBox.Show("The Winner is CROSS!!!"); } }
                RefreshScore();
                CleanBoxes();
                GameStart();
            }

            else if (checkDraw())
            {
                timer1.Enabled = false;
                MessageBox.Show("DRAW!!!");
                RefreshScore();
                CleanBoxes();
                GameStart();
            }
        }

        private bool checkDraw()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {  if (board[i, j] == 3)
                    { return false; }
                }
            }
            return true;
        }

            private bool checkRow(int currentPlayer, int row)
        {
            int checker = currentPlayer;
            for (int i = 0; i < board.GetLength(1); i++)
            {if (board[row, i] != checker || board[row, i] == 3)
                { return false; }
            }
            return true;     
        }

        private bool checkColumn(int currentPlayer, int column)
        {
            int checker = currentPlayer;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[i, column] != checker || board[i, column] == 3)
                { return false; }
            }
            return true;
        }

        private bool checkDiagonalMain(int currentPlayer)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[i, i] != currentPlayer || board[i, i] == 3)
                { return false; }
            }
            return true;
        }

        private bool checkDiagonalReverse(int currentPlayer)
        {
            int dimension = board.GetLength(0);
            for (int i = dimension - 1, j = 0; i >= 0 && j < dimension; i--, j++)
            {
                if (board[i, j] != currentPlayer || board[i, j] == 3)
                { return false; }
            }
            return true;
        }

        private void RefreshScore()
        {
          label1.Text = "X: " + crossWins.ToString() + " victories";
          label2.Text = "О: " + zeroWins.ToString() + " victories";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            row = 0;
            column = 0;
            board[0, 0] = Player;
            ChangePicture(pictureBox1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            row = 0;
            column = 1;
            board[0, 1] = Player;
            ChangePicture(pictureBox2);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            row = 0;
            column = 2;
            board[0, 2] = Player;
            ChangePicture(pictureBox3);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            row = 1;
            column = 0;
            board[1, 0] = Player;
            ChangePicture(pictureBox4);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            row = 1;
            column = 1;
            board[1, 1] = Player;
            ChangePicture(pictureBox5);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            row = 1;
            column = 2;
            board[1, 2] = Player;
            ChangePicture(pictureBox6);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            row = 2;
            column = 0;
            board[2, 0] = Player;
            ChangePicture(pictureBox7);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            row = 2;
            column = 1;
            board[2, 1] = Player;
            ChangePicture(pictureBox8);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            row = 2;
            column = 2;
            board[2, 2] = Player;
            ChangePicture(pictureBox9);
        }

        private void CleanBoxes()
        {
            pictureBox1.Image = Image.FromFile("blank.png");
            pictureBox1.Enabled = true;
            pictureBox2.Image = Image.FromFile("blank.png");
            pictureBox2.Enabled = true;
            pictureBox3.Image = Image.FromFile("blank.png");
            pictureBox3.Enabled = true;
            pictureBox4.Image = Image.FromFile("blank.png");
            pictureBox4.Enabled = true;
            pictureBox5.Image = Image.FromFile("blank.png");
            pictureBox5.Enabled = true;
            pictureBox6.Image = Image.FromFile("blank.png");
            pictureBox6.Enabled = true;
            pictureBox7.Image = Image.FromFile("blank.png");
            pictureBox7.Enabled = true;
            pictureBox8.Image = Image.FromFile("blank.png");
            pictureBox8.Enabled = true;
            pictureBox9.Image = Image.FromFile("blank.png");
            pictureBox9.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e) // Restart
        {
            CleanBoxes();
            GameStart();
            UpdateTime();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time--;
            label5.Text = "Time: " + time.ToString()+ " seconds left";
            if (time == 0)
            {
                timer1.Enabled = false;
                if (Player == 0)
                    {
                    MessageBox.Show("ZERO time is left");
                    Player = 1;}
                else
                    {
                    MessageBox.Show("CROSS time is left");
                    Player = 0;}
                UpdateTime();
            }
        }
    }
}

