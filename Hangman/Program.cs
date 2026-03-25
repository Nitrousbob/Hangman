namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // the game picks a word at random from a list of words 
            //The game's state is displayed to the player as shown above 
            //the player can pick a letter if they pick a letter they already chose pick again 
            //The game should update its state based on the letter the player picked 
            //The game needs to detect a win for the player All letters have been guessed 
            //The game needs to detect a loss for the player out of incorrect guesses 


            Console.Title = "Hangman";

            for (int i = 0; i < 2; i++)  //create 2 players
            {
                Console.WriteLine($"Hello Player {i+1}, What is your name? ");
                string playerName = Console.ReadLine();
                Player player = new(playerName);
            }

            Console.WriteLine("Welcome Players.");

        }
    }
}
