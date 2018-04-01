using System.Linq;
using System.Reflection;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        var classType = typeof(Startup);
        var methods = classType.GetMethods(
            BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

        foreach (var methodInfo in methods)
        {
            if (methodInfo.CustomAttributes.Any(n => n.AttributeType == typeof(SoftUniAttribute)))
            {
                var attrs = methodInfo.GetCustomAttributes<SoftUniAttribute>();

                foreach (SoftUniAttribute attr in attrs)
                {
                    System.Console.WriteLine($"{methodInfo.Name} is written by {attr.Name}");
                }
            }
        }
    }
}
