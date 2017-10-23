//Your first task is to collect all the pieces of text into a single string and replace multiple whitespaces 
//(e.g. "       "), with a single one (" "). The important pieces of data are stored between special symbols 
//which are the following: a dollar sign ('$') with weight of 1, a percentage sign ('%') with weight of 2, 
//ampersand ('&') with weight of 3 and a single quote ('’') with weight of 4. You need to retrieve all non-empty 
//strings that are contained between two identical special symbols. Special symbols aren’t allowed inside 
//these strings! A special symbol can be part of only one string, e.g. in "$abc$def$" only the left string 
//should be captured ("$abc$"). Then, for each even symbol in the captured string (positions 0, 2, etc.), 
//you need to add the weight of the surrounding special symbol to the ASCII code of the current symbol. 
//For each odd symbol (positions 1, 3, etc.), you need to subtract the weight of the special symbol from the ASCII 
//code of the current symbol. When you’re done, just print all resulting strings on the console (on a single line, 
//separated by a space). That’s it! 

using System;
using System.Text;
using System.Text.RegularExpressions;

class TextTransformer
{
    static void Main()
    {
        string input = Console.ReadLine();
        StringBuilder allInput = new StringBuilder();

        while (input != "burp")
        {
            allInput.Append(input);
            input = Console.ReadLine();
        }

        string patternWhitespaces = @"\s+";
        string text = Regex.Replace(allInput.ToString(), patternWhitespaces, " ");

        string patternSpecialSymbols = @"([$%&'])([^$%&']+)\1";
        Regex regex = new Regex(patternSpecialSymbols);

        MatchCollection matches = regex.Matches(text);

        foreach (Match match in matches)
        {
            string output = match.Groups[2].Value;
            int weight = 0;

            switch (match.Groups[1].Value)
            {
                case "$":
                    weight = 1;
                    break;
                case "%":
                    weight = 2;
                        break;
                case "&":
                    weight = 3;
                        break;
                case "'":
                    weight = 4;
                        break;          
            }

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < output.Length; i++)
            {
                char resultSymbol;

                if (i %  2 == 0)
                {
                    resultSymbol = (char)(output[i] + weight);
                }
                else
                {
                    resultSymbol = (char)(output[i] - weight);
                }

                result.Append(resultSymbol);
            }

            Console.Write(result + " ");  
        }
    }   
}

