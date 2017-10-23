using System;
using System.Collections.Generic;
using System.Text;

namespace _03.NMS
{
    public class NMS
    {
        public static void Main()
        {           
            var line = Console.ReadLine();
            var stringBuilder = new StringBuilder();
            var messages = new List<string>();

            while (line != "---NMS SEND---")
            {
                stringBuilder.Append(line);
                line = Console.ReadLine();
            }

            var text = stringBuilder.ToString().Trim();
            stringBuilder.Clear();

            for (int i = 0; i < text.Length - 1; i++)
            {
                stringBuilder.Append(text[i]);

                if (char.ToUpper(text[i]) > char.ToUpper(text[i + 1]))
                {
                    messages.Add(stringBuilder.ToString());
                    stringBuilder.Clear();
                }
            }

            stringBuilder.Append(text[text.Length - 1]);
            messages.Add(stringBuilder.ToString());

            var delimiter = Console.ReadLine();
            Console.WriteLine(string.Join(delimiter, messages));
        }
    }
}