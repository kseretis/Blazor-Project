using BlazorApp.Client.EmployeeAndManager.Sol1;
using BlazorApp.Client.EmployeeAndManager.Sol2;

namespace BlazorApp.Client.EmployeeAndManager;

public static class CallSolutions
{
    public static void PrintNameSolution1()
    {
        var employee = new Sol1.Employee()
        {
            Name = "John Employee Doe"
        };
        
        var manager = new Sol1.Manager()
        {
            Name = "John Manager Doe"
        };
        
        // print with static extension
        employee.PrintNameStatic();
        manager.PrintNameStatic();
        
        // print with normal PrintName method
        Solution1.PrintName(employee);
        Solution1.PrintName(manager);
    }
    
    public static void PrintNameSolution2()
    {
        var employee = new Sol2.Employee()
        {
            Name = "John Employee Doe"
        };
        
        var manager = new Sol2.Manager()
        {
            Name = "John Manager Doe"
        };
        
        // print name using inheritance
        Solution2.PrintName(employee);
        Solution2.PrintName(manager);
        
        // we can print with static extension from the solution 1 too
        employee.PrintNameStatic();
        manager.PrintNameStatic();
        
        // or we can print with the normal PrintName method
        Solution1.PrintName(employee);
        Solution1.PrintName(manager);
    }
}