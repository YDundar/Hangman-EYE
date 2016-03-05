using System.Linq;
using System.Windows.Forms;

namespace WFA_Hangman_EYE
{
    public partial class Form1 : Form
    {
        string word;

        public Form1()
        {
            InitializeComponent();

            word = WordPool.getRandomWord();

            labelWord.Text = "";

            foreach (char letter in word)
                labelWord.Text = labelWord.Text.Insert(labelWord.Text.Length, "_ ");

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

                int index = 0;
                foreach (char letter in word)   //Make visible the guessed letters.
                {
                    if (richTextBoxGuessedLetters.Text.Contains(letter)) //User guessed that letter.
                    {
                        char[] buffer = labelWord.Text.ToCharArray();
                        buffer[index * 2] = word[index];
                        labelWord.Text = new string(buffer);
                    }
                    index++;
                }

                textBoxGuess.ResetText(); //Empty the guess text box
            }
        }

        private void buttonNewGame_Click(object sender, System.EventArgs e) //Reset the controls.
        {
            richTextBoxGuessedLetters.ResetText();
            richTextBoxGuessedWords.ResetText();
            textBoxGuess.ResetText();
            word = WordPool.getRandomWord();
            labelWord.ResetText();
            foreach (char letter in word)
                labelWord.Text = labelWord.Text.Insert(labelWord.Text.Length, "_ ");

        }
    }
}
