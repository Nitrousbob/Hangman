using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Hangman
{
    internal class Game
    {
        public bool IsRunning { get; set; }
        //game state
        public string SecretWord { get; private set; } //hold the secret word

        private char[] GuessList = new char[26]; //hold an array of guesses to look through
        public int GuessCount { get; private set; }
        public int RemaingWrongGuesses { get; private set; }

        public Game(string secretWord, Player player)
        {
            SecretWord = secretWord; //get the secret word
            IsRunning = true; //start the game running
            GuessCount = 0;
            RemaingWrongGuesses = 6;
        }

        public string ProcessGuess(char input)
        {
            //look at GuessList for previous guess
            //if guessed before
            
            for (int i = 0; i < GuessCount; i++)
            {
                if (GuessList[i] == input)  //go through the array
                {
                    return $"You have already guessed {input}.";
                    //do not increase turn number
                }
            }

            GuessList[GuessCount] = input; //add the character to the GuessList Array
            GuessCount++;//Increase the Guess Count for any more actions because they are new

            foreach (char s in SecretWord)
            {
                if (input == s)
                {
                    //GuessList[].Add(input);
                    return $"You have found a letter {input}";
                }
            }
            //Add guess to GuessList
            RemaingWrongGuesses--; //remove a wrong guess
            return $"The letter {input} is not in the word.";
        }
     
        public void DisplayMaskedWord()
        {
            foreach (char c in SecretWord)  //go through each character in Secret Word
            {
                bool wasGuessed = false;

                for (int i = 0; i < GuessCount; i++)
                {
                    if (GuessList[i] == c)
                    {
                        wasGuessed = true;
                        break;
                    }
                }

                if (wasGuessed)
                {
                    Console.Write($"{c} ");
                }
                else
                { 
                     Console.Write("_ ");
                }
            }
        }

        public void Turn()
        {
            char input;
            while (IsRunning == true)
            {
                DisplayMaskedWord(); 
                DisplayScore();
                do Console.WriteLine("\nWhat letter would you like to guess");
                while (!char.TryParse(Console.ReadLine(), out input));
                input = char.ToLower(input);
                Console.WriteLine(ProcessGuess(input));
                if (RemaingWrongGuesses == 0)
                {
                    IsRunning = false;
                    Console.WriteLine($"You are out of guesses, the word was {SecretWord} you lose.");
                }
                if (CheckWinCondition() == true)
                {
                    IsRunning = false;
                    Console.WriteLine($"You have won! The word was {SecretWord}.");
                }
            }
        }

        private void DisplayScore()
        {
            Console.Write($"Wrong guesses left [{RemaingWrongGuesses}]");
        }

        public bool CheckWinCondition()
        {
            int flags = 0;
            foreach (char c in SecretWord)  //go through each character in Secret Word
            {
                for (int i = 0; i < GuessCount; i++)
                {
                    if (GuessList[i] == c)
                    {
                        flags++;  //add a flag for each matching letter 
                    }
                }   
            }
            if (flags == SecretWord.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
