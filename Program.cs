namespace GuessingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declaring variables
            string secretWord = "programming";
            int maxAttempts = 3;
            int remainingAttempts = maxAttempts;

            Console.WriteLine("Welcome to the Word Guessing Game!");
            Console.WriteLine($"You have {maxAttempts} attempts to guess the secret word");

            while ( remainingAttempts > 0 )
            {
                Console.Write($"Attempt {maxAttempts - remainingAttempts + 1} of {maxAttempts}. Enter a guess: ");
                string userGuess = Console.ReadLine();

                if (userGuess == secretWord)
                {
                    Console.WriteLine("Congrats!. You guessed the correct word");
                    break;
                }
                //Display the correct letters in the correct position to streamline options for the user
                else
                {
                    Console.WriteLine("Incorrect guess.");

                    HashSet<char> displayedchar = new();

                    for (int i = 0; i < secretWord.Length; i++)
                    {
                        //ensure it's only one occurence printed to the console
                        if (displayedchar.Contains(secretWord[i]))
                        {
                            Console.Write("_");
                        }
                        else
                        {
                            bool foundMatch = false; //keep track for match

                            for (int j = 0; j < userGuess.Length; j++)
                            {
                                if (userGuess[j] == secretWord[i])
                                {
                                    foundMatch = true;
                                    displayedchar.Add(secretWord[i]);
                                    Console.Write(secretWord[i]);
                                    break; //Move the next iteration
                                }
                            }

                            if (!foundMatch)
                            {
                                Console.Write("_");
                            }

                        }
                    }
                }

                Console.WriteLine(); //New line for clarity sake.
                remainingAttempts--;

                Console.WriteLine(remainingAttempts > 0 ? $"You have {remainingAttempts} attempt(s) left" : $"You have used up all your attempts. The secret word was: {secretWord}");

            }

        }
    }
}