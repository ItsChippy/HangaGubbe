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
        private string secretWord;
        private int[] letterIdentifier;
        List<string> wordList = new List<string>(){"buss", "ägg", "blomma", "katt", "kratta", "byxor", "lampa", "bok", "stol", "bord"};
        List<string> incorrectGuesses = new List<string>();
        private int correctLetterCounter = 0;

        public Hangman()
        {
        }

        private string GenerateSecretWord()
        {

            Random rand = new Random();
            int index = rand.Next(wordList.Count);
            return wordList[index];
        }

        // Fill letteridentifiers with the value 0, implying letter not found
        private int[] GenerateLetterIdentifier()
        {
            letterIdentifier = new int[secretWord.Length];

            for (int i = 0; i < secretWord.Length; i++)
            {
                letterIdentifier[i] = 0;
            }

            return letterIdentifier;
        }

        //Takes in the input from the user and matches it to matching letters in the secret word. if the guess is incorrect, it gets added to the incorrect guesses array
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
                else
                {
                    continue;
                }
            }
            if (!isCorrectGuess)
            {
                incorrectGuesses.Add(userInput);
                lives--;
            }
        }

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


        //Main method that displays the game and progress
        public void PlayGame()
        {
            Console.WriteLine("Welcome to Hangman!");
            Console.WriteLine("Enter custom word or 'start' to play.");
            string userInput = Console.ReadLine();

            while (userInput.ToLower() != "start")
            {
                wordList.Add(userInput);
                userInput = Console.ReadLine();
            }
            secretWord = GenerateSecretWord();
            letterIdentifier = GenerateLetterIdentifier();

            while (lives != 0)
            {
                Console.Clear();
                if (correctLetterCounter == secretWord.Length)
                {
                    CheckLives();
                    DisplayScore();
                    Console.WriteLine($"You win! The word was '{secretWord}' :) ");
                    break;
                }
                
                CheckLives();
                DisplayScore();

                string? input = Console.ReadLine();
                if (input == null)
                {
                    Console.WriteLine("Guess again");
                    continue;
                }

                HandleUserInput(input);
            }
            if (lives == 0)
            {
                Console.WriteLine($"You lose! The word was '{secretWord}' :(");
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

            Console.Write("\nEnter a letter to guess: ");
        }


       

        //Debug method
        public void Debugging()
        {
            //write test code here
        }

        //6 different states of the Hangman
        private void RitaGubbe1()
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

        private void RitaGubbe2()
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

        private void RitaGubbe3()
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

        private void RitaGubbe4()
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

        private void RitaGubbe5()
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

        private void RitaGubbe6()
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

        //Checks players' lives and prints the corresponding image.
        private void CheckLives()
        {
            if (lives == 5)
            {
                RitaGubbe1();
            }
            else if (lives == 4)
            {
                RitaGubbe2();
            }
            else if (lives == 3)
            {
                RitaGubbe3();
            }
            else if (lives == 2)
            {
                RitaGubbe4();
            }
            else if (lives == 1)
            {
                RitaGubbe5();
            }
            else
            {
                RitaGubbe6();
            }
        }


    }
}
