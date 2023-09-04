using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HangaGubbe
{
    internal class Hangman
    {
        private int lives = 5;
        private string secretWord;
        List<string> incorrectGuesses = new List<string>();
        List<string> maskedSecretWord = new List<string>();
        private int correctLetterCounter = 0;

        public Hangman()
        {
            secretWord = GenerateSecretWord();

            for (int i = 0; i < secretWord.Length; i++)
            {
                maskedSecretWord.Add("_");
            }
        }

        private string GenerateSecretWord()
        {
            string[] wordList = {
                "buss", "ägg", "blomma", "katt", "kratta",
                "byxor", "lampa", "bok", "stol", "bord"
            };
            Random rand = new Random();
            int index = rand.Next(wordList.Length);
            return wordList[index];
        }


        //Main method that displays the game and progress
        public void PlayGame()
        {
            Console.WriteLine("Välkommen till hänga gubbe!");
            Console.WriteLine("Tryck enter för att fortsätta..");
            Console.ReadLine();
            
            while (lives !=0)
            {
                if (correctLetterCounter == secretWord.Length)
                {
                    Console.WriteLine("Du har vunnit!");
                    break;
                }

                CheckLives();
                
                foreach (var letter in maskedSecretWord)
                {
                    Console.Write(letter);
                }
                
                Console.WriteLine("\nGissa en bokstav: ");
                string? input = Console.ReadLine();
                if(input == null)
                {
                    Console.WriteLine("Gissa igen");
                    continue;
                }
                else
                {
                    HandleUserInput(input); 
                }

            }
        }

        //Takes in the input from the user and matches it to matching letters in the secret word. if the guess is incorrect, it gets added to the incorrect guesses array
        private void HandleUserInput(string userInput)
        {
            bool isCorrectGuess = false;
            for (int i = 0; i < secretWord.Length; i++)
            {
                if (userInput == secretWord[i].ToString())
                {
                    maskedSecretWord[i] = userInput;
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

        //Debug method
        public void GetWord()
        {
            Console.WriteLine(secretWord);
            foreach (var index in maskedSecretWord)
            {
                Console.Write(index);
            }
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
