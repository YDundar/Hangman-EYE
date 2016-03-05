using System.Windows.Forms;

namespace WFA_Hangman_EYE
{
    public partial class Form1 : Form
    {
        string word = "Computer";

        public Form1()
        {
            InitializeComponent();

            labelWord.Text = "________";
            labelWord.Font = new System.Drawing.Font(labelWord.Font.Name, 16f);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !richTextBoxGuessedWords.Text.Contains(textBoxGuess.Text) && !richTextBoxGuessedWords.Text.Contains(textBoxGuess.Text))
            {
                richTextBoxGuessedWords.Text = richTextBoxGuessedWords.Text.Insert(richTextBoxGuessedWords.Text.Length, textBoxGuess.Text + "\n");

                foreach (char letter in textBoxGuess.Text)
                    if (!richTextBoxGuessedLetters.Text.Contains(letter.ToString()))
                        richTextBoxGuessedLetters.Text = richTextBoxGuessedLetters.Text.Insert(richTextBoxGuessedLetters.Text.Length, letter + " ");



                if (word.Contains(textBoxGuess.Text))
                {
                    int index = word.IndexOf(textBoxGuess.Text);
                    char[] buffer = labelWord.Text.ToCharArray();
                    buffer[index] = word[index];
                    labelWord.Text = new string(buffer);
                }

                textBoxGuess.Text = "";
            }
        }
    }
}
