using System;
using System.Linq;

namespace ConsoleEF
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddEmployee();
            UpdateSalary();
            //DeleteEmployee();
        }
        static void AddEmployee()
        {
            using(var db = new EmployeeDBContext())
            {
                Employee employee = new Employee
                {
                    Designation = "Software Engineer",
                    Name = "Jaya AK",
                    Salary = 9999999999
                };
                db.Employees.Add(employee);
                int recordsInserted = db.SaveChanges();
                Console.WriteLine("Number of records inserted: " + recordsInserted);
                Console.ReadLine();
            }
        }

        static void UpdateSalary()
        {
            using(var db = new EmployeeDBContext())
            {
                Employee employee = db.Employees.Where(
                    emp => emp.EmployeeId == 4
                    ).FirstOrDefault();
                if(employee != null)
                {
                    employee.Salary = 10000000000000;
                    int recordsInserted = db.SaveChanges();
                    Console.WriteLine("Records Updated: " + recordsInserted);
                    Console.ReadLine();
                }
            }
        }


        static void DeleteEmployee()
        {
            using (var db = new EmployeeDBContext())
            {
                Employee employeeToBeDeleted = db.Employees.Where(
                    emp => emp.EmployeeId == 3
                    ).FirstOrDefault();
                if (employeeToBeDeleted != null)
                {
                    db.Entry(employeeToBeDeleted).State =
                        Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    int recordsInserted = db.SaveChanges();
                    Console.WriteLine("Records deleted: " + recordsInserted);
                    Console.ReadLine();
                }
            }
        }

    }
}
