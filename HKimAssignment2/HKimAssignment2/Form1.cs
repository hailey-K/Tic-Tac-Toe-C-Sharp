/***************************************************************************
 *  NAME : HYERIM KIM
 *  STUDENT NUMBER : 7518301
 *  REVISION HISTORY : OCT 4TH 2017
 *  PROJECT : ASSIGNMENT 2
 *  
 *  
 *  DOCUMENTATION COMMENT :
 *  THIS IS TIC-TAC-TOE GAME. 
 *  THE GAME ALWAYS START FROM X AND IT WILL SHOW MESSAGE IF YOU WIN OR DRAW.
 *  AFTER COMPLETING THE GAME, IT WILL START NEW GAME AUTOMATICALLY.
 ***************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HKimAssignment2
{
    public partial class Form1 : Form
    {
        //IMAGE VARIABLES 
        static readonly Image backCard = Properties.Resources.back_card;
        static readonly Image tictactoeO = Properties.Resources.tictactoeO;
        static readonly Image tictactoeX = Properties.Resources.tictactoeX;
        // VARIABLE THAT INDICATES WHOES TURN IS
        static string turn = "tictactoeX";
        PictureBox[,] imageData = new PictureBox[3, 3];
        public Form1()
        {
            InitializeComponent();
            imageData = new PictureBox[3, 3] { { pic1, pic2, pic3 }, { pic4, pic5, pic6 }, { pic7, pic8, pic9 } };
        }
        //IMAGE CLICK EVENT 
        private void pic_Click(object sender, EventArgs e)
        {
            Image current = ((PictureBox)sender).Image;
            if (backCard.Tag == current.Tag)
            {
                if (turn == "tictactoeX")
                {
                    ((PictureBox)sender).Image = Properties.Resources.tictactoeX;
                    ((PictureBox)sender).Image.Tag = turn;
                    WinnerCheck1(turn);
                    turn = "tictactoeO";
                }
                else
                {
                    ((PictureBox)sender).Image = Properties.Resources.tictactoeO;
                    ((PictureBox)sender).Image.Tag = turn;
                    WinnerCheck1(turn);
                    turn = "tictactoeX";
                }
            }
        }
        //CHECK WINNER 
        private void WinnerCheck1(string turn)
        {

            bool winnerCheck = false;
            bool blankCheck = false;
            for (int i = 0; i < imageData.GetLength(0); i++)
            {
                if (mutipleEquals(imageData[i, 0].Image, imageData[i, 1].Image, imageData[i, 2].Image))
                    winnerCheck = true;
                if (imageData[i, 0].Image.Tag == backCard.Tag || imageData[i, 1].Image.Tag == backCard.Tag || imageData[i, 2].Image.Tag == backCard.Tag
                 || imageData[i, 0].Image.Tag == null || imageData[i, 1].Image.Tag == null || imageData[i, 2].Image.Tag == null)
                {
                    blankCheck = true;
                }

            }
            for (int j = 0; j < imageData.GetLength(1); j++)
                if (mutipleEquals(imageData[0, j].Image, imageData[1, j].Image, imageData[2, j].Image))
                    winnerCheck = true;

            if (mutipleEquals(imageData[0, 0].Image, imageData[1, 1].Image, imageData[2, 2].Image) ||
                mutipleEquals(imageData[2, 0].Image, imageData[1, 1].Image, imageData[0, 2].Image))
            {
                winnerCheck = true;
            }
            if (!blankCheck && winnerCheck == false)
            {
                MessageBox.Show("Draw!");
                NewGameStart();
            }
            else if (winnerCheck)
            {
                MessageBox.Show(turn + " is Winner !");
                NewGameStart();
            }
        }
        // CHECK THREE PARAMETERS HAS THE SAME TAGS
        private bool mutipleEquals(Image firstText, Image secondText, Image thirdText)
        {
            if (firstText.Tag == secondText.Tag && firstText.Tag == thirdText.Tag && secondText.Tag == thirdText.Tag
                && firstText.Tag != backCard.Tag && secondText.Tag != backCard.Tag && thirdText.Tag != backCard.Tag
                && firstText.Tag != null && secondText.Tag != null && thirdText.Tag != null)
                return true;

            else
                return false;
        }
        //START NEW GAME (INITIALIZE MANUALLY)
        private void NewGameStart()
        {
            for (int i = 0; i < imageData.GetLength(0); i++)
            {
                imageData[i, 0].Image.Tag = null;
                imageData[i, 1].Image.Tag = null;
                imageData[i, 2].Image.Tag = null;
                imageData[i, 0].Image = backCard;
                imageData[i, 1].Image = backCard;
                imageData[i, 2].Image = backCard;
            }
            turn = "tictactoeX";
        }
    }
}
