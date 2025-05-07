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
    /// <summary>
    /// Normal method call, passing the object as a parameter.
    /// </summary>
    /// <param name="obj"></param>
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
    
    /// <summary>
    /// Static method call, calling the method as extension method.
    /// Preferable
    /// </summary>
    /// <param name="obj"></param>
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
