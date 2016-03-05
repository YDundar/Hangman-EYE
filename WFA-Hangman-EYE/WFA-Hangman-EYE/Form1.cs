﻿using System.Linq;
using System.Windows.Forms;

namespace WFA_Hangman_EYE
{
    public partial class Form1 : Form
    {
        string word = "Computer";

        public Form1()
        {
            InitializeComponent();

            labelWord.Text = "_ _ _ _ _ _ _ _";
            labelWord.Font = new System.Drawing.Font(labelWord.Font.Name, 16f);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !richTextBoxGuessedWords.Text.Contains(textBoxGuess.Text) && !richTextBoxGuessedWords.Text.Contains(textBoxGuess.Text))
            {
                richTextBoxGuessedWords.Text = richTextBoxGuessedWords.Text.Insert(richTextBoxGuessedWords.Text.Length, textBoxGuess.Text + "\n"); //Guessed word box

                foreach (char letter in textBoxGuess.Text)  //Guessed letter box
                    if (!richTextBoxGuessedLetters.Text.Contains(letter.ToString()))
                        richTextBoxGuessedLetters.Text = richTextBoxGuessedLetters.Text.Insert(richTextBoxGuessedLetters.Text.Length, letter + " ");

                foreach (char letter in word)   //Make visible the guessed letters.
                {
                    if (richTextBoxGuessedLetters.Text.Contains(letter))
                    {
                        int index = word.IndexOf(letter);
                        char[] buffer = labelWord.Text.ToCharArray();
                        buffer[index * 2] = word[index];
                        labelWord.Text = new string(buffer);
                    }
                }

                textBoxGuess.ResetText(); //Empty the guess text box
            }
        }

        private void buttonNewGame_Click(object sender, System.EventArgs e) //Reset the controls.
        {
            richTextBoxGuessedLetters.ResetText();
            richTextBoxGuessedWords.ResetText();
            textBoxGuess.ResetText();
            labelWord.Text = "_ _ _ _ _ _ _ _";
        }
    }
}
