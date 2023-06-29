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
        const int k_ButtonSpaceing = 10;
        const int k_ButtonSize = 50;
        public FormTicTacToeMisere(int i_BoardSize, bool i_IsTwoPlayerGame)
        {
            m_Game = new Game(i_BoardSize, i_IsTwoPlayerGame);
            InitializeComponent();
        }
    }
}
