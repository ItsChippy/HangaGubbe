using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HangaGubbe
{
    internal class Hangman
    {
        private int lives = 5;
        private string secretWord = "";
        private int[] letterIdentifier;
        List<string> wordList = new List<string>(){"buss", "ägg", "blomma", "katt", "kratta", "byxor", "lampa", "bok", "stol", "bord"};
        List<string> incorrectGuesses = new List<string>();
        private int correctLetterCounter = 0;

        /// <summary>
        /// Generates a new secret word.
        /// </summary>
        private string GenerateSecretWord()
        {

            Random rand = new Random();
            int index = rand.Next(wordList.Count);
            return wordList[index];
        }

        /// <summary>
        /// Fill letteridentifiers array with the value 0, implying letter not found.
        /// </summary>
        private int[] GenerateLetterIdentifier()
        {
            letterIdentifier = new int[secretWord.Length];

            for (int i = 0; i < secretWord.Length; i++)
            {
                letterIdentifier[i] = 0;
            }

            return letterIdentifier;
        }

        /// <summary>
        /// Match user input with secret word letters.
        /// If the guess is incorrect add it to the incorrect guesses array.
        /// </summary>
        private void HandleUserInput(string userInput)
        {
            bool isCorrectGuess = false;
            if (CheckDoubleGuess(userInput)) // Checks if the guessed letter has been entered previously
            {
                Console.WriteLine($"You have already guessed the letter {userInput}!");
                Thread.Sleep(3000);
                return;
            }
            for (int i = 0; i < secretWord.Length; i++)
            {
                if (userInput == secretWord[i].ToString())
                {
                    letterIdentifier[i] = 1; // mark current letter as found
                    isCorrectGuess = true;
                    correctLetterCounter++;
                }
            }
            if (!isCorrectGuess)
            {
                incorrectGuesses.Add(userInput);
                lives--;
            }
        }

        /// <summary>
        /// Check for double guesses in correct and incorrect guesses.
        /// </summary>
        private bool CheckDoubleGuess(string inputLetter)
        {
            bool isDoubleGuess = false;

            for (int i = 0; i < letterIdentifier.Length; i++)
            {
                if(inputLetter == secretWord[i].ToString() && letterIdentifier[i] == 1)
                {
                    isDoubleGuess = true;
                    break;
                }
            }
            for (int i = 0; i < incorrectGuesses.Count(); i++)
            {
                if (inputLetter == incorrectGuesses[i])
                {
                    isDoubleGuess = true;
                    break;
                }
            }

            return isDoubleGuess;
        }


        /// <summary>
        /// Game loop that displays the current game
        /// </summary>
        public void PlayGame()
        {
            Console.WriteLine("Welcome to Hangman!");
            Console.WriteLine("Enter custom word or 'start' to play.");
            string? userInput = Console.ReadLine();

            while (userInput.ToLower() != "start") //checks for the word "start" in order to start the game
            {
                wordList.Add(userInput);
                userInput = Console.ReadLine();
            }
            secretWord = GenerateSecretWord();
            letterIdentifier = GenerateLetterIdentifier();

            while (lives > 0) //Main gameplay loop
            {
                Console.Clear();

                if (correctLetterCounter == secretWord.Length) //checks the win condition
                {
                    DrawHangman();
                    DisplayScore();
                    Console.WriteLine($"\nYou win! The word was '{secretWord}' :) ");
                    break;
                }

                DrawHangman();
                DisplayScore();

                Console.Write("\nEnter a letter to guess: ");
                string? input = Console.ReadLine();
                if (input == null)
                {
                    Console.WriteLine("Guess again");
                    continue;
                }

                HandleUserInput(input);
            }
            if (lives == 0) //Checks if user has lost and displays a message
            {
                Console.WriteLine($"\nYou lose! The word was '{secretWord}' :(");
            }
        }

        /// <summary>
        /// Method to display wrong guesses, correct guesses and input prompt
        /// </summary>
        private void DisplayScore()
        {
            for (int i = 0; i < letterIdentifier.Length; i++)
            {
                if (letterIdentifier[i] == 1)
                {
                    Console.Write(secretWord[i].ToString() + " ");
                }
                else
                {
                    Console.Write("_" + " ");
                }
            }

            // Add newline between correct and incorrect guesses
            Console.WriteLine();

            // Write wrong guesses to screen
            foreach (var letter in incorrectGuesses)
            {
                Console.Write(letter);
            }

        }

        /// <summary>
        /// The different states of the hangman
        /// </summary>
        private void DrawHangmanBox()
        {
            Console.WriteLine("#############################");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#############################");

        }

        private void DrawHangmanRope()
        {
            Console.WriteLine("#############################");
            Console.WriteLine("#            #              #");
            Console.WriteLine("#            #              #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#############################");

        }

        private void DrawHangmanHead()
        {
            Console.WriteLine("#############################");
            Console.WriteLine("#            #              #");
            Console.WriteLine("#            #              #");
            Console.WriteLine("#          #####            #");
            Console.WriteLine("#          #####            #");
            Console.WriteLine("#          #####            #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#############################");
        }

        private void DrawHangmanArms()
        {
            Console.WriteLine("#############################");
            Console.WriteLine("#            #              #");
            Console.WriteLine("#            #              #");
            Console.WriteLine("#          #####            #");
            Console.WriteLine("#          #####            #");
            Console.WriteLine("#          #####            #");
            Console.WriteLine("#            #              #");
            Console.WriteLine("#       ###########         #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#############################");
        }

        private void DrawHangmanBody()
        {
            Console.WriteLine("#############################");
            Console.WriteLine("#            #              #");
            Console.WriteLine("#            #              #");
            Console.WriteLine("#          #####            #");
            Console.WriteLine("#          #####            #");
            Console.WriteLine("#          #####            #");
            Console.WriteLine("#            #              #");
            Console.WriteLine("#       ###########         #");
            Console.WriteLine("#            #              #");
            Console.WriteLine("#            #              #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#############################");

        }

        private void DrawHangmanLegs()
        {
            Console.WriteLine("#############################");
            Console.WriteLine("#            #              #");
            Console.WriteLine("#            #              #");
            Console.WriteLine("#          #####            #");
            Console.WriteLine("#          #####            #");
            Console.WriteLine("#          #####            #");
            Console.WriteLine("#            #              #");
            Console.WriteLine("#       ###########         #");
            Console.WriteLine("#            #              #");
            Console.WriteLine("#            #              #");
            Console.WriteLine("#           ###             #");
            Console.WriteLine("#          #   #            #");
            Console.WriteLine("#         #     #           #");
            Console.WriteLine("#        #       #          #");
            Console.WriteLine("#                           #");
            Console.WriteLine("#############################");


        }

        /// <summary>
        /// Check player's lives and draw the corresponding picture
        /// </summary>
        private void DrawHangman()
        {
            if (lives == 5)
            {
                DrawHangmanBox();
            }
            else if (lives == 4)
            {
                DrawHangmanRope();
            }
            else if (lives == 3)
            {
                DrawHangmanHead();

            }
            else if (lives == 2)
            {
                DrawHangmanArms();
            }
            else if (lives == 1)
            {
                DrawHangmanBody();
            }
            else
            {
                DrawHangmanLegs();
            }
        }


    }
}
