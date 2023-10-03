using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {

        List<Employee> employees = new List<Employee>
        {
            new Employee { EmpId = 1, FName = "John", LName = "Doe", Email = "john@example.com" },
            new Employee { EmpId = 2, FName = "Alice", LName = "Smith", Email = "alice@example.com" },
            new Employee { EmpId = 3, FName = "Bob", LName = "Johnson", Email = "bob@example.com" },
            new Employee { EmpId = 4, FName = "Alice", LName = "Smith", Email = "alice@example.com" },
            new Employee { EmpId = 5, FName = "David", LName = "Lee", Email = "david@example.com" },
        };
        List<Salary> salaries = new List<Salary>
        {
            new Salary { SalaryId = 1, EmpId = 1, SalaryAmount = 60000 },
            new Salary { SalaryId = 2, EmpId = 2, SalaryAmount = 55000 },
            new Salary { SalaryId = 3, EmpId = 3, SalaryAmount = 70000 },
            new Salary { SalaryId = 4, EmpId = 4, SalaryAmount = 60000 },
            new Salary { SalaryId = 5, EmpId = 5, SalaryAmount = 65000 },
        };


        ///////////   PROJECTION METHODS
        //+++++++++++++++++++    Select *****************************

        // Simple Select query & method
        var basicquery=(from emp in employees
                       select emp).ToList();

        var basicmethod = employees.ToList();
        foreach(var emp in basicmethod)
        {
            Console.WriteLine($"EmpId: " + emp.EmpId + "Employee Name: " + emp.FName);
        }






        // 2
        var query1= (from emp in employees
                     select emp.EmpId).ToList();

        var method1 = employees.Select(a => a.EmpId).ToList();
        foreach (var emp in method1)
        {
            Console.WriteLine($"EmpId: " + emp);
        }





        //3

        var query2=(from emp in employees
                    select new Employee()
                    {
                        EmpId = emp.EmpId,
                        FName = emp.FName,
                        LName = emp.LName
                    }).ToList();
        var method2=employees.Select(emp => new Employee()
        {
            EmpId = emp.EmpId,
            FName = emp.FName,
            LName = emp.LName

        }).ToList();
        foreach (var emp in method2)
        {
            Console.WriteLine($"EmpId: " + emp.EmpId+" FName: "+emp.FName+" LName: "+emp.LName);
        }



        //+++++++++++++++++++    Select Many*****************************




        /*var thirdHighestSalary = salaries
            .OrderByDescending(s => s.SalaryAmount)
            .Distinct() 
            .Skip(2) 
            .FirstOrDefault();

        if (thirdHighestSalary != null)
        {
            Console.WriteLine($"3rd Highest Salary Employee:");
            var employee = employees.FirstOrDefault(e => e.EmpId == thirdHighestSalary.EmpId);
            Console.WriteLine($"Name: {employee?.FName}");
            Console.WriteLine($"Salary: {thirdHighestSalary.SalaryAmount}");
        }
        else
        {
            Console.WriteLine("No 3rd highest salary found.");
        }

        var duplicateEmployees = employees
            .GroupBy(e => new { e.FName, e.Email })
            .Where(g => g.Count() > 1)
            .SelectMany(g => g);

        if (duplicateEmployees.Any())
        {
            Console.WriteLine("\nDuplicate Employees:");
            foreach (var duplicate in duplicateEmployees)
            {
                Console.WriteLine($"Name: {duplicate.FName}, Email: {duplicate.Email}");
            }
        }
        else
        {
            Console.WriteLine("\nNo duplicate employees found.");
        }

        var salary = from sal in salaries
                     where sal.EmpId > 2
                     select sal.SalaryAmount;





        foreach (var amount in salary)
        {
            Console.WriteLine(amount);
        }

        var methodsalary = salaries.Where(a => a.EmpId > 2);
        foreach (var amount in methodsalary)
        {
            Console.WriteLine(amount.SalaryAmount);
        }

        IQueryable<Salary> salaries1=salaries.AsQueryable().Where(a=>a.EmpId > 2);
        Console.WriteLine("Iquerable: ");
        foreach (var amount in salaries1)
        {
            Console.WriteLine(amount.SalaryAmount);
        }*/
    }
}

class Employee
{
    public int EmpId { get; set; }
    public string FName { get; set; }
    public string LName { get; set; }
    public string Email { get; set; }
}

class Salary
{
    public int SalaryId { get; set; }
    public int EmpId { get; set; }
    public decimal SalaryAmount { get; set; }
}
