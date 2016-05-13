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

        int picIndex = 0; //Failure tries.

        public Form1()
        {
            InitializeComponent();              //Start widgets.

            word = WordPool.getRandomWord();    //Get a random word from the pool.

            labelWord.Text = "";                //Reset the word label.

            foreach (char letter in word)                                           //For each letter of the word,
                labelWord.Text = labelWord.Text.Insert(labelWord.Text.Length, "_ ");//Insert an underscore.

            labelWord.Font = new System.Drawing.Font(labelWord.Font.Name, 16f); //Set the font of the word label
            textBoxGuess.MaxLength = word.Length;   //Limit the input length in Guess Text Box 

            pictureBox1.Image = hangImg[picIndex];  //Set the hangman image.
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter && !isEnteredWord(textBoxGuess.Text)) //While the guess text box is in focus, 
            {                                                                 //if the player presses enter and didn't enter that word before.
                //Enter the new word to the guessed letters box.
                richTextBoxGuessedWords.Text = richTextBoxGuessedWords.Text.Insert(richTextBoxGuessedWords.Text.Length, textBoxGuess.Text + "\n");

                //If the guess word is one letter && the player hasn't guess that letter before.
                if (textBoxGuess.Text.Length == 1 && !richTextBoxGuessedLetters.Text.Contains(textBoxGuess.Text))
                    //Add the guessed letter to guessed letter box
                    richTextBoxGuessedLetters.Text = richTextBoxGuessedLetters.Text.Insert(richTextBoxGuessedLetters.Text.Length, textBoxGuess.Text + "\n");

                int index = 0;

                if (!word.Contains(textBoxGuess.Text)) //If the word does not contain the guess word...
                {
                    picIndex++;                            //Increment the failed tries int.
                    pictureBox1.Image = hangImg[picIndex]; //Change the hangman picture.
                }
                else
                {
                    foreach (char letter in word)   //Make visible the guessed letters. For each letter in guess word,
                    {                               //check if the player guessed that letter in guess text box.
                        if (textBoxGuess.Text.Contains(letter))
                        {
                            char[] buffer = labelWord.Text.ToCharArray(); //Need to cast the 
                            buffer[index * 2] = word[index];              //Check letter for letter. 
                                                                          //Need to check index*2 because every one of 2 letters is a underscore.
                            labelWord.Text = new string(buffer);
                        }
                        index++;                                          //Increment the place of the guessed letter.
                    }
                }


                if (picIndex + 1 >= hangImg.Length)//Player exceeded the try limit, lost.
                {
                    textBoxGuess.Enabled = false;       //Disable the guess letter box so player can't enter anything else.
                    textBoxGuess.BackColor = Color.Red; //Player lost, change the back color to red.
                    textBoxGuess.ForeColor = Color.Red; //Player lost, change the fore color to red.

                    string spacedWord = string.Join(" ", word.ToCharArray()); //Put spaces between every letter so the letters would line up.
                    labelShowOnLost.Text = spacedWord;                        //Show the guess word.
                }
                if (!labelWord.Text.Contains('_')) //User found all the letters, won
                {
                    textBoxGuess.Enabled = false;               //Disable the guess letter box so player can't enter anything else.
                    textBoxGuess.BackColor = Color.GreenYellow; //Player won, change the back color to green.
                    textBoxGuess.ForeColor = Color.GreenYellow; //Player won, change the fore color to green.
                }

                textBoxGuess.ResetText(); //Empty the guess text box
            }
        }

        /// <summary>
        /// Checks whether if a word has been guessed before
        /// </summary>
        /// <param name="_guessWord">Word to lookup</param>
        /// <returns>Whether if the word has been guessed or not</returns>
        private bool isEnteredWord(string _guessWord)
        {
            string[] guessedWords = richTextBoxGuessedWords.Text.Split('\n');

            foreach (string item in guessedWords)
                if (item == _guessWord)
                    return true;

            return false;
        }
        /// <summary>
        /// Resets the necessary widgets so a new game can be started.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNewGame_Click(object sender, System.EventArgs e) //Reset the controls.
        {
            richTextBoxGuessedLetters.ResetText(); //Reset Guessed Letters Text Box
            richTextBoxGuessedWords.ResetText();   //Reset Guessed Letters Text Box
            textBoxGuess.ResetText();              //Reset Guess Text Box
            word = WordPool.getRandomWord();       //Get one random word form WordPool
            textBoxGuess.MaxLength = word.Length;  //Limit the input length in Guess Text Box 
            labelWord.ResetText();                 //Reset the word label to show nothing.
            picIndex = 0;                          //Reset the number of failed tries
            pictureBox1.Image = hangImg[picIndex]; //Reset the hangman picture

            foreach (char letter in word)          //Put underscores in word label
                labelWord.Text = labelWord.Text.Insert(labelWord.Text.Length, "_ ");

            labelShowOnLost.Text = " ";            //Reset the ShowOnLost label
            textBoxGuess.Enabled = true;           //Enable the guess text box so player can guess 
            textBoxGuess.BackColor = SystemColors.Control;     //Reset the back color of the guess text box
            textBoxGuess.ForeColor = SystemColors.ControlText; //Reset the fore color of the guess text box
        }

        private void buttonHelp_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("Write letters in the Guess field and press enter to register.\nYou can guess parts of the word if you are sure.\nFor example, Word: Capitol Guess: pit\nYou can review the letters and words you've guessed on the right side.\nGood Luck!");
        }
    }
}
