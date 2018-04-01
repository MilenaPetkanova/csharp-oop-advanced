using System;

class Startup
{
    static void Main()
    {
        Spy spy = new Spy();
        string result = spy.AnalyzeAcessModifiers("Hacker");
        Console.WriteLine(result);
    }
}
