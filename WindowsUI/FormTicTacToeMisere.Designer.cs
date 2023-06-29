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
            int windowHeight = windowWidth + 4 * k_ButtonSpaceing;

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(windowWidth, windowHeight);
            this.Name = "FormTicTacToeMisere";
            this.Text = "TicTacToeMisere";
            buildButtonMatrix(m_Game.BoardSize);
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

        #endregion
    }
}