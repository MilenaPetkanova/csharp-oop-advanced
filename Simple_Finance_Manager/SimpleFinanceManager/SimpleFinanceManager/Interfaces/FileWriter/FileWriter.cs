using System;
using System.IO;


public class FileWriter : IWriter
{
    private const string FileName = "summary.txt";
    private const string ContentSeparator = "========================";
    private readonly string filePath = Path.Combine(Environment.CurrentDirectory, FileName);

    public void WriteLine(string message)
    {
        File.AppendAllText(this.filePath, $"{Environment.NewLine}{message}{Environment.NewLine}{ContentSeparator}{Environment.NewLine}");
    }
}