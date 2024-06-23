using System;


public class Job
{
    public int JobNumber { get; set; }
    public string ExecutionTime { get; set; }
    public JobType Type { get; set; }

    public enum JobType
    {
        User,
        Processor
    }
    public string StatusOfCompletion { get; set; }
    public int Priority { get; set; }
    public bool removed { get; set; }
    public static SortedDictionary<int, Job> ListOfJobs = new SortedDictionary<int, Job>();

    //y     m   d   h   m   s
    // DateTime date2 = new DateTime(2012, 12, 25, 10, 30, 50);

    public Job(int jobNumber, string executionTime, JobType type, string statusOfCompletion, int priority)
    {
        JobNumber = jobNumber;
        ExecutionTime = executionTime;
        Type = type;
        StatusOfCompletion = statusOfCompletion;
        Priority = priority;
        removed = false;
        ListOfJobs.Add(priority, this);

    }
    public void AddJob(int jobNumber, string executionTime, JobType type, string statusOfCompletion, int priority)
    {
        Job jobb = new Job(jobNumber, executionTime, type, statusOfCompletion, priority);


        ListOfJobs.Add(priority, jobb);
    }

    public static void RemoveJob(int JobNumber)
    {
        // ListOfJobs.Remove(JobNumber);
        foreach (KeyValuePair<int, Job> i in ListOfJobs)
        {
            if (i.Value.JobNumber == JobNumber)
            {
                i.Value.removed = true;
            }
        }
    }
    public static int GetTotalPendingExecutionTime()
    {
        int ans = 0;
        foreach (KeyValuePair<int, Job> i in ListOfJobs)
        {
            if (i.Value.removed == false)
            {
                if (!i.Value.StatusOfCompletion.Equals("true"))
                {
                    ans += Convert.ToInt32(i.Value.ExecutionTime);
                }
            }
        }
        return ans;
    }
    public static List<Job> DisplayAllPendingJob()
    {
        List<Job> ans = new List<Job>();
        foreach (KeyValuePair<int, Job> i in ListOfJobs)
        {
            if (i.Value.removed == false)
            {
                if (!i.Value.StatusOfCompletion.Equals("completed"))
                {
                    ans.Add(i.Value);
                }
            }
        }
        return ans;
    }
    public static List<Job> DisplayAllCompletedJobs()
    {
        List<Job> ans = new List<Job>();
        foreach (KeyValuePair<int, Job> i in ListOfJobs)
        {
            if (i.Value.removed == false)
            {
                if (i.Value.StatusOfCompletion.Equals("completed"))
                {
                    ans.Add(i.Value);
                }
            }
        }
        return ans;
    }
    public static List<Job> DisplayAllSystemJob()
    {
        List<Job> ans = new List<Job>();
        foreach (KeyValuePair<int, Job> i in ListOfJobs)
        {
            if (i.Value.removed == false)
                if (i.Value.Type == JobType.Processor)
                {
                    ans.Add(i.Value);
                }
        }
        return ans;
    }
    public static void MarkGivenJobCompleted(int jobNumber)
    {
        foreach (KeyValuePair<int, Job> i in ListOfJobs)
        {
            if (i.Value.JobNumber == jobNumber)
            {
                i.Value.StatusOfCompletion = "completed";
            }
        }

        return;
    }
    public static void RemoveAllCompletedJob()
    {
        foreach (KeyValuePair<int, Job> i in ListOfJobs)
        {
            if (i.Value.StatusOfCompletion == "completed")
            {
                i.Value.removed = true;
            }
        }
        return;
    }
    public static int GetTotalCompletedExecTime()
    {
        int ans = 0;
        foreach (KeyValuePair<int, Job> i in ListOfJobs)
        {
            if (i.Value.StatusOfCompletion == "completed")
            {
                ans += Convert.ToInt32(i.Value.ExecutionTime);

            }
        }
        return ans;
    }
}


public class StringLengthComparer : IComparer<string>
{
    public int Compare(string x, string y)
    {
        if (x.Length > y.Length)
            return 1;
        else if (x.Length < y.Length)
            return -1;
        return 0;
    }
}


class Program
{

    public static void Main(string[] args)
    {
       


        Job job1 = new Job(1, "2", Job.JobType.User, "Incomplete", 1);
        Job job2 = new Job(2, "3", Job.JobType.Processor, "Incomplete", 2);
        Job job3 = new Job(3, "3", Job.JobType.Processor, "Incomplete", 3);
        Job job4 = new Job(4, "3", Job.JobType.Processor, "Incomplete", -4);
        Job job5 = new Job(5, "3", Job.JobType.Processor, "Incomplete", 5);
        Job job6 = new Job(6, "3", Job.JobType.Processor, "Incomplete", 6);
        // Job.RemoveJob(5);
        Job.MarkGivenJobCompleted(5);
        // System.Console.WriteLine(Job.GetTotalCompletedExecTime());
        System.Console.WriteLine(Job.GetTotalPendingExecutionTime());
        // Print the details of jobs from the SortedDictionary
        foreach (var job in Job.ListOfJobs)
        {
            Console.WriteLine($"Job Number: {job.Value.JobNumber}, Execution Time: {job.Value.ExecutionTime}, Type: {job.Value.Type}, Status: {job.Value.StatusOfCompletion}, Priority: {job.Value.Priority}, Removed: {job.Value.removed}");
        }




    }
}