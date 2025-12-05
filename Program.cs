using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

namespace Wordle
{
	class Program
	{
		static void Main(string[] arg)
		{
			Start();

			static void Start()
			{
				Console.WriteLine("Douglas's Wordle");
				Console.WriteLine("1 - Play");
				Console.WriteLine("0 - Exit");

				String choice = Console.ReadLine() ?? ""; // [?? ""] removes the null warning.

				if (choice.Equals("1"))
				{
					Console.Clear();
					Play();
				}
				else if (choice.Equals("0"))
				{
					Console.Clear();
					Console.WriteLine("Goodbye!");
					Exit();
				}
				else
				{
					Console.WriteLine("Hey");
				}

			}
		}
		static void Exit()
		{
			Environment.Exit(1);
		}

		static void Play()
		{
			// QUICK REMINDERS FOR MYSELF:
			// Wordle consists of a maximum of 6 guesses
			// 5 letter word (normal)
			// Green if letter is INSIDE the word AND in the correct position
			// Yellow if letter is INSIDE the word but NOT in the correct position
			// Grey if letter is NOT inside the word at all
			// There can be multiple instances of a single letter, which I'll have to work out at some point

			// For now the Answer will always be "s t o a t" to work out the logic
			char[] answer = Answer();
			char[] validGuess;

			Console.WriteLine("Please type in a five letter word and press ENTER");
            

            int guessesMade = 0;
			bool win = false;
			while(win == false)
			{
				if (guessesMade == 6)
				{
					Console.BackgroundColor = ConsoleColor.Red;
					Console.WriteLine("\nt r a g i c");
					Console.ResetColor();
					break;
				}
                answer = Answer(); // Reset each time
                validGuess = GuessCheck();
                Respond(validGuess, answer);
				guessesMade++;
            }
        }
		
		static char[] Answer()
		{
            char[] answer = { 's', 't', 'o', 'a', 't' };
            return answer;
		}

		static char[] GuessCheck()
		{
            Console.ForegroundColor = ConsoleColor.Cyan;
            String guess = Console.ReadLine() ?? "";
            Console.ResetColor();

            char[] validGuess = {};

			while (guess.Length !=5)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Invalid Guess");
				Console.ForegroundColor = ConsoleColor.Cyan;
				guess = Console.ReadLine() ?? "";
				Console.ResetColor();
			}
			validGuess = guess.ToCharArray();
			return validGuess;
        }

		static void Respond(char[] vg, char[] answer)
		{
			for (int i = 0; i < 5; i++)
			{
				if (vg[i] == answer[i])
				{
					Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(vg[i]);
					Console.ResetColor();
                    Console.Write(" ");
                }
				else if (answer.Contains(vg[i]))
				{
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(vg[i]);
                    Console.ResetColor();
                    Console.Write(" ");
                }
				else
				{
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(vg[i]);
                    Console.ResetColor();
                    Console.Write(" ");
                }
                // Changes the value in answer so that when checking if answer contains
                // x char it doesn't say a char is within the array multiple times incorrectly.
                answer[i] = '0';
			}
            Console.WriteLine();
        }
	}
}