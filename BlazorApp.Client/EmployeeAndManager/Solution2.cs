namespace BlazorApp.Client.EmployeeAndManager.Sol2;

public class Person
{
    public string Name { get; set; }
}

public class Employee : Person
{
}

public class Manager : Person
{
}

public static class Solution2
{
    public static void PrintName(Person obj)
    {
        Console.WriteLine($"Name: {obj.Name}");
    }
}