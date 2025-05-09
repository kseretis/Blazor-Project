namespace BlazorApp.Client.EmployeeAndManager.Sol3;

public interface IPerson
{
    string Name { get; set; }
}

public class Employee : IPerson
{
    public string Name { get; set; }
}

public class Manager : IPerson
{
    public string Name { get; set; }
}

public class Solution3
{
    public static void PrintName(IPerson person)
    {
        Console.WriteLine($"Name: {person.Name}");
    }
}