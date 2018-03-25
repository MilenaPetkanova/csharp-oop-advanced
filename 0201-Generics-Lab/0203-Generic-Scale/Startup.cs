public class Startup
{
    static void Main()
    {
        var intScale = new Scale<int>(2, 2);
        var heavierInt = intScale.GetHeavier();

        var stringScale = new Scale<string>("mena", "sami");
        var heavierString = stringScale.GetHeavier();
    }
}
