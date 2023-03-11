using System;
using System.Collections.Generic;

// Base class for all goals
public class Goal
{
	// Private attributes
	public string name;
	public string getName;
	public int RecordGoal;
	public int Serialize;
	public static Goal Deserialize;
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
		return $"{name} ({points} points) [{(completed ? "X" : " ")}]";
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

	// Hide the inherited RecordGoal method with a new implementation
	public new int RecordGoal()
	{
		int pointsEarned = base.MarkCompleted();
		pointsEarned += pointsPerRecording;
		return pointsEarned;
	}

	// Override GetDescription to show the total points earned so far
	public override string GetDescription()
	{
		return $"{name} ({pointsPerRecording} points per recording, {base.GetDescription()}: {pointsPerRecording * Convert.ToInt32(completed)})";
	}
}

// Subclass for checklist goals that must be completed a certain number of times
public class ChecklistGoal : Goal
{
	// Private attributes
	private int pointsPerCompletion;
	private int targetCount;
	private int completedCount;
	// Constructor
	public ChecklistGoal(string name, int pointsPerCompletion, int targetCount) : base(name, 0)
	{
		this.pointsPerCompletion = pointsPerCompletion;
		this.targetCount = targetCount;
		this.completedCount = 0;
	}

	// Mark this goal as completed and return the points earned
	public override int MarkCompleted()
	{
		int pointsEarned = base.MarkCompleted();
		completedCount++;
		if (completedCount == targetCount)
		{
			pointsEarned += pointsPerCompletion * targetCount;
		}
		else
		{
			pointsEarned += pointsPerCompletion;
		}

		return pointsEarned;
	}

	// Override GetDescription to show the completion status
	public override string GetDescription()
	{
		return $"{name} ({pointsPerCompletion} points per completion, {base.GetDescription()}: Completed {completedCount}/{targetCount} times)";
	}
}

// Class for tracking the user's goals and score
public class GoalTracker
{
	// Private attributes
	private List<Goal> goals;
	private int score;
	// Constructor
	public GoalTracker()
	{
		goals = new List<Goal>();
		score = 0;
	}

	// Add a new goal to the list of goals
	public void AddGoal(Goal goal)
	{
		goals.Add(goal);
	}

	// Mark a goal as completed
	public class LargeGoal : Goal
	{
		private int progress;
		private int target;
		public LargeGoal(string name, int points, int target) : base(name, points)
		{
			this.target = target;
			this.progress = 0;
		}

		public void AddProgress(int amount)
		{
			this.progress += amount;
			if (this.progress >= this.target)
			{
				this.completed = true;
				this.points += 500;
			}
		}

		public override string GetDescription()
		{
			string status = this.completed ? "Completed" : "Incomplete";
			return $"{this.name}: {status}, Progress: {this.progress}/{this.target}";
		}
	}

	public class NegativeGoal : Goal
	{
		public NegativeGoal(string name, int points) : base(name, points)
		{
			this.points *= -1;
		}

		public override int MarkCompleted()
		{
			this.completed = true;
			return this.points;
		}

		public override string GetDescription()
		{
			return $"{this.name}: {(this.completed ? "Completed" : "Incomplete")}, {this.points} points";
		}
	}

	public class GoalTracker1
	{
		private List<Goal> goals;
		private int score;
		public GoalTracker1()
		{
			this.goals = new List<Goal>();
			this.score = 0;
		}

		public void AddGoal(Goal goal)
		{
			this.goals.Add(goal);
		}

		public void MarkGoalCompleted(string goalName)
		{
			foreach (Goal goal in this.goals)
			{
				if (goal.getName == goalName)
				{
					this.score += goal.MarkCompleted();
					return;
				}
			}
		}

		public void RecordGoal(string goalName)
		{
			foreach (Goal goal in this.goals)
			{
				if (goal.getName == goalName)
				{
					this.score += goal.RecordGoal;
					return;
				}
			}
		}

		public List<string> GetGoalList()
		{
			List<string> goalList = new List<string>();
			foreach (Goal goal in this.goals)
			{
				goalList.Add(goal.GetDescription());
			}

			return goalList;
		}

		public int GetScore()
		{
			return this.score;
		}

		public void SaveData(string fileName)
		{
			using (StreamWriter writer = new StreamWriter(fileName))
			{
				writer.WriteLine(this.score);
				foreach (Goal goal in this.goals)
				{
					writer.WriteLine(goal.Serialize);
				}
			}
		}

		public void LoadData(string fileName)
		{
			this.goals.Clear();
			using (StreamReader reader = new StreamReader(fileName))
			{
				this.score = int.Parse(reader.ReadLine());
				string line;
				while ((line = reader.ReadLine()) != null)
				{
					Goal goal = Goal.Deserialize(line);
					this.goals.Add(goal);
				}
			}
		}
	}
}