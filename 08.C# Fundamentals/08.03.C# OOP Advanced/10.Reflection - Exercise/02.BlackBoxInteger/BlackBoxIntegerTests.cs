using System;
using System.Linq;
using System.Reflection;

namespace _02.BlackBoxInteger
{
    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var type = typeof(BlackBoxInt);
            var blackBoxConstructor = type.GetConstructor(
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                null,
                Type.EmptyTypes,
                null);

            var number = (BlackBoxInt)blackBoxConstructor.Invoke(new object[] { });
            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            var fieldName = fields.FirstOrDefault().Name;

            var input = Console.ReadLine();

            while (input != "END")
            {
                var inputTokens = input.Split('_');
                var command = inputTokens[0];
                var num = int.Parse(inputTokens[1]);

                var method = type
                    .GetMethod(
                        command,
                        BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                method.Invoke(number, new object[] {num});

                var field = type
                    .GetField(
                        fieldName,
                        BindingFlags.Instance | BindingFlags.NonPublic);

                Console.WriteLine(field.GetValue(number));

                input = Console.ReadLine();
            }
        }
    }
}