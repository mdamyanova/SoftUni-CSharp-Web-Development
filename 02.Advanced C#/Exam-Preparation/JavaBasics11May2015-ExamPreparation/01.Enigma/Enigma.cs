//You are given n lines of encrypted messages.The messages will contain ASCII characters.
//In each message, only the Latin letters and special characters will be encrypted. 
//The numbers and whitespace will not be encrypted. Your task is to write a program to decrypt
//the messages. The formula for the decrypting each letter is X = k + m, where X is the ASCII 
//code of the decrypted letter, k is the ASCII code of the encrypted character and m is the 
//integer half of the length of the input line, without the numbers and whitespace. (Hint: length()/2)

using System;
using System.Text;

internal class Enigma
{
    private static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int countLines = 0;
        string encryptedMessage = Console.ReadLine();
        while (countLines != n)
        {
            string[] splitAndWithoutWhitespaces = encryptedMessage.Split(new char[] {' '},
                StringSplitOptions.RemoveEmptyEntries);
            string result = string.Join("", splitAndWithoutWhitespaces);
            int countLength = 0;

            foreach (char letter in result)
            {
                if (!char.IsNumber(letter))
                {
                    countLength++;
                }
            }

            StringBuilder decryptedMessage = new StringBuilder();
            foreach (char letter in encryptedMessage)
            {
                if (char.IsWhiteSpace(letter) || char.IsNumber(letter))
                {
                    decryptedMessage.Append(letter);
                }
                else
                {
                    decryptedMessage.Append((char) (letter + ((countLength))/2));
                }
            }

            Console.WriteLine(decryptedMessage.ToString());
            countLines++;
            encryptedMessage = Console.ReadLine();
        }
    }
}