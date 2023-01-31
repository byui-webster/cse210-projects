using System;

class Program
{
    static void Main(string[] args)
    {
        // For Parts 1 and 2, where the user specified the number...
        // Console.Write("What is the magic number? ");
        // int magicNumber = int.Parse(Console.ReadLine());
        
        // For Part 3, where we use a random number
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        string secretNumber = "6";
        string guess = "";
        string input = "yes";
        int guessCount = 0;
        int guessLimit = 5;
        bool outOfGuesses = false;
        


        // int guess = -1;

        // We could also use a do-while loop here...
        while (guess != secretNumber && !outOfGuesses)
        {
            if(guessCount < guessLimit) 
            {
                Console.Write("Enter your guess? ");
                guess = Console.ReadLine();
                guessCount++; 
            }
            
            else 
            {
                outOfGuesses = true;
            }

            if (outOfGuesses) 
            {
                Console.Write ("Game Over!");
            }

            else 
            {
                Console.Write ("You Won!");
            }
        }
        while (input == "yes")
        {
            Console.Write("Do you want to continue? ");
            input = Console.ReadLine();
        }                  
    }
}