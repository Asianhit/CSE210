public class Job
{
    public string _jobTitle;
    public string _jobCompany;
    public int _startDate;
    public int _endDate;

    public void Display()
    {
        Console.WriteLine($"{_jobTitle} at {_jobCompany} ({_startDate}-{_endDate})");
        Console.WriteLine("Designs, develops, tests, and maintains software applications.");
    }
}
