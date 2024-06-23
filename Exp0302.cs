using System;



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
        int.TryParse(Console.ReadLine(), out int n);
        List<string> arr = new List<string>();
        for (int i = 0; i < n; i++)
        {
            arr.Add(Console.ReadLine());
        }
        arr.Sort(new StringLengthComparer());
        foreach (string i in arr)
        {
            System.Console.WriteLine(i);
        }



    }
}