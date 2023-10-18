namespace GuessingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declaring variables
            string secretWord = "studyt";
            int maxAttempts = 3;
            int remainingAttempts = maxAttempts;

            Console.WriteLine($"You have {maxAttempts} attempts to guess the secret word");

            while (remainingAttempts > 0 )
            {
                Console.Write($"Attempt {maxAttempts - remainingAttempts + 1} of {maxAttempts}. Enter a guess: ");
                string userGuess = GetUserInput();

                if (userGuess == secretWord)
                {
                    DisplaySuccessMessage("Congrats!. You guessed the correct word");
                    break;
                }

                //Display the correct letters in the correct position to streamline options for the user
                else
                {
                    if (remainingAttempts > 1)
                    {
                        DisplayFailureMessage("Incorrect guess. Try again");
                         
                        List<CharInfo> CharList = new List<CharInfo>();
                        GetCharList(CharList, userGuess, secretWord);

                        if(CharList.Count > 0)
                        {
                            DisplayHint(secretWord, CharList);
                            Console.WriteLine(); //New line for clarity sake.
                        }
                    }

                    remainingAttempts--;

                    if (remainingAttempts > 0)
                    {
                        DisplayWarningMessage($"You have {remainingAttempts} attempt(s) left");
                    }
                    else
                    {
                        DisplayFailureMessage($"You have used up all your attempts. The secret word was: {secretWord}");
                    }
                }
            }

            Console.WriteLine("Thank you for playing!");

            static string GetUserInput()
            {
                return Console.ReadLine().ToLower();
            }

            static void DisplaySuccessMessage(string message)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(message);
                Console.ResetColor();
            }

            static void DisplayFailureMessage(string message)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ResetColor();
            }

            static void DisplayWarningMessage(string message)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(message);
                Console.ResetColor();
            }

            static void DisplayHint(string secretWord, List<CharInfo> charList)
            {
                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (charList.Any(x => x.Character == secretWord[i] && x.Index == i))
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(secretWord[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write('_');
                        Console.ResetColor();
                    }
                }
            }

            static void GetCharList(List<CharInfo> list, string userGuess, string secretWord)
            {
                List<int> indexes = new List<int>();

                foreach (var character in userGuess)
                {
                    int secretWordIndex = !indexes.Contains(secretWord.IndexOf(character)) ? secretWord.IndexOf(character) : secretWord.LastIndexOf(character);

                    if (!indexes.Contains(secretWordIndex) && secretWordIndex != -1)
                    {
                        //keep track of indexes to display multiple occurence of a characters
                        indexes.Add(secretWordIndex);
                    }

                    //check if character and it's index already exists
                    bool indexExists = list.Any(x => x.Index == secretWordIndex);

                    if (secretWordIndex != -1 && !indexExists)
                    {
                        //keep track of all characters and their indexes
                        list.Add(new CharInfo { Character = character, Index = secretWordIndex });
                    }
                }
            }
        }
    }
}