//Write a program that reads a list of student grade entries and prints
//the average grade of every subject for each student.

using System;
using System.Collections.Generic;
using System.Linq;

class SchoolSystem
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        var data = new SortedDictionary<string, SortedDictionary<string, List<double>>>();

        var result = new SortedDictionary<string, SortedSet<string>>();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            string fullname = input[0] + " " + input[1];
            string subject = input[2];
            int score = int.Parse(input[3]);

            if (!data.ContainsKey(fullname))
            {
                var studentData = new SortedDictionary<string, List<double>>();
                List<double> scores = new List<double>();
                scores.Add(score);
                studentData.Add(subject, scores);
                data.Add(fullname, studentData); //add all info in the main dictionary

            }

            else if(data.ContainsKey(fullname))
            {
                if (!data[fullname].ContainsKey(subject))
                {
                    List<double> scores = new List<double>();
                    scores.Add(score);
                    data[fullname].Add(subject, scores);
                }
                else
                {
                    data[fullname][subject].Add(score);
                }
            }
        }

        foreach (var pair in data)
        {
            SortedSet<string> infoSubject = new SortedSet<string>();

            foreach (var infoStudent in pair.Value)
            {
                string averageScore = String.Format(("{0} - {1:F2}"), 
                    infoStudent.Key, 
                    infoStudent.Value.Average());;

                infoSubject.Add(averageScore);
            }

            result.Add(pair.Key, infoSubject);
        }

        foreach (var pair in result)
        {
            string infoStudent = string.Join(", ", pair.Value);
            Console.WriteLine("{0}: [{1}]", pair.Key, infoStudent);
        }
    }
}
