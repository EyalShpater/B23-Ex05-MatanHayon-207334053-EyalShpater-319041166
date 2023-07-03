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
    public partial class FormGameSettings : Form
    {
        const int k_MaxNameLength = 10;

        public FormGameSettings()
        {
            InitializeComponent();
        }

        private void checkBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            if (checkBox.Checked)
            {
                textBoxPlayer2Name.Enabled = true;
                textBoxPlayer2Name.Text = string.Empty;
            }
            else
            {
                textBoxPlayer2Name.Enabled = false;
                textBoxPlayer2Name.Text = "[Computer]";
            }
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = sender as NumericUpDown;

            if (numericUpDown.Name == "numericUpDownRows")
            {
                numericUpDownCols.Value = numericUpDownRows.Value;
            }
            else
            {
                numericUpDownRows.Value = numericUpDownCols.Value;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (textBoxPlayer1Name.Text == string.Empty || textBoxPlayer2Name.Text == string.Empty)
            {
                MessageBox.Show("Names shouldn't be empty!");
            }
            else if (textBoxPlayer1Name.Text.Length > k_MaxNameLength || textBoxPlayer2Name.Text.Length > k_MaxNameLength)
            {
                MessageBox.Show($"Names max length should be {k_MaxNameLength} !");
            }
            else
            {
                FormTicTacToeMisere ticTacToeForm = new FormTicTacToeMisere(initiateGameFromForm());

                this.Visible = false;
                ticTacToeForm.ShowDialog();
                this.Close();
            }
        }


        private Game initiateGameFromForm()
        {
            Game game = new Game((int)numericUpDownCols.Value, checkBoxPlayer2.Checked);

            game.Player1Name = textBoxPlayer1Name.Text;
            game.Player2Name = checkBoxPlayer2.Checked ? textBoxPlayer2Name.Text : "Computer";

            return game;
        }
    }
}
