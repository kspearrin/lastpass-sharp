namespace CLI;

public static class Helpers
{
    public static string Prompt(string text)
    {
        Console.Write(text + ": ");
        var input = Console.ReadLine();
        return input == null ? "" : input.Trim();
    }
}
