using System;
using System.Collections.Generic;

// Base class for all goals
public class Goal
{
	// Public attributes
	public string name;
	public int points;
	public bool completed;
	// Constructor
	public Goal(string name, int points)
	{
		this.name = name;
		this.points = points;
		this.completed = false;
	}

	// Mark this goal as completed and return the points earned
	public virtual int MarkCompleted()
	{
		completed = true;
		return points;
	}

	// Get a string description of this goal
	public virtual string GetDescription()
	{
		return name + " (" + points + " points) [" + (completed ? "X" : " ") + "]";
	}

	// Deserialize a Goal object from a string
	public static Goal Deserialize(string data)
	{
		string[] fields = data.Split(',');
		if (fields.Length < 3)
		{
			throw new ArgumentException("Invalid data format");
		}

		string type = fields[0];
		string goalName = fields[1]; // Change local variable name to 'goalName'
		int points;
		if (!Int32.TryParse(fields[2], out points))
		{
			throw new ArgumentException("Invalid points format");
		}

		switch (type)
		{
			case "SimpleGoal":
				return new SimpleGoal(goalName, points); // Use the updated local variable name
			case "EternalGoal":
				if (fields.Length < 4)
				{
					throw new ArgumentException("Invalid data format");
				}

				int pointsPerRecording = Int32.Parse(fields[3]);
				return new EternalGoal(goalName, pointsPerRecording); // Use the updated local variable name
			case "ChecklistGoal":
				if (fields.Length < 5)
				{
					throw new ArgumentException("Invalid data format");
				}

				int pointsPerCompletion = Int32.Parse(fields[3]);
				int targetCount = Int32.Parse(fields[4]);
				return new ChecklistGoal(goalName, pointsPerCompletion, targetCount); // Use the updated local variable name
			case "LargeGoal":
				if (fields.Length < 4)
				{
					throw new ArgumentException("Invalid data format");
				}

				int target = Int32.Parse(fields[3]);
				return new LargeGoal(goalName, points, target); // Use the updated local variable name
			case "NegativeGoal":
				return new NegativeGoal(goalName, points); // Use the updated local variable name
			default:
				throw new ArgumentException("Invalid goal type '" + type + "'");
		}
	}
}

// Subclass for simple goals that can be marked complete
public class SimpleGoal : Goal
{
	// Constructor
	public SimpleGoal(string name, int points) : base(name, points)
	{
	}

	// Override MarkCompleted method to simply call the parent implementation
	public override int MarkCompleted()
	{
		return base.MarkCompleted();
	}
}

// Subclass for eternal goals that are never complete but each recording earns points
public class EternalGoal : Goal
{
	// Private attributes
	private int pointsPerRecording;
	// Constructor
	public EternalGoal(string name, int pointsPerRecording) : base(name, 0)
	{
		this.pointsPerRecording = pointsPerRecording;
	}

	// Hide the inherited MarkCompleted method with a new implementation
	public int MarkCompleted(int recordings)
	{
		int pointsEarned = pointsPerRecording * recordings;
		points += pointsEarned;
		return pointsEarned;
	}

	// Override GetDescription to show the total points earned so far
	public override string GetDescription()
	{
		return name + " (" + points + " points earned) [Eternal]";
	}
}

// Subclass for goals that require multiple completions
public class ChecklistGoal : Goal
{
	// Private attributes
	private int pointsPerCompletion;
	private int targetCount;
	private int completionCount;
	// Constructor
	public ChecklistGoal(string name, int pointsPerCompletion, int targetCount) : base(name, 0)
	{
		this.pointsPerCompletion = pointsPerCompletion;
		this.targetCount = targetCount;
		this.completionCount = 0;
	}

	// Override MarkCompleted method to track the number of completions and update points
	public override int MarkCompleted()
	{
		completionCount++;
		if (completionCount >= targetCount)
		{
			completed = true;
		}

		points += pointsPerCompletion;
		return pointsPerCompletion;
	}

	// Override GetDescription to show the completion progress and target count
	public override string GetDescription()
	{
		return name + " (" + points + " points) [" + completionCount + "/" + targetCount + "]";
	}
}

// Subclass for goals that require a large amount of points to complete
public class LargeGoal : Goal
{
	// Private attributes
	private int target;
	// Constructor
	public LargeGoal(string name, int points, int target) : base(name, points)
	{
		this.target = target;
	}

	// Override MarkCompleted method to check if the goal is complete
	public override int MarkCompleted()
	{
		if (points >= target)
		{
			completed = true;
		}

		return points;
	}

	// Override GetDescription to show the target points and progress
	public override string GetDescription()
	{
		return name + " (" + points + "/" + target + " points) [" + (completed ? "X" : " ") + "]";
	}
}

// Subclass for negative goals that subtract points when completed
public class NegativeGoal : Goal
{
	// Constructor
	public NegativeGoal(string name, int points) : base(name, -points)
	{
	}

	// Override MarkCompleted method to simply call the parent implementation
	public override int MarkCompleted()
	{
		return base.MarkCompleted();
	}
}

// Main program
public class Program
{
	public static void Main()
	{
		string data = "ChecklistGoal,Do laundry,10,5";
		Goal goal = Goal.Deserialize(data);
		Console.WriteLine(goal.GetDescription());
		try
		{
			// Call Deserialize method with the data string
			Goal newgoal = Goal.Deserialize(data);
		}
		catch (ArgumentException ex)
		{
			// Handle the ArgumentException
			Console.WriteLine("Error: " + ex.Message);
		// You can also perform additional error handling or logging here
		}
	}
}