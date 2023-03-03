using System;
using System.Threading;

// Base class for activities
public abstract class Activity {
    protected int count; // number of times activity performed
    
    // constructor
    public Activity() {
        count = 0;
    }
    
    // method to perform activity
    public abstract void Perform();
    
    // method to display activity count
    public void DisplayCount() {
        //Console.WriteLine($"You have performed this activity {count} times.");
    }
}

// Breathing activity class
public class BreathingActivity : Activity {
    // constructor
    public BreathingActivity() : base() {}
    
    // method to perform breathing activity
    public override void Perform() {
        Console.WriteLine("Welcome to the Breathing Activity! \nThis activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
        Console.Write("How long would you like to do this activity (in seconds)? ");
        int duration = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("Starting in:");
        for (int i = 3; i > 0; i--) {
            Console.WriteLine(i);
            Thread.Sleep(1000);
        }
        Console.WriteLine("Go!");
        
        // loop for duration of activity
        for (int i = 0; i < duration; i++) {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(2000); // 2 seconds for inhale
            Console.WriteLine("Breathe out...");
            Thread.Sleep(2000); // 2 seconds for exhale
        }
        
        Console.WriteLine("Good job!");
        count++;
    }
}

// Reflection activity class
public class ReflectionActivity : Activity {
    // constructor
    public ReflectionActivity() : base() {}
    
    // method to perform reflection activity
    public override void Perform() {
        Console.WriteLine("Welcome to the Reflection Activity! \nThis activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        Console.WriteLine("Think of a time when you were successful or demonstrated strength.");
        // user inputs experience
        Console.Write("What was the experience? ");
		Console.ReadLine();
		Console.Write("Think of a time when you stood up for someone else. ");
		Console.ReadLine();
		Console.Write("Think of a time when you did something really difficult. ");
		Console.ReadLine();
		Console.Write("Think of a time when you helped someone in need. ");
		Console.ReadLine();
		Console.Write("Think of a time when you did something truly selfless. ");
		Console.ReadLine();

        string experience = Console.ReadLine();
        
        //Console.WriteLine($"Let's reflect more deeply about your experience: {experience}");
        // prompt user with questions to reflect more deeply
        Console.Write("Why was this experience meaningful to you? ");
        Console.ReadLine();
        Console.Write("Have you ever done anything like this before? ");
        Console.ReadLine();
        Console.Write("How did you get started? ");
        Console.ReadLine();
        Console.Write("How did you feel when it was complete? ");
        Console.ReadLine();
        
        Console.WriteLine("Great reflection!");
        count++;
    }
}

// Listing activity class
public class ListingActivity : Activity {
    // constructor
    public ListingActivity() : base() {}
    
    // method to perform listing activity
    public override void Perform() {
        Console.WriteLine("Welcome to the Listing Activity! \nThis activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        Console.WriteLine("Think of an area where you have strength or positivity.");
        // user inputs area of strength or positivity
        Console.Write("What is the area? ");
		Console.ReadLine();
		Console.Write("Who are people that you appreciate? ");
		Console.ReadLine();
		Console.Write("What are personal strengths of yours? ");
		Console.ReadLine();
		Console.Write("Who are people that you have helped this week? ");
		Console.ReadLine();
		Console.Write("When have you felt the Holy Ghost this month? ");
		Console.ReadLine();
		Console.Write("Who are some of your personal heroes? ");
		Console.ReadLine();
		//string area = Console.ReadLine();
        //string area = Console.ReadLine();
        
        //Console.WriteLine($"Let's list as many things as we can in the area of {area}.");
        // loop for listing items
        string item;
        do {
            Console.Write("Input Item (or 'done' to finish): ");
            item = Console.ReadLine();
            if (item != "done") {
                count++;
            }
        } while (item != "done");
        
        Console.WriteLine("Great job listing!");
    }
}

// Main program
public class Program {
    public static void Main(string[] args) {
        BreathingActivity breathingActivity = new BreathingActivity();
        ReflectionActivity reflectionActivity = new ReflectionActivity();
        ListingActivity listingActivity = new ListingActivity();
        
        // menu loop
        int choice;
        do {
			Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());
            
            switch (choice) {
                case 1:
                    breathingActivity.Perform();
                    break;
                case 2:
                    reflectionActivity.Perform();
                    break;
                case 3:
                    listingActivity.Perform();
                    break;
                case 4:
                    Console.WriteLine("Exiting program...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        } while (choice != 4);
        
        // display activity counts
        breathingActivity.DisplayCount();
        reflectionActivity.DisplayCount();
        listingActivity.DisplayCount();
    }
}
