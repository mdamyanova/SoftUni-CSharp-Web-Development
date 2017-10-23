//On the first input line you’ll be given some non-negative integer numbers separated 
//by whitespaces (one or more). On the following lines, until the "stop" command is received, 
//you’ll receive commands which will describe what you need to do. The commands will be in 
//format "[offset] [operation] [operand]". Offset will be a number which shows which element 
//you need to manipulate.You start with the element at position 0 and add the offset at each step.
//If you receive the command "2 * 2", this means you need to work with element at position 2 = 
//that is 0 (initial index) + 2 (offset). As the next command, you receive "-2 * 2", this means
//you need to operate on the element at index 0 = 2 (current index) + -2 (offset). If you receive 
//a positive offset and end up out of range, start at the beginning. The same applies for negative offsets; 
//if you end up with target index less than 0, start at the end of the array. 

using System;
using System.Linq;
using System.Numerics;

class ArraySlider
{
    static void Main()
    {
        BigInteger[] numbers =
            Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(BigInteger.Parse)
                .ToArray();

        string line = Console.ReadLine();
        int currentIndex = 0;

        while (line != "stop")
        {
            string[] lineArgs = line.Split(new char[] {' '}, 
                StringSplitOptions.RemoveEmptyEntries);
            int offset = int.Parse(lineArgs[0]) % numbers.Length;
            string operation = lineArgs[1];
            BigInteger operand = BigInteger.Parse(lineArgs[2]);

            if (offset < 0)
            {
                currentIndex = (currentIndex + offset + numbers.Length) % numbers.Length;
            }
            else
            {
                currentIndex = (currentIndex + offset) % numbers.Length;
            }

            ProcessCommand(numbers, currentIndex, operation, operand);

            line = Console.ReadLine();
        }

        Console.WriteLine("[{0}]", string.Join(", ", numbers));
    }

    private static void ProcessCommand(BigInteger[] numbers, int currentIndex, string operation, BigInteger operand)
    {
        switch (operation)
        {
            case "&":
                numbers[currentIndex] &= operand;
                break;
            case "|":
                numbers[currentIndex] |= operand;
                break;
            case "^":
                numbers[currentIndex] ^= operand;
                break;
            case "+":
                numbers[currentIndex] += operand;
                break;
            case "-":
                numbers[currentIndex] -= operand;            
                break;
            case "*":
                numbers[currentIndex] *= operand;
                break;
            case "/":
                numbers[currentIndex] /= operand;
                break;
        }
        if (numbers[currentIndex] < 0)
        {
            numbers[currentIndex] = 0;
        }
    }
}