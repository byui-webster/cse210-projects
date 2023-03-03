// File: WritingAssignment.cs

public class WritingAssignment : Assignment
{
    private int numPages;
    private string citationStyle;

    public WritingAssignment(string studentName, string topic, int numPages, string citationStyle)
        : base(studentName, topic)
    {
        this.numPages = numPages;
        this.citationStyle = citationStyle;
    }

    public string GetWritingInformation()
    {
        string studentName = GetStudentName(); // using public method to access private variable
        return $"Write a {numPages} page paper on {topic} using {citationStyle} style. Submit by {DateTime.Now}. Prepared by {studentName}.";
    }

    public string GetStudentName()
    {
        return citationStyle;
    }
}