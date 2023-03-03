// File: MathAssignment.cs

public class MathAssignment : Assignment
{
    private int numProblems;
    private bool isCalculus;

    public MathAssignment(string studentName, string topic, int numProblems, bool isCalculus)
        : base(studentName, topic)
    {
        this.numProblems = numProblems;
        this.isCalculus = isCalculus;
    }

    public string GetHomeworkList()
    {
        string calculusText = isCalculus ? "calculus" : "algebra";
        return $"Complete {numProblems} {calculusText} problems";
    }
}