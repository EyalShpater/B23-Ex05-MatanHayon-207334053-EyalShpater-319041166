using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TicTacToe;

namespace WindowsUI
{
    public partial class FormTicTacToeMisere : Form
    {
        Game m_Game;
        const int k_ButtonSpacing = 10;
        const int k_ButtonSize = 50;
        const string k_Player1Sign = "X";
        const string k_Player2Sign = "O";
        private Button[,] m_Buttons;

        public FormTicTacToeMisere(Game i_Game)
        {
            m_Game = i_Game;
            InitializeComponent();
            initiateFormByChosenBoardSize();
        }

        private void initiateFormByChosenBoardSize() 
        {
            updatePlayersNameLabel();
            buildButtonMatrix(m_Game.BoardSize);
            this.ResumeLayout(false);
        }

        private void setWindowSize(Label i_LabelPlayer1, Label i_LabelPlayer2)
        {
            int windowWidth = m_Game.BoardSize * k_ButtonSize + 2 * k_ButtonSpacing;
            int windowHeight = windowWidth + 2 * k_ButtonSpacing;
            int labelsWidth = i_LabelPlayer1.Width + i_LabelPlayer2.Width;

            if (labelsWidth > windowWidth)
            {
                windowWidth = labelsWidth + 2 * k_ButtonSpacing;
            }

            this.ClientSize = new System.Drawing.Size(windowWidth, windowHeight);
        }

        private void buildButtonMatrix(int i_Size)
        {
            m_Buttons = new Button[i_Size, i_Size];
            for (int i = 0; i < i_Size; i++)
            {
                for (int j = 0; j < i_Size; j++)
                {
                    Button button = createButtonForMatrix(i, j);
                    m_Buttons[i, j] = button;
                    this.Controls.Add(button);
                }
            }
        }

        private Button createButtonForMatrix(int i_X, int i_Y)
        {
            Button button = new Button();

            button.Location = new Point(k_ButtonSize * i_X + k_ButtonSpacing, k_ButtonSize * i_Y + k_ButtonSpacing);
            button.Name = string.Format("{0} {1}", i_X, i_Y);
            button.Size = new Size(k_ButtonSize, k_ButtonSize);
            button.Text = string.Empty;
            button.UseVisualStyleBackColor = true;
            button.Visible = true;
            button.TabStop = false;
            button.Click += buttonMatrix_Click;

            return button;
        }

        private void buttonMatrix_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string[] coordinates = clickedButton.Name.Split(' ');
            int x = int.Parse(coordinates[0]);
            int y = int.Parse(coordinates[1]);

            clickedButton.Enabled = false;
            clickedButton.Text = m_Game.CurrentPlayerTurn.Id == Player.ePlayerId.Player1 ? k_Player1Sign : k_Player2Sign;
            m_Game.MarkSquare(x, y);
            handleGameOver();
            if (m_Game.IsComputerTurn())
            {
                playComputerTurn();
            }

            updateLabelsBoldByTurn();
        }

        private void playComputerTurn()
        {
            m_Game.PlayAsComputer(out int computerX, out int computerY);
            Button computerButton = m_Buttons[computerX, computerY];

            computerButton.Enabled = false;
            computerButton.Text = k_Player2Sign;

            if (m_Game.IsGameOver())
            {
                gameOverSequence();
            }
        }

        private void handleGameOver()
        {
            if (m_Game.IsGameOver())
            {
                gameOverSequence();
            }
        }

        private void gameOverSequence()
        {
            Player winner;
            string message;

            labelPlayer1.Text = $"{m_Game.Player1Name}:{m_Game.Player1Score}";
            labelPlayer2.Text = $"{m_Game.Player2Name}:{m_Game.Player2Score}";
            if (m_Game.IsDraw())
            {
                message = "It's a draw!";
            }
            else
            {
                string winnerName; 

                winner = m_Game.Winner;
                winnerName = winner.Id == Player.ePlayerId.Player1 ? m_Game.Player1Name : m_Game.Player2Name;
                message = $"The winner is {winnerName}!";
            }

            DialogResult result = MessageBox.Show(message + @"
Do you want to restart the game?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                restartGame();
            }
            else
            {
                this.Close();
            }
        }

        private void restartGame()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    button.Enabled = true;
                    button.Text = string.Empty;
                }
            }

            m_Game.InitGame();
            updateLabelsBoldByTurn();
        }

        private void updatePlayersNameLabel()
        {
            int labelPlayer1Top, labelPlayer1Left;
            int labelPlayer2Top, labelPlayer2Left;

            labelPlayer1.Text = string.Format("{0}: {1}", m_Game.Player1Name, m_Game.Player1Score);
            labelPlayer2.Text = string.Format("{0}: {1}", m_Game.Player2Name, m_Game.Player2Score);
            setWindowSize(labelPlayer1, labelPlayer2);
            labelPlayer1Top = m_Game.BoardSize * k_ButtonSize + (this.ClientSize.Height - m_Game.BoardSize * k_ButtonSize) / 2;
            labelPlayer1Left = (this.ClientSize.Width - labelPlayer1.Size.Width - labelPlayer2.Size.Width - k_ButtonSpacing) / 2; 
            labelPlayer1.Location = new Point(labelPlayer1Left, labelPlayer1Top);
            labelPlayer2Top = labelPlayer1Top;
            labelPlayer2Left = labelPlayer1Left + labelPlayer1.Size.Width + k_ButtonSpacing;
            labelPlayer2.Location = new Point(labelPlayer2Left, labelPlayer2Top);
            updateLabelsBoldByTurn();
        }

        private void updateLabelsBoldByTurn()
        {
            labelPlayer1.Font = new Font(labelPlayer1.Font, FontStyle.Regular);
            labelPlayer2.Font = new Font(labelPlayer2.Font, FontStyle.Regular);
            if (m_Game.CurrentPlayerTurn.Id == Player.ePlayerId.Player1)
            {
                labelPlayer1.Font = new Font(labelPlayer1.Font, FontStyle.Bold);
                labelPlayer2.Font = new Font(labelPlayer2.Font, FontStyle.Regular);
            }
            else
            {
                labelPlayer2.Font = new Font(labelPlayer2.Font, FontStyle.Bold);
                labelPlayer1.Font = new Font(labelPlayer1.Font, FontStyle.Regular);
            }
        }
    }
}
