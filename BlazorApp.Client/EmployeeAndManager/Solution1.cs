namespace BlazorApp.Client.EmployeeAndManager.Sol1;

public class Employee
{
    public string Name { get; set; }
}

public class Manager
{
    public string Name { get; set; }
}

public static class Solution1
{
    public static void PrintName(object obj)
    {
        try
        {
            var name = obj.GetType().GetProperty("Name")!.GetValue(obj, null);
            
            Console.WriteLine($"Name: {name}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Property Name not found: {ex.Message}");
        }
    }
    
    public static void PrintNameStatic(this object obj)
    {
        try
        {
            var name = obj.GetType().GetProperty("Name")!.GetValue(obj, null);

            Console.WriteLine($"Name: {name}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Property Name not found: {ex.Message}");
        }
    }
}
