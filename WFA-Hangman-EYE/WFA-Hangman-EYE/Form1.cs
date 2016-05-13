using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace WFA_Hangman_EYE
{
    public partial class Form1 : Form
    {
        string word;
        Image[] hangImg = {
            WFA_Hangman_EYE.Properties.Resources.hangman_0,
            WFA_Hangman_EYE.Properties.Resources.hangman_1,
            WFA_Hangman_EYE.Properties.Resources.hangman_2 ,
            WFA_Hangman_EYE.Properties.Resources.hangman_3 ,
            WFA_Hangman_EYE.Properties.Resources.hangman_4 ,
            WFA_Hangman_EYE.Properties.Resources.hangman_5 ,
            WFA_Hangman_EYE.Properties.Resources.hangman_6 ,
            WFA_Hangman_EYE.Properties.Resources.hangman_7 ,
            WFA_Hangman_EYE.Properties.Resources.hangman_8
        };

        int picIndex = 0;

        public Form1()
        {
            InitializeComponent();

            word = WordPool.getRandomWord();

            labelWord.Text = "";

            foreach (char letter in word)
                labelWord.Text = labelWord.Text.Insert(labelWord.Text.Length, "_ ");

            labelWord.Font = new System.Drawing.Font(labelWord.Font.Name, 16f);
            textBoxGuess.MaxLength = word.Length;






            pictureBox1.Image = hangImg[picIndex];
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter && !isEnteredWord(textBoxGuess.Text)) //While the guess text box is in focus, 
            {                                                                 //if the player presses enter and didn't enter that word before.
                //Enter the new word to the guessed letters box.
                richTextBoxGuessedWords.Text = richTextBoxGuessedWords.Text.Insert(richTextBoxGuessedWords.Text.Length, textBoxGuess.Text + "\n");
                if (textBoxGuess.Text.Length == 1 && !richTextBoxGuessedLetters.Text.Contains(textBoxGuess.Text))
                    richTextBoxGuessedLetters.Text = richTextBoxGuessedLetters.Text.Insert(richTextBoxGuessedLetters.Text.Length, textBoxGuess.Text + "\n");

                int index = 0;

                if (!word.Contains(textBoxGuess.Text)) //If the word does not contain the guess word...
                {
                    picIndex++;
                    pictureBox1.Image = hangImg[picIndex];
                }
                else
                {
                    foreach (char letter in word)   //Make visible the guessed letters.
                    {
                        if (textBoxGuess.Text.Contains(letter)) //User guessed that letter.
                        {
                            char[] buffer = labelWord.Text.ToCharArray();
                            buffer[index * 2] = word[index];
                            labelWord.Text = new string(buffer);
                        }
                        index++;
                    }
                }


                if (picIndex + 1 >= hangImg.Length)//Player exceeded the try limit, lost.
                {
                    textBoxGuess.Enabled = false;
                    textBoxGuess.BackColor = Color.Red;
                    textBoxGuess.ForeColor = Color.Red;

                    string spacedWord = string.Join(" ", word.ToCharArray());
                    labelShowOnLost.Text = spacedWord;
                }
                if (!labelWord.Text.Contains('_')) //User found all the lettters, won
                {
                    textBoxGuess.Enabled = false;
                    textBoxGuess.BackColor = Color.GreenYellow;
                    textBoxGuess.ForeColor = Color.GreenYellow;
                }

                textBoxGuess.ResetText(); //Empty the guess text box
            }
        }

        private bool isEnteredWord(string _guessWord)
        {
            string[] guessedWords = richTextBoxGuessedWords.Text.Split('\n');

            foreach (string item in guessedWords)
                if (item == _guessWord)
                    return true;


            return false;
        }

        private void buttonNewGame_Click(object sender, System.EventArgs e) //Reset the controls.
        {
            richTextBoxGuessedLetters.ResetText();
            richTextBoxGuessedWords.ResetText();
            textBoxGuess.ResetText();
            word = WordPool.getRandomWord();
            textBoxGuess.MaxLength = word.Length;
            labelWord.ResetText();
            picIndex = 0;
            pictureBox1.Image = hangImg[picIndex];
            foreach (char letter in word)
                labelWord.Text = labelWord.Text.Insert(labelWord.Text.Length, "_ ");

            labelShowOnLost.Text = " ";
            textBoxGuess.Enabled = true;
            textBoxGuess.BackColor = SystemColors.Control;
            textBoxGuess.ForeColor = SystemColors.ControlText;
        }
    }
}
