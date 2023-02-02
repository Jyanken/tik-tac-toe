using BoardLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TikTakGUI
{
    public partial class Form1 : Form
    {

        Board game = new Board();
        Button[] buttons = new Button[9];
        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            game = new Board();

            buttons[0] = button1;
            buttons[1] = button2;
            buttons[2] = button3;
            buttons[3] = button4;
            buttons[4] = button5;
            buttons[5] = button6;
            buttons[6] = button7;
            buttons[7] = button8;
            buttons[8] = button9;

            // add a common click even to each button 
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Click += handleButtonClick;
                buttons[i].Tag = i;

            }
        }

        private void handleButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button) sender;

            int gameSquareNumber = (int) clickedButton.Tag;
            
            game.Grid[gameSquareNumber] = 1;

            updateBoard();

            if (game.isBoardFull() == true)
            {
                MessageBox.Show("The board is full!");
                disableAllButtons();
            }
            else if (game.checkForWinner() == 1)
            {
                MessageBox.Show("Player human wins!");
                disableAllButtons();
            }
            else
            {
                // computer turn
                computerChoose();
            } 

            

        }

        private void disableAllButtons()
        {
            foreach (var item in buttons)
            {
                item.Enabled = false;
            }
        }

        private void computerChoose()
        {
            // computer picks a random number. update game.grid to reflect the choice.
            int computerTurn = rand.Next(9);
            // get a random move from the computer
            while (computerTurn == -1 || game.Grid[computerTurn] != 0)
            {
                computerTurn = rand.Next(9);

                Console.WriteLine("Computer chooses " + computerTurn);
            }
            game.Grid[computerTurn] = 2;
            updateBoard();

            //check for winner
            //check to see if board is full
            if (game.isBoardFull() == true)
            {
                MessageBox.Show("The board is full!");
                disableAllButtons();
            }
            else if (game.checkForWinner() == 2)
            {
                MessageBox.Show("Player computer wins!");
                disableAllButtons();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateBoard();
        }

        private void updateBoard()
        {
            // assign and x or an o to the text of each button based on the values of board
            for (int i = 0; i < game.Grid.Length; i++)
            {
                if (game.Grid[i] == 0)
                {
                    buttons[i].Text = "";
                    buttons[i].Enabled = true;
                    buttons[i].ForeColor = Color.Black;
                }
                else if (game.Grid[i] == 1)
                {
                    buttons[i].Text = "X";
                    buttons[i].Enabled = false;
                    buttons[i].ForeColor = Color.Red;
                }
                else if (game.Grid[i] == 2)
                {
                    buttons[i].Text = "O";
                    buttons[i].Enabled = false;
                    buttons[i].ForeColor = Color.Green;
                }
            }
        }

        private void newGame_Click(object sender, EventArgs e)
        {
            game = new Board();
            enableAllButtons();
        }

        private void enableAllButtons()
        {
            foreach (var item in buttons)
            {
                item.Enabled = true;
            }

            updateBoard();
        }
    }
}
