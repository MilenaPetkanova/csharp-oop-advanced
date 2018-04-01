using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
    {
        Type classType = Type.GetType(investigatedClass);
        FieldInfo[] classFields = classType.GetFields(
            BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

        Object classInctance = Activator.CreateInstance(classType, new object[] { });

        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"Class under investigation: {investigatedClass}");

        foreach (var field in classFields.Where(f => requestedFields.Contains(f.Name)))
        {
            stringBuilder.AppendLine($"{field.Name} = {field.GetValue(classInctance)}");
        }

        return stringBuilder.ToString().Trim();
    }
}