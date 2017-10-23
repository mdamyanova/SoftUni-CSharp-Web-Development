//Write a program that replaces in a HTML document given as string all 
//the tags <a href=…>…</a> with corresponding tags [URL href=…]…[/URL]. 
//Print the result on the console. 

using System;
using System.Text.RegularExpressions;

class ReplaceTag
{
    static void Main()
    {
        string input = @"<ul>
 <li>
  <a href=http://softuni.bg>SoftUni</a>
 </li>
</ul>";

        string pattern = @"<a?<link>(\shref=.+)>?<name>(.+)<\/a>";
        
        string replaced = Regex.Replace(input, pattern, @"[URL$link]$name[/URL]");
        Console.WriteLine(replaced);

    }
}


