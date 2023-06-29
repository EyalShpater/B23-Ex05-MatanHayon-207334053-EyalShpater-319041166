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
            int windowWidth = m_Game.BoardSize * k_ButtonSize + 2 * k_ButtonSpaceing;
            int windowHeight = windowWidth + 2 * k_ButtonSpaceing;

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(windowWidth, windowHeight);
            this.Name = "FormTicTacToeMisere";
            this.Text = "TicTacToeMisere";
            buildButtonMatrix(m_Game.BoardSize);
            createPlayeryNameLabel();
            this.ResumeLayout(false);


        }

        private void buildButtonMatrix(int i_Size)
        {
            for (int i = 0; i < i_Size; i++)
            {
                for(int j = 0; j < i_Size; j++) 
                {
                    this.Controls.Add(createButtonForMatrix(i, j));
                }
            }
        }

        private Button createButtonForMatrix(int i_X, int i_Y)
        {
            Button button = new Button();

            button.Location = new System.Drawing.Point(k_ButtonSize * i_X + k_ButtonSpaceing, k_ButtonSize * i_Y + k_ButtonSpaceing);
            button.Name = string.Format("{0} {1}", i_X, i_Y);
            button.Size = new System.Drawing.Size(k_ButtonSize, k_ButtonSize);
            button.Text = string.Empty;
            button.UseVisualStyleBackColor = true;
            button.Visible = true;

            return button;
        }

        private void createPlayeryNameLabel()
        {
            //   Label labelPlayer1 = new Label();
            //   Label labelPlayer2 = new Label();

            //   labelPlayer1.Text = string.Format("{0}: {1}", m_Game.Player1Name, m_Game.Player1Score);
            //   labelPlayer2.Text = string.Format("{0}: {1}", m_Game.Player2Name, m_Game.Player2Score);
            //   labelPlayer1.AutoSize = true;
            //   labelPlayer2.AutoSize = true;
            //   labelPlayer1.Location = calculatePlayer1LabelPosition(labelPlayer1, labelPlayer2);
            //  // labelPlayer2.Left = labelPlayer1.Left + labelPlayer1.Width;
            ////   labelPlayer2.Height = labelPlayer1.Height;
            //   labelPlayer2.Location = new Point(labelPlayer1.Left + labelPlayer1.Width, labelPlayer1.Height);

            //   this.Controls.Add(labelPlayer1);
            //   this.Controls.Add(labelPlayer2);

            Label labelPlayer1 = new Label();
            Label labelPlayer2 = new Label();

            labelPlayer1.Text = string.Format("{0}: {1}", m_Game.Player1Name, m_Game.Player1Score);
            labelPlayer2.Text = string.Format("{0}: {1}", m_Game.Player2Name, m_Game.Player2Score);
            labelPlayer1.AutoSize = true;
            labelPlayer2.AutoSize = true;

            // Calculate the position of labelPlayer1 in the down center
            int labelPlayer1Top = k_ButtonSize * m_Game.BoardSize + 2 * k_ButtonSpaceing; // Adjust the vertical position as needed
            int labelPlayer1Left = (this.Width - labelPlayer2.Width) / 2; // Center horizontally

            // Set the calculated position for labelPlayer1
            labelPlayer1.Location = new Point(labelPlayer1Left, labelPlayer1Top);

            // Calculate the position of labelPlayer2 based on labelPlayer1
            int labelPlayer2Top = labelPlayer1Top; // Same top position as labelPlayer1
            int labelPlayer2Left = labelPlayer1Left + labelPlayer1.Text.Length * 8; // Place it to the right of labelPlayer1

            // Set the calculated position for labelPlayer2
            labelPlayer2.Location = new Point(labelPlayer2Left, labelPlayer2Top);

            this.Controls.Add(labelPlayer1);
            this.Controls.Add(labelPlayer2);

        }

        private Point calculatePlayer1LabelPosition(Label i_Label1, Label i_Label2)
        {
            int containerWidth = this.ClientSize.Width;
            int centerY = k_ButtonSize * m_Game.BoardSize + 3 * k_ButtonSpaceing; 
            int centerX = (containerWidth - i_Label2.Width) / 2;

            return new Point(centerX, centerY);
        }

        #endregion
    }
}