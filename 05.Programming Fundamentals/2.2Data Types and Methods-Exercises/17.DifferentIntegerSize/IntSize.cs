using System;

namespace _17.DifferentIntegerSize
{
    using System.Text;

    public class IntSize
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            StringBuilder output = new StringBuilder();

            sbyte testSbyte;
            if (sbyte.TryParse(input, out testSbyte))
            {
                output.AppendLine("* sbyte");
            }

            byte testByte;
            if (byte.TryParse(input, out testByte))
            {
                output.AppendLine("* byte");
            }

            short testShort;
            if (short.TryParse(input, out testShort))
            {
                output.AppendLine("* short");
            }

            ushort testUshort;
            if (ushort.TryParse(input, out testUshort))
            {
                output.AppendLine("* ushort");
            }

            int testInt;
            if (int.TryParse(input, out testInt))
            {
                output.AppendLine("* int");
            }

            uint testUint;
            if (uint.TryParse(input, out testUint))
            {
                output.AppendLine("* uint");
            }

            long testLong;
            if (long.TryParse(input, out testLong))
            {
                output.AppendLine("* long");
            }

            if (output.Length > 0)
            {
                output.Insert(0, input + " can fit in:\n");
                Console.WriteLine(output.ToString());
            }
            else
            {
                Console.WriteLine("{0} can't fit in any type", input);
            }
        }
    }
}