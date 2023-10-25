using System;

class Program {
  static string[] words = { "programming", "hangman", "computer", "developer", "csharp", "openai" };
  static Random random = new Random();
  static string selectedWord;
  static char[] guessedWord;
  static int maxAttempts = 6;
  static int remainingAttempts;
  
  public static void Main (string[] args) {
    StartGame();
    PlayGame();

    if (remainingAttempts == 0)
    {
        Console.WriteLine("You ran out of attempts! The word was: " + selectedWord);
    }
    else
    {
        Console.WriteLine("Congratulations! You guessed the word: " + selectedWord);
    }

    Console.WriteLine("Press any key to exit.");
    Console.ReadKey();
  }
  static void StartGame()
  {
      selectedWord = words[random.Next(0, words.Length)].ToLower();
      guessedWord = new char[selectedWord.Length];
      remainingAttempts = maxAttempts;

      for (int i = 0; i < selectedWord.Length; i++)
      {
          if (char.IsLetter(selectedWord[i]))
          {
              guessedWord[i] = '_';
          }
          else
          {
              guessedWord[i] = selectedWord[i];
          }
      }
  }

static void ClearConsole()
    {
        for (int i = 0; i < 25; i++)
        {
            Console.WriteLine();
        }
    }
  static void PlayGame()
  {
      while (remainingAttempts > 0)
      {     ClearConsole();
          Console.WriteLine("Hangman Game");
          Console.WriteLine("Attempts left: " + remainingAttempts);
          Console.WriteLine("Current word: " + new string(guessedWord));

          char guess = GetGuess();

          bool correctGuess = false;
          for (int i = 0; i < selectedWord.Length; i++)
          {
              if (selectedWord[i] == guess)
              {
                  guessedWord[i] = guess;
                  correctGuess = true;
              }
          }

          if (!correctGuess)
          {
              remainingAttempts--;
          }

          if (new string(guessedWord) == selectedWord)
          {
              break;
          }
      }
  }

  static char GetGuess()
  {
      Console.Write("Guess a letter: ");
      char guess;
      while (true)
      {
          string input = Console.ReadLine();
          if (input.Length == 1 && char.IsLetter(input[0]))
          {
              guess = input[0];
              break;
          }
          Console.Write("Invalid input. Please enter a single letter: ");
      }
      return guess;
  }
}