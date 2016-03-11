namespace WFA_Hangman_EYE
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelWord = new System.Windows.Forms.Label();
            this.buttonNewGame = new System.Windows.Forms.Button();
            this.textBoxGuess = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBoxGuessedWords = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBoxGuessedLetters = new System.Windows.Forms.RichTextBox();
            this.labelShowOnLost = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(362, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 220);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // labelWord
            // 
            this.labelWord.AutoSize = true;
            this.labelWord.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelWord.Location = new System.Drawing.Point(12, 31);
            this.labelWord.Name = "labelWord";
            this.labelWord.Size = new System.Drawing.Size(12, 16);
            this.labelWord.TabIndex = 1;
            this.labelWord.Text = "-";
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonNewGame.Location = new System.Drawing.Point(138, 291);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(131, 23);
            this.buttonNewGame.TabIndex = 2;
            this.buttonNewGame.Text = "Start a New Game";
            this.buttonNewGame.UseVisualStyleBackColor = true;
            this.buttonNewGame.Click += new System.EventHandler(this.buttonNewGame_Click);
            // 
            // textBoxGuess
            // 
            this.textBoxGuess.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxGuess.Location = new System.Drawing.Point(16, 212);
            this.textBoxGuess.Name = "textBoxGuess";
            this.textBoxGuess.Size = new System.Drawing.Size(100, 21);
            this.textBoxGuess.TabIndex = 3;
            this.textBoxGuess.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Guess:";
            // 
            // richTextBoxGuessedWords
            // 
            this.richTextBoxGuessedWords.Enabled = false;
            this.richTextBoxGuessedWords.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxGuessedWords.Location = new System.Drawing.Point(256, 28);
            this.richTextBoxGuessedWords.Name = "richTextBoxGuessedWords";
            this.richTextBoxGuessedWords.Size = new System.Drawing.Size(100, 89);
            this.richTextBoxGuessedWords.TabIndex = 5;
            this.richTextBoxGuessedWords.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(253, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Guessed words:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(250, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Guessed letters:";
            // 
            // richTextBoxGuessedLetters
            // 
            this.richTextBoxGuessedLetters.Enabled = false;
            this.richTextBoxGuessedLetters.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxGuessedLetters.Location = new System.Drawing.Point(253, 144);
            this.richTextBoxGuessedLetters.Name = "richTextBoxGuessedLetters";
            this.richTextBoxGuessedLetters.Size = new System.Drawing.Size(100, 96);
            this.richTextBoxGuessedLetters.TabIndex = 8;
            this.richTextBoxGuessedLetters.Text = "";
            // 
            // labelShowOnLost
            // 
            this.labelShowOnLost.AutoSize = true;
            this.labelShowOnLost.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelShowOnLost.Location = new System.Drawing.Point(12, 57);
            this.labelShowOnLost.Name = "labelShowOnLost";
            this.labelShowOnLost.Size = new System.Drawing.Size(16, 24);
            this.labelShowOnLost.TabIndex = 9;
            this.labelShowOnLost.Text = " ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 326);
            this.Controls.Add(this.labelShowOnLost);
            this.Controls.Add(this.richTextBoxGuessedLetters);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBoxGuessedWords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxGuess);
            this.Controls.Add(this.buttonNewGame);
            this.Controls.Add(this.labelWord);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelWord;
        private System.Windows.Forms.Button buttonNewGame;
        private System.Windows.Forms.TextBox textBoxGuess;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBoxGuessedWords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBoxGuessedLetters;
        private System.Windows.Forms.Label labelShowOnLost;
    }
}

