using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Hangman
{
    internal class Game
    {
        public bool IsRunning { get; set; }
        public string SecretWord { get; private set; } //hold the secret word

        private char[] GuessList = new char[26]; //hold an array of guesses to look through
        public int GuessCount { get; private set; }
        public int RemaingWrongGuesses { get; private set; }
        public Player Player { get; private set; }
        public Game(string secretWord, Player player)
        {
            Player = player;
            SecretWord = secretWord; //get the secret word
            IsRunning = true; //start the game running
            GuessCount = 0;
            RemaingWrongGuesses = 6;
        }

        public string ProcessGuess(char input)
        {
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
                    return $"You have found a letter {input}";
                }
            }
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
                        break;  //break out of the for loop, back to the foreach loop
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
                do Console.WriteLine("\nWhat letter would you like to guess? ");
                while (!char.TryParse(Console.ReadLine(), out input));
                input = char.ToLower(input);
                Console.WriteLine(ProcessGuess(input));
                if (RemaingWrongGuesses == 0)
                {
                    IsRunning = false;
                    Console.WriteLine($"You are out of guesses {Player.Name}, the word was {SecretWord} you lose.");
                }
                if (CheckWinCondition() == true)
                {
                    IsRunning = false;
                    Console.WriteLine($"{Player.Name}, you have won! The word was {SecretWord}.");
                }
            }
        }

        private void DisplayScore()
        {
            Console.Write($"Wrong guesses left [{RemaingWrongGuesses}]");
        }

        public bool CheckWinCondition()  //now it asks the exact rule of hangman, did every secret letter have at least one match
        {
            foreach (char c in SecretWord)
            {
                bool wasGuessed = false;

                for (int i = 0; i < GuessCount; i++)
                {
                    if (GuessList[i] == c)
                    {
                        wasGuessed = true;
                        break; //break out of the for loop, back to the foreach loop
                    }
                }

                if (!wasGuessed)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
