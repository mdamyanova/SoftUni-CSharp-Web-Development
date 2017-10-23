//Write a program to extract all email addresses from a given text. 
//The text comes at the only input line. Print the emails on the console, 
//each at a separate line. Emails are considered to be in format <user>@<host>, where: 
//•	<user> is a sequence of letters and digits, where '.', '-' and '_' can appear 
//between them. Examples of valid users: "stephan", "mike03", "s.johnson", "st_steward", 
//"softuni-bulgaria", "12345". Examples of invalid users: ''--123", ".....", "nakov_-", 
//"_steve", ".info". 
//•	<host> is a sequence of at least two words, separated by dots '.'. Each word is 
//sequence of letters and can have hyphens '-' between the letters. Examples of hosts: 
//"softuni.bg", "software-university.com", "intoprogramming.info", "mail.softuni.org". 
//Examples of invalid hosts: "helloworld", ".unknown.soft.", "invalid-host-", "invalid-". 

using System;
using System.Text.RegularExpressions;

class ExtractEmails
{
    static void Main()
    {
        string input = Console.ReadLine();

        string pattern = @"(?<=\s|^)([a-z0-9]+(?:[_.-][a-z0-9]+)*@[a-z]+\-?[a-z]+(?:\.[a-z]+)+)\b";
        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(input);

        foreach (Match item in matches)
        {
            Console.WriteLine(item.Groups[0]);
        }
    }
}

