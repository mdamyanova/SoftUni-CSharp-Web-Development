using System;
using System.Linq;
using System.Reflection;

namespace _01.HarvestingFields
{
    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var fields =
                typeof(HarvestingFields).GetFields(BindingFlags.Instance | BindingFlags.Public |
                                                   BindingFlags.NonPublic);
            FieldInfo[] gatheredFields = null;
            while (input != "HARVEST")
            {            
                switch (input)
                {
                    case "private":
                        gatheredFields = fields.Where(f => f.IsPrivate).ToArray();          
                        break;
                    case "protected":
                        gatheredFields = fields.Where(f => f.IsFamily).ToArray();
                        break;
                    case "public":
                        gatheredFields = fields.Where(f => f.IsPublic).ToArray();
                        break;
                    case "all":
                        gatheredFields = fields;
                        break;
                }

                var result =
                    gatheredFields.Select(f => $"{f.Attributes.ToString().ToLower()} {f.FieldType.Name} {f.Name}");
                Console.WriteLine(string.Join(Environment.NewLine, result).Replace("family", "protected"));
                input = Console.ReadLine();
            }         
        }
    }
}