using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string AnalyzeAcessModifiers(string className)
    {
        StringBuilder result = new StringBuilder();

        Type classType = Type.GetType(className);

        FieldInfo[] publicFields = classType.GetFields(
            BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public);
        MethodInfo[] privateMethods = classType.GetMethods(
            BindingFlags.Instance | BindingFlags.NonPublic);
        MethodInfo[] publicMethods = classType.GetMethods(
            BindingFlags.Instance | BindingFlags.Public);
        
        foreach (var field in publicFields)
        {
            result.AppendLine($"{field.Name} must be private!");
        }
        foreach (var privateGetter in privateMethods.Where(m => m.Name.StartsWith("get")))
        {
            result.AppendLine($"{privateGetter.Name} have to be public!");
        }
        foreach (var publicSetter in publicMethods.Where(m => m.Name.StartsWith("set")))
        {
            result.AppendLine($"{publicSetter.Name} have to be private!");
        }

        return result.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {

        var classType = Type.GetType(className);

        var privateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        var result = new StringBuilder();

        result.AppendLine($"All Private Methods of Class: {className}");
        result.AppendLine($"Base Class: {classType.BaseType.Name}");

        foreach (var privateMethod in privateMethods)
        {
            result.AppendLine(privateMethod.Name);
        }

        return result.ToString().Trim();
    }
}