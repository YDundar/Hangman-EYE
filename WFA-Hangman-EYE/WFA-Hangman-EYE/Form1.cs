using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NUnit.Framework; //NUnit Framework

namespace WFA_Hangman_EYE
{
    [TestFixture]
    public partial class Form1 : Form
    {
        string word;

        #region Test Cases

        [Test]
        public void testForRevealLetterHint() //Testing if the Reveal Letter Hint enables and disables correctly
        {
            Form1 dummyForm = new Form1();
            if (dummyForm.word.Length < 5)
            {
                Assert.IsTrue(!dummyForm.labelRevealLetter.Enabled);
            }
            else
            {
                Assert.IsTrue(dummyForm.labelRevealLetter.Enabled);
            }
        }

        [Test]
        public void testMaxLength() //Testing if the maxLength gets set correctly or not
        {
            Form1 dummyForm1 = new Form1();
            Assert.AreEqual(dummyForm1.textBoxGuess.MaxLength,dummyForm1.word.Length);
        }

        [Test]
        public void testForGuessedWords() //Testing if the Entered Text is added to the Guessed Letter List or not
        {
            Form1 dummyForm1=new Form1();
            KeyEventArgs e= new KeyEventArgs(Keys.Enter);
            dummyForm1.textBoxGuess.Text = "a";
            dummyForm1.textBox1_KeyDown(new object(),e);
            Assert.IsTrue(dummyForm1.richTextBoxGuessedLetters.Text.Contains(dummyForm1.textBoxGuess.Text));
            Assert.IsTrue(dummyForm1.isEnteredWord(dummyForm1.textBoxGuess.Text));
        }

        [Test]
        public void testPicIndex() //Testing if the picIndex sets correctly after correct/incorrect guess attempts
        {
            Form1 dummyForm1 =new Form1();
            KeyEventArgs e=new KeyEventArgs(Keys.Enter);
            dummyForm1.word = "abcd";
            int initialPicIndex = dummyForm1.picIndex;

            dummyForm1.textBoxGuess.Text = "a"; // A Correct attempt
            dummyForm1.textBox1_KeyDown(new object(), e);
            Assert.AreEqual(initialPicIndex,dummyForm1.picIndex);
            initialPicIndex = dummyForm1.picIndex;
            dummyForm1.textBoxGuess.Text = "e"; // A failed attempt
            dummyForm1.textBox1_KeyDown(new object(), e);
            Assert.AreEqual(initialPicIndex+1, dummyForm1.picIndex);
        }

        [Test]
        public void testForGameLost() //Testing if the game lost event is triggered correctly or not
        {
            Form1 dummyForm1 = new Form1();
            KeyEventArgs e = new KeyEventArgs(Keys.Enter);
            dummyForm1.word = "test";
            dummyForm1.textBoxGuess.MaxLength = dummyForm1.word.Length;
            dummyForm1.textBoxGuess.Text = "a";
            dummyForm1.textBox1_KeyDown(new object(), e);
            dummyForm1.textBoxGuess.Text = "b";
            dummyForm1.textBox1_KeyDown(new object(), e);
            dummyForm1.textBoxGuess.Text = "c";
            dummyForm1.textBox1_KeyDown(new object(), e);
            dummyForm1.textBoxGuess.Text = "d";
            dummyForm1.textBox1_KeyDown(new object(), e);
            dummyForm1.textBoxGuess.Text = "f";
            dummyForm1.textBox1_KeyDown(new object(), e);
            dummyForm1.textBoxGuess.Text = "g";
            dummyForm1.textBox1_KeyDown(new object(), e);
            dummyForm1.textBoxGuess.Text = "h";
            dummyForm1.textBox1_KeyDown(new object(), e);
            int tempPicIndex = dummyForm1.picIndex;
            Assert.AreEqual(Color.Red,dummyForm1.textBoxGuess.BackColor);
            Assert.AreEqual(Color.Red,dummyForm1.textBoxGuess.ForeColor);
        }

        [Test]
        public void testForGameWon() //Testing if the game won event is triggered correctly or not
        {
            Form1 dummyForm1 = new Form1();
            KeyEventArgs e = new KeyEventArgs(Keys.Enter);
            dummyForm1.textBoxGuess.Text = dummyForm1.word; //Correct attempt
            dummyForm1.textBox1_KeyDown(new object(), e);
            Assert.AreEqual(Color.GreenYellow, dummyForm1.textBoxGuess.BackColor);
            Assert.AreEqual(Color.GreenYellow, dummyForm1.textBoxGuess.ForeColor);
        }

        [Test]
        public void testForSameLetterGuess() //Testing if the same letter guess increases the picIndex or not.
        {
            Form1 dummyForm1=new Form1();
            KeyEventArgs e=new KeyEventArgs(Keys.Enter);
            
            dummyForm1.word = "test";
            dummyForm1.textBoxGuess.Text = "a"; //Same letter guesses
            dummyForm1.textBox1_KeyDown(new object(), e);
            int attemptIndex = dummyForm1.picIndex;
            dummyForm1.textBoxGuess.Text = "a";
            dummyForm1.textBox1_KeyDown(new object(), e);
            Assert.AreEqual(attemptIndex,dummyForm1.picIndex);
            dummyForm1.textBoxGuess.Text = "abc"; //Same word guesses
            dummyForm1.textBox1_KeyDown(new object(), e);
            attemptIndex = dummyForm1.picIndex;
            dummyForm1.textBoxGuess.Text = "abc";
            dummyForm1.textBox1_KeyDown(new object(), e);
            Assert.AreEqual(attemptIndex, dummyForm1.picIndex);
        }

        [Test]
        public void testForPartialWordGuess() //Testing if parts of the hidden word will count as correct guesses.
        {
            Form1 dummyForm1=new Form1();
            KeyEventArgs e=new KeyEventArgs(Keys.Enter);
            dummyForm1.textBoxGuess.Text =dummyForm1.word.Substring(2,3);
            dummyForm1.textBox1_KeyDown(new object(), e);
            dummyForm1.textBoxGuess.Text =dummyForm1.word.Substring(0,2);
            dummyForm1.textBox1_KeyDown(new object(), e);
            dummyForm1.textBoxGuess.Text = dummyForm1.word.Substring(3);
            dummyForm1.textBox1_KeyDown(new object(), e);
            Assert.AreEqual(Color.GreenYellow, dummyForm1.textBoxGuess.BackColor);

        }

        [Test]
        public void testPicIndexAfterPartialWordGuess() //Testing if the picIndex sets correctly after a correct/incorrect partial word guesses.
        {
            Form1 dummyForm1 = new Form1();
            KeyEventArgs e = new KeyEventArgs(Keys.Enter);
            int initialPicIndex = dummyForm1.picIndex;
            dummyForm1.word = "test";
            dummyForm1.textBoxGuess.MaxLength = 4;
            dummyForm1.textBoxGuess.Text = "abc"; //Incorrect guess
            dummyForm1.textBox1_KeyDown(new object(), e);
            Assert.AreEqual(initialPicIndex+1, dummyForm1.picIndex);
            initialPicIndex = dummyForm1.picIndex;
            dummyForm1.textBoxGuess.Text = "tes"; //Correct guess
            dummyForm1.textBox1_KeyDown(new object(), e);
            Assert.AreEqual(initialPicIndex, dummyForm1.picIndex);
        }

        [Test]
        public void testForLargerThanMaxLengthGuess() // Testing if the larger than maxLength guess registers or not.
        {
            Form1 dummyForm1=new Form1();
            KeyEventArgs e=new KeyEventArgs(Keys.Enter);
            dummyForm1.word = "test";
            dummyForm1.textBoxGuess.MaxLength = dummyForm1.word.Length;
            dummyForm1.textBoxGuess.Text = "abcde";
            dummyForm1.textBox1_KeyDown(new object(), e);
            Assert.AreNotEqual(1,picIndex);
        }

        [Test]
        public void testGetRandomWord() //Testing if getRandomWord will return a new word
        {
            Form1 dummyForm1 =new Form1();
            string initialWord = dummyForm1.word;
            System.Threading.Thread.Sleep(1000);
            dummyForm1.word=WordPool.getRandomWord();
            Assert.AreNotEqual(initialWord,dummyForm1.word);
        }

        [Test]
        public void testNumericalInputs() //Testing if numerical inputs are registered by the system correctly or not
        {
            Form1 dummyForm1 = new Form1();
            KeyEventArgs e=new KeyEventArgs(Keys.Enter);
            dummyForm1.textBoxGuess.Text = "2!3";
            dummyForm1.textBox1_KeyDown(new object(), e);
            Assert.IsTrue(!dummyForm1.isEnteredWord("2!3"));
        }

        #endregion Test Cases

        Image[] hangImg = {
            WFA_Hangman_EYE.Properties.Resources.hangman_0,
            WFA_Hangman_EYE.Properties.Resources.hangman_1,
            WFA_Hangman_EYE.Properties.Resources.hangman_2 ,
            WFA_Hangman_EYE.Properties.Resources.hangman_3 ,
            WFA_Hangman_EYE.Properties.Resources.hangman_4 ,
            WFA_Hangman_EYE.Properties.Resources.hangman_5 ,
            WFA_Hangman_EYE.Properties.Resources.hangman_6,
            WFA_Hangman_EYE.Properties.Resources.hangman_7
        };

        int picIndex = 0; //Failure tries.
        bool clickedOnReveal = false; //Initialize the clickedOnReveal boolean.

        public Form1()
        {
            InitializeComponent();              //Start widgets.

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            word = WordPool.getRandomWord();    //Get a random word from the pool.

            labelWord.Text = "";                //Reset the word label.

            foreach (char letter in word)                                           //For each letter of the word,
                labelWord.Text = labelWord.Text.Insert(labelWord.Text.Length, "_ ");//Insert an underscore.

            labelWord.Font = new System.Drawing.Font(labelWord.Font.Name, 16f); //Set the font of the word label
            textBoxGuess.MaxLength = word.Length;   //Limit the input length in Guess Text Box 

            pictureBox1.Image = hangImg[picIndex];  //Set the hangman image.
            if (word.Length < 5)                   //If the word is too short,
                labelRevealLetter.Enabled = false; //disable the reveal a letter feature.

        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter && !isEnteredWord(textBoxGuess.Text) && doesContainAllLetters(textBoxGuess.Text)) //While the guess text box is in focus, 
            {                                                                 //if the player presses enter and didn't enter that word before.
                //Enter the new word to the guessed letters box.
                richTextBoxGuessedWords.Text = richTextBoxGuessedWords.Text.Insert(richTextBoxGuessedWords.Text.Length, textBoxGuess.Text + "\n");

                //If the guess word is one letter && the player hasn't guessed that letter before.
                if (textBoxGuess.Text.Length == 1 && !richTextBoxGuessedLetters.Text.Contains(textBoxGuess.Text))
                    //Add the guessed letter to guessed letter box
                    richTextBoxGuessedLetters.Text = richTextBoxGuessedLetters.Text.Insert(richTextBoxGuessedLetters.Text.Length, textBoxGuess.Text + " ");

                int index = 0;

                if (!word.Contains(textBoxGuess.Text)) //If the word does not contain the guess word...
                {
                    picIndex++;                            //Increment the failed tries int.
                    pictureBox1.Image = hangImg[picIndex]; //Change the hangman picture.

                    if (picIndex == hangImg.Length - 2)    //Only one try left so,
                        labelRevealLetter.Enabled = false; //Disable the label.
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
        /// Checks whether the guessed word contains only letters or not
        /// </summary>
        /// <param name="_guessWord"></param>
        /// <returns>Returns true if the word contains all letters</returns>
        private bool doesContainAllLetters(string _guessWord)
        {
            return _guessWord.All(Char.IsLetter);
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

            if (word.Length < 5)                   //If the word is too short,
                labelRevealLetter.Enabled = false; //disable the reveal a letter feature.
            else
                labelRevealLetter.Enabled = true; //enable the feature if word is long enough.

            clickedOnReveal = false;              //Reset the clickedOnReveal boolean.
        }

        private void buttonHelp_Click(object sender, System.EventArgs e) //Click on help button.
        {
            //Show the help message.
            MessageBox.Show("Write letters in the Guess field and press enter to register.\n" +
                "You can guess parts of the word if you are sure.\n" +
                "For example, Word: Capitol Guess: pit\n" +
                "You can review the letters and words you've guessed on the right side.\n" +
                "You can reveal a letter once if the word is longer than 5 letters.\n" +
                "Good Luck!");
        }

        private void labelRevealLetter_Click(object sender, System.EventArgs e) //Click on Reveal label.
        {

            System.Random r = new System.Random(); //Get a new Random object.
            if (!clickedOnReveal && labelWord.Text.Contains('_'))//If the user didn't click on the label before and there is a letter to reveal.
            {
                clickedOnReveal = true;                         //Change the boolean to true/clicked.
                int randomIndex = r.Next(word.Length);          //Get a random int between 0 and word's length.
                while (labelWord.Text[randomIndex * 2] != '_')  //Get a random int until we find an underscore.
                    randomIndex = r.Next(word.Length);


                char[] buffer = labelWord.Text.ToCharArray();  //Buffer is needed to change the char at an index.
                buffer[randomIndex * 2] = word[randomIndex];
                labelWord.Text = new string(buffer);           //Change the labelWord's text / Reveal a letter.

                picIndex++;                            //Increment the failed tries int.
                pictureBox1.Image = hangImg[picIndex]; //Change the hangman picture.

                labelRevealLetter.Enabled = false;             //Disable the label.
            }
        }
    }
}
