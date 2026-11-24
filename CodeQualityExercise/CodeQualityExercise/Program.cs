
using System;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        List<int> grades = new List<int>() { 85, 40, 75, 90, 95, 100 };

        Console.WriteLine(Calculate(grades));
    }

    public static string Calculate(List<int> x)
    {
        if (x == null || x.Count == 0)
        {
            return "List is empty";
        }
        if (!ValidateGrades(x))
        {
            return "Invalid grades";
        }
        int total = CalculateTotal(x);
        double avg = (double)total / x.Count;
        return GetLetterGrade(avg);
    }

    static string GetLetterGrade(double avg)
    {
        return avg switch
        {
            >= 90 => "A",
            >= 80 => "B",
            >= 70 => "C",
            >= 60 => "D",
            _ => "F"
        };
    }

    static int CalculateTotal(List<int> x)
    {
        int total = 0;
        foreach (int grade in x)
        {
            total += grade;
        }
        return total;
    }

    static bool ValidateGrades(List<int> grades)
    {
        foreach (int grade in grades)
        {
            if (grade < 0 || grade > 100)
                return false;
        }

        return true;
    }
}