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

        public char[]? GuessList { get; private set; } //hold an array of guesses to look through

        //guess validation
        //win loss detection
        //the word

        public Game(string secretWord, Player player)
        {
            SecretWord = secretWord; //get the secret word
            IsRunning = true; //start the game running
        }

        public string ProcessGuess(char input)
        {
            //look at GuessList for previous guess
            //if guessed before
            
            foreach (char c in GuessList)
            {
                if (c == input)
                {
                    return $"You have already guessed {input}.";
                }
                else
                {
                    //add the char to the guess list
                    //the updateed masked word will handle the display
                    GuessList[].Add(input);
                    return $"You have found a letter {input}";
                }

            }
            //if not then try against the SecretWord

            //try against SecretWord
            //foreach char c in SecretWord
            //{
            //if {input == c}
            // UpdateSecretWord()? //method to unhide the letter
            //}
            //return $"There are no {input}'s in the word.";

        }

        public void DisplayMaskedWord()
        {
            foreach (char c in SecretWord)
            {
                if (GuessList == null)
                {
                    Console.Write("_ ");
                }
                else
                {
                    foreach (char g in GuessList)
                    {
                        if (c == g)
                        {
                            Console.Write($"{c} ");
                        }
                        else
                            Console.Write("_ ");
                    }
                }
            }
        }

        public void Turn()
        {
            char input;
            while (IsRunning == true)
            {
                DisplayMaskedWord();
                do Console.WriteLine("What letter would you like to guess");
                while (!char.TryParse(Console.ReadLine(), out input));
                input = char.ToLower(input);
                ProcessGuess(input);
            }


        }


        //ProcessGuess
        //IsWordSolved
        //GetMaskedWord
        //HasAlreadyGuessed
    }
}
