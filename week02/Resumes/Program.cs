using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._jobCompany = "Google";
        job1._startDate = 2027;
        job1._endDate = 2032;

        Job job2 = new Job();
        job2._jobTitle = "Senior Software Engineer";
        job2._jobCompany = "Microsoft";
        job2._startDate = 2033;
        job2._endDate = 2038;

        Resume myResume = new Resume();
        myResume._name = "Samuel Asian";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}