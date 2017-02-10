/* TicTacToe.cs
 * Assignment 2
 * Revision History
 *      Almas Khan: 2016.10.04: Created
 *      Almas Khan: 2016.10.05: coded
 *      Almas Khan: 2016.10.07: Debugged
 *      
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    /// <summary>
    /// A class that shows form of tic tac toe game whose base class is Form class
    /// </summary>
    public partial class TicTacToe : Form
    {
        //Global variables declaration
        bool turn = true;// true if X's turn, false if O's turn
        int turnCount = 0;
        const int noOfBoxes = 9; // constant declaration of no of boxes in tictactoe board
        
        //Declaration of images used in the program which are saved in the resources 
        Image imageCross = global::TicTacToe.Properties.Resources.cross;
        Image imageCircle = global::TicTacToe.Properties.Resources.circle;
        Image imageBoard = global::TicTacToe.Properties.Resources.board;

        /// <summary>
        /// The default constructor of the class
        /// </summary>
        public TicTacToe()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method will check adjacent boxes if matched to declare winner, if any condition is true then
        /// winnerFound variable is set to true and will passed to other method.
        /// </summary>
        private void checkAllPosibilities()
        {
            bool winnerFound = false;
            
            //horizontal Check
            if ((pictureBoxA1.Image == pictureBoxA2.Image) && (pictureBoxA2.Image == pictureBoxA3.Image) && (!pictureBoxA1.Enabled))
            {
                winnerFound = true;
            }
            else if ((pictureBoxB1.Image == pictureBoxB2.Image) && (pictureBoxB2.Image == pictureBoxB3.Image) && (!pictureBoxB1.Enabled))
            {
                winnerFound = true;
            }
            else if ((pictureBoxC1.Image == pictureBoxC2.Image) && (pictureBoxC2.Image == pictureBoxC3.Image) && (!pictureBoxC1.Enabled))
            {
                winnerFound = true;
            }

            //Vertical Check
            if ((pictureBoxA1.Image == pictureBoxB1.Image) && (pictureBoxB1.Image == pictureBoxC1.Image) && (!pictureBoxA1.Enabled))
            {
                winnerFound = true;
            }
            else if ((pictureBoxA2.Image == pictureBoxB2.Image) && (pictureBoxB2.Image == pictureBoxC2.Image) && (!pictureBoxA2.Enabled))
            {
                winnerFound = true;
            }
            else if ((pictureBoxA3.Image == pictureBoxB3.Image) && (pictureBoxB3.Image == pictureBoxC3.Image) && (!pictureBoxA3.Enabled))
            {
                winnerFound = true;
            }

            //Diagonal check
            if ((pictureBoxA1.Image == pictureBoxB2.Image) && (pictureBoxB2.Image == pictureBoxC3.Image) && (!pictureBoxA1.Enabled))
            {
                winnerFound = true;
            }
            else if ((pictureBoxA3.Image == pictureBoxB2.Image) && (pictureBoxB2.Image == pictureBoxC1.Image) && (!pictureBoxC1.Enabled))
            {
                winnerFound = true;
            }
            //Method called to check winner and boolean value is passed in method
            checkWinner(winnerFound);
        }

        /// <summary>
        /// This method will check for winner by checking the boolean value passed by preceding
        /// method and also check value of variable turn to declare whether X is winner or O is winner
        /// </summary>
        /// <param name="winnerFound">Boolean parameter, if any of the winning posibility met then 
        /// this parameter will set to true and sent</param>
        private void checkWinner(bool winnerFound)
        {
            string winner = "";
            if (winnerFound)
            {
                if (turn)
                {
                    winner = "O";
                }
                else
                {
                    winner = "X";
                }
                MessageBox.Show(winner + " wins!");

                //Method called to start game again, after winner is showed 
                initializeNewGame();
            }
            else
            {
                if (turnCount == noOfBoxes)
                {
                    MessageBox.Show("It's a Draw!");

                    //Method called to start game again, after game is draw
                    initializeNewGame();
                }
            }
        }

        /// <summary>
        /// This method will set everything as at start of the game, so that new game can be 
        /// played
        /// </summary>
        private void initializeNewGame()
            {
                turn = true;
                turnCount = 0;
                try
                {
                    foreach (Control control in Controls)
                    {
                        PictureBox pictureBox = (PictureBox)control;
                        pictureBox.Enabled = true;
                        pictureBox.Image = null;
                        pictureBox1.Image = imageBoard;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error Occured : "+e.Message);
                }
            }

        /// <summary>
        /// This event handler will be called when any picturebox is clicked and will display image of 
        /// circle or cross depending on value of turn variable. After displaying the image
        /// picturbox will be disabled so that nobody can change image in between the game.
        /// </summary>
        /// <param name="sender">Contains a reference to the control/object that raised the event</param>
        /// <param name="e"></param>
        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            if (turn)
            {
                pictureBox.Image = imageCross;
            }
            else
            {
                pictureBox.Image = imageCircle;
            }
            turn = !turn;
            pictureBox.Enabled = false;
            turnCount++;
            checkAllPosibilities(); // Method Called 

        }
    }
}

       
    
