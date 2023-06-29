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
        public FormGameSettings()
        {
            InitializeComponent();
        }

        private void FormGameSettings_Load(object sender, EventArgs e)
        {
            
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
            if (textBoxPlayer1Name.Text != string.Empty && textBoxPlayer2Name.Text != string.Empty)
            {
                FormTicTacToeMisere ticTacToeForm = new FormTicTacToeMisere(initiateGameFromForm());

                this.Visible = false;
                ticTacToeForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Names cannot be empty!");
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
