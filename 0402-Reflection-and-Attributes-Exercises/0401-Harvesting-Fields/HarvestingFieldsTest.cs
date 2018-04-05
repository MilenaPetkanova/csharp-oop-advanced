namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            var input = string.Empty;
            var allFields = typeof(HarvestingFields).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            while ((input = Console.ReadLine()) != "HARVEST")
            {
                Console.WriteLine(PrintAllFields(input, allFields));
                input = Console.ReadLine();
            }
        }
        public static string PrintAllFields(string input, FieldInfo[] allFields)
        {
            var builder = new StringBuilder();
            var fieldClass = typeof(HarvestingFields);

            if (input == "public")
            {
                var publicFields = allFields.Where(f => f.IsPublic);
                foreach (var item in allFields)
                {

                    builder.AppendLine($"public {item.FieldType.Name} {item.Name}");
                }

            }
            if (input == "private")
            {
                var privateFields = allFields.Where(f => f.IsPrivate);
                foreach (var item in privateFields)
                {
                    builder.AppendLine($"private {item.FieldType.Name} {item.Name}");
                }
            }
            if (input == "protected")
            {
                var protectedFields = allFields.Where(f => f.IsFamily);
                foreach (var item in protectedFields)
                {
                    builder.AppendLine($"protected {item.FieldType.Name} {item.Name}");
                }
            }
            return builder.ToString().TrimEnd();
        }
    }
}