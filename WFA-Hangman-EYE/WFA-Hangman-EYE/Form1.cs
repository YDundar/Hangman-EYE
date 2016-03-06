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

            if (e.KeyCode == Keys.Enter && !richTextBoxGuessedWords.Text.Contains(textBoxGuess.Text))
            {
                richTextBoxGuessedWords.Text = richTextBoxGuessedWords.Text.Insert(richTextBoxGuessedWords.Text.Length, textBoxGuess.Text + "\n"); //Guessed word box

                foreach (char letter in textBoxGuess.Text)  //Guessed letter box
                    if (!richTextBoxGuessedLetters.Text.Contains(letter.ToString()))
                        richTextBoxGuessedLetters.Text = richTextBoxGuessedLetters.Text.Insert(richTextBoxGuessedLetters.Text.Length, letter + " ");


                int index = 0;
                int numOfLettersFound = 0;
                foreach (char letter in word)   //Make visible the guessed letters.
                {
                    if (richTextBoxGuessedLetters.Text.Contains(letter)) //User guessed that letter.
                    {
                        char[] buffer = labelWord.Text.ToCharArray();
                        buffer[index * 2] = word[index];
                        labelWord.Text = new string(buffer);
                        numOfLettersFound++;
                    }
                    index++;
                }

                if (!word.Contains(textBoxGuess.Text))
                {
                    picIndex++;
                    pictureBox1.Image = hangImg[picIndex];
                }

                if (picIndex + 1 >= hangImg.Length || numOfLettersFound == word.Length) //Player exceeded the try limit || User found all the lettters.
                    textBoxGuess.Enabled = false;



                textBoxGuess.ResetText(); //Empty the guess text box
            }
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


            textBoxGuess.Enabled = true;
        }
    }
}
