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

        String choice = Console.ReadLine();

        if (choice.Equals("1"))
        {
          Console.Clear();
          Console.WriteLine("I dunnno...");
        }
        else if (choice.Equals("0"))
        {
          Console.Clear();
          Console.WriteLine("Goodbye!");
          Exit();
        }
      }
    }
    static void Exit()
    {
      Environment.Exit(1);
    }
  }
}