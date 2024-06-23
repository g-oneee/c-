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


public class EmpComparor : IComparer<Employee>
{
    public int Compare(Employee? x, Employee? y)
    {
        if (Convert.ToInt32(x.Salary) > Convert.ToInt32(y.Salary))
            return 1;
        else if (Convert.ToInt32(x.Salary) < Convert.ToInt32(y.Salary))
            return -1;
        return 1;
    }
}

public class Employee
{
    public int EmpId { get; set; }
    public string EmpName { get; set; }
    public DateOnly DOB { get; set; }
    public string MobileNumber { get; set; }
    public string Experience { get; set; }
    public string Salary { get; set; }
    public static EmpComparor empCom = new EmpComparor();
    public static SortedSet<Employee> SetOfEmployee = new SortedSet<Employee>(empCom);

    //y     m   d   h   m   s
    // DateTime date2 = new DateTime(2012, 12, 25, 10, 30, 50);

    public Employee(int empId, string empName, DateOnly dob, string mobileNumber, string experience, string salary)
    {
        EmpId = empId;
        EmpName = empName;
        DOB = dob;
        MobileNumber = mobileNumber;
        Experience = experience;
        Salary = salary;

        // Add the employee to the SortedSet
        SetOfEmployee.Add(this);
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
        // int.TryParse(Console.ReadLine(), out int n);
        // List<string> arr = new List<string>();
        // for (int i = 0; i < n; i++)
        // {
        //     arr.Add(Console.ReadLine());
        // }
        // arr.Sort(new StringLengthComparer());
        // foreach (string i in arr)
        // {
        //     System.Console.WriteLine(i);
        // }

        Employee emp1 = new Employee(1, "Alice", new DateOnly(1990, 1, 1), "1234567890", "5 years", "50000");
        Employee emp2 = new Employee(2, "Bob", new DateOnly(1985, 2, 2), "0987654321", "3 years", "45000");
        Employee emp3 = new Employee(3, "Charlie", new DateOnly(1988, 3, 3), "1112223333", "5 years", "55000");

        // Print the details of employees from the SortedSet
        foreach (var employee in Employee.SetOfEmployee)
        {
            Console.WriteLine($"EmpId: {employee.EmpId}, EmpName: {employee.EmpName}, DOB: {employee.DOB}, MobileNumber: {employee.MobileNumber}, Experience: {employee.Experience}, Salary: {employee.Salary}");
        }
        // Job job1 = new Job(1, "2", Job.JobType.User, "Incomplete", 1);
        // Job job2 = new Job(2, "3", Job.JobType.Processor, "Incomplete", 2);
        // Job job3 = new Job(3, "3", Job.JobType.Processor, "Incomplete", 3);
        // Job job4 = new Job(4, "3", Job.JobType.Processor, "Incomplete", -4);
        // Job job5 = new Job(5, "3", Job.JobType.Processor, "Incomplete", 5);
        // Job job6 = new Job(6, "3", Job.JobType.Processor, "Incomplete", 6);
        // // Job.RemoveJob(5);
        // Job.MarkGivenJobCompleted(5);
        // // System.Console.WriteLine(Job.GetTotalCompletedExecTime());
        // System.Console.WriteLine(Job.GetTotalPendingExecutionTime());
        // // Print the details of jobs from the SortedDictionary
        // foreach (var job in Job.ListOfJobs)
        // {
        //     Console.WriteLine($"Job Number: {job.Value.JobNumber}, Execution Time: {job.Value.ExecutionTime}, Type: {job.Value.Type}, Status: {job.Value.StatusOfCompletion}, Priority: {job.Value.Priority}, Removed: {job.Value.removed}");
        // }




    }
}