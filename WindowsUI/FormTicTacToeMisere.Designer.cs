using System.Drawing;
using System.Windows.Forms;

namespace WindowsUI
{
    partial class FormTicTacToeMisere
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
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.labelPlayer2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // player1Label
            // 
            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.Location = new System.Drawing.Point(31, 213);
            this.labelPlayer1.Name = "player1Label";
            this.labelPlayer1.Size = new System.Drawing.Size(66, 20);
            this.labelPlayer1.TabIndex = 0;
            this.labelPlayer1.Text = "Player1";
            // 
            // player2Label
            // 
            this.labelPlayer2.AutoSize = true;
            this.labelPlayer2.Location = new System.Drawing.Point(161, 213);
            this.labelPlayer2.Name = "player2Label";
            this.labelPlayer2.Size = new System.Drawing.Size(66, 20);
            this.labelPlayer2.TabIndex = 1;
            this.labelPlayer2.Text = "Player2";
            // 
            // FormTicTacToeMisere
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.labelPlayer2);
            this.Controls.Add(this.labelPlayer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormTicTacToeMisere";
            this.Text = "TicTacToeMisere";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label labelPlayer1;
        private Label labelPlayer2;
    }
}