namespace HangmanProject
{
    class Program
    {
        static void Main(string[] args)
        {
            const int LIMIT = 15;
            const int START = 1;

            Console.WriteLine("Hello, Welcome to Hangman game!");
            Console.WriteLine("I hope you will enjoy this game");

            // List of words-car names
            List<string> cars = new List<string> { "Audi", "Benz", "Ford", "Honda", "Hyundai", "Tesla" };
            // Way to choose a random word from the list
            Random random = new Random();
            string selectedWord = cars[random.Next(cars.Count)];
            string lowerCaseSelectedWord = selectedWord.ToLower();
            //check the lenghth of the selected word
            int wordLength = selectedWord.Length;
            string wordCharacters = new string('_', wordLength);
            Console.WriteLine($"The secret word is within: {wordCharacters}");
            char[] currentCharacters = wordCharacters.ToCharArray();

            //Initializing variables
            int position = 0;
            char userInputletter;
            char guessedLetter;

            for (int i = START; i <= LIMIT; i++)
            {
                bool presentLetter = false;
                Console.WriteLine("Hey enter your guess letter");
                userInputletter = Console.ReadKey().KeyChar;
                if (char.IsLetter(userInputletter))
                {
                    Console.WriteLine($"\nYou guessed {userInputletter}");
                }
                else
                {
                    Console.WriteLine($"\nYou must enter only letters, you guessed {userInputletter}");
                    Console.WriteLine($"You guessed {i} times. you are now remained with {LIMIT - i} guesses");
                    continue;
                }

                int check = 0;
                guessedLetter = char.ToLower(userInputletter);
                for (check = 0; check < wordLength; check++)
                {
                    if (lowerCaseSelectedWord[check] == guessedLetter)
                    {
                        position = check;
                        presentLetter = true;
                    }
                }
                if (!presentLetter)
                {
                    Console.WriteLine($"The letter {guessedLetter} is not in the secret word");
                }
                if (presentLetter)
                {
                    Console.WriteLine($"The letter {guessedLetter} is in the secret word");
                    currentCharacters[position] = guessedLetter;
                    Console.WriteLine(currentCharacters);
                }
                bool isEqual = new string(currentCharacters) == lowerCaseSelectedWord;
                if (isEqual)
                {
                    Console.WriteLine($"You guessed {selectedWord} and it is the correct word, Conglatulation");
                    return;
                }
                if (i < LIMIT)
                {
                    Console.WriteLine($"You guessed {i} times. you are now remained with {LIMIT - i} guesses");
                }
                if (i == LIMIT)
                {
                    Console.WriteLine($"That was your last guess");
                }
            }

            Console.WriteLine($"The word is {selectedWord}.");
        }
    }
}

