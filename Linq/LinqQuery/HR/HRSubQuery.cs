using Linq.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Linq.LinqQuery.HR
{
    public class HRSubQuery
    {
        private readonly W3ResourceContext w3ResourceContext;

        public HRSubQuery(W3ResourceContext w3ResourceContext)
        {
            this.w3ResourceContext = w3ResourceContext;
        }

        /// <summary>
        /// --1. Write a query to display the name ( first name and last name ) 
        //for those employees who gets more salary than the employee whose ID is 163. 
        /// </summary>
        public void FirstExe()
        {
            var salary = from e in w3ResourceContext.HREmployees
                         where e.EmployeeId == 163
                         select e.Salary;

            var result = from e in w3ResourceContext.HREmployees
                         where e.Salary > salary.Single()
                         select new
                         {
                             Name = e.FirstName + " " + e.LastName
                         };

            System.Console.WriteLine($"{result.Count()}");
            foreach (var r in result)
            {
                System.Console.WriteLine($"{r.Name}");
            }
        }

        /// <summary>
        /// --3. Write a query to display the name ( first name and last name ),
        //--salary, department id for those employees who earn such amount of salary which
        //--is the smallest salary of any of the departments.
        /// </summary>
        public void ThirdExe()
        {
            var salary = from e in w3ResourceContext.HREmployees
                         group e by e.DepartmentId into que
                         select que.Min(x => x.Salary);

            var result = from e in w3ResourceContext.HREmployees
                         where salary.ToList().Contains(e.Salary)
                         select new
                         {
                             Name = e.FirstName + " " + e.LastName,
                             e.Salary,
                             e.DepartmentId
                         };

            foreach (var r in salary)
            {
                System.Console.WriteLine($"{r}");
            }

            System.Console.WriteLine($"{result.Count()}");
            foreach (var r in result)
            {
                System.Console.WriteLine($"{r.Name}, {r.Salary}, {r.DepartmentId}");
            }

        }

        /// <summary>
        /// --4. Write a query to display the employee id, employee name (first name and last name )
        //--for all employees who earn more than the average salary.
        /// </summary>
        public void FourthExe()
        {
            var salary = (from e in w3ResourceContext.HREmployees
                          select e.Salary
                          ).Average();

            var result = from e in w3ResourceContext.HREmployees
                         where e.Salary > salary
                         select new
                         {
                             Name = e.FirstName + " " + e.LastName,
                             e.Salary,
                             e.DepartmentId
                         };

            System.Console.WriteLine($"{result.Count()}");
            foreach (var r in result)
            {
                System.Console.WriteLine($"{r.Name}, {r.Salary}, {r.DepartmentId}");
            }
        }

        /// <summary>
        /// --5. Write a query to display the employee name ( first name and last name ),
        //--employee id and salary of all employees who report to Payam.
        /// </summary>
        public void FifthExe()
        {
            var managerId = from e in w3ResourceContext.HREmployees
                            where e.FirstName == "Payam"
                            select e.EmployeeId;

            var result = from e in w3ResourceContext.HREmployees
                         where e.ManagerId == managerId.Single()
                         select new
                         {
                             e.EmployeeId,
                             Name = $"{e.FirstName} {e.LastName}",
                             e.Salary
                         };

            System.Console.WriteLine($"{result.Count()}");
            foreach (var r in result)
            {
                System.Console.WriteLine($"{r.EmployeeId}, {r.Name}, {r.Salary}");
            }
        }

        /// <summary>
        /// --11. Write a query to display all the information of the employees who does not work
        //--in those departments where some employees works whose manager id within the range 100 and 200.
        /// </summary>
        public void EleventhExe()
        {
            var departments = (from e in w3ResourceContext.HREmployees
                               where e.ManagerId > 100 && e.ManagerId < 200
                               select e.DepartmentId).Distinct();

            var result = from e in w3ResourceContext.HREmployees
                         where !departments.ToList().Contains(e.DepartmentId)
                         select e;

            System.Console.WriteLine($"{result.Count()}");
            foreach (var r in result)
            {
                System.Console.WriteLine($"{r.EmployeeId}, {r.FirstName}, {r.LastName}, {r.Salary}, {r.DepartmentId}");
            }
        }

        /// <summary>
        ///12. Write a query to display all the information for those employees whose id is any id who earn the second highest salary.
        /// </summary>
        public void TwelvethExe()
        {
            var salary = (from e in w3ResourceContext.HREmployees
                          orderby e.Salary descending
                          select e.Salary)
                           .ToList()
                           .Skip(1)
                           .Take(1);

            var result = from e in w3ResourceContext.HREmployees
                         where e.Salary == salary.Single()
                         select e;

            System.Console.WriteLine($"{result.Count()}");
            foreach (var r in result)
            {
                System.Console.WriteLine($"{r.EmployeeId}, {r.FirstName}, {r.LastName}, {r.Salary}, {r.DepartmentId}");
            }
        }

        /// <summary>
        /// --13. Write a query to display the employee name( first name and last name ) and hiredate
        ///--for all employees in the same department as Clara.Exclude Clara.
        /// </summary>
        public void ThirteenthExe()
        {
            var department = from e in w3ResourceContext.HREmployees
                             where e.FirstName == "Clara"
                             select e.DepartmentId;

            var result = from e in w3ResourceContext.HREmployees
                         where e.DepartmentId == department.Single() &&
                                e.FirstName != "Clara"
                         select new
                         {
                             Name = $"{e.FirstName} {e.LastName}",
                             e.HireDate
                         };

            System.Console.WriteLine($"{result.Count()}");
            foreach (var r in result)
            {
                System.Console.WriteLine($"{r.Name} {r.HireDate}");
            }
        }

        /// <summary>
        //--15. Write a query to display the employee number, name( first name and last name ), and salary 
        //--for all employees who earn more than the average salary and who work in a department 
        //--with any employee with a J in their name.
        /// </summary>
        public void FifteenthExe()
        {
            var avr = (from e in w3ResourceContext.HREmployees
                       select e.Salary).Average();

            var jDepartments = from e in w3ResourceContext.HREmployees
                               where e.FirstName.StartsWith("J")
                               select e.DepartmentId;

            var result = from e in w3ResourceContext.HREmployees
                         where e.Salary > avr &&
                                jDepartments.Contains(e.DepartmentId)
                         select new
                         {
                             e.EmployeeId,
                             Name = $"{e.FirstName} {e.LastName}",
                             e.Salary
                         };

            System.Console.WriteLine($"{result.Count()}");
            foreach (var r in result)
            {
                System.Console.WriteLine($"{r.EmployeeId} {r.Name}, {r.Salary}");
            }
        }

        /// <summary>
        ///--16. Display the employee name(first name and last name ), employee id, and job title 
        ///--for all employees whose department location is Toronto.
        /// </summary>
        public void SixteenthExe()
        {
            var location = from l in w3ResourceContext.HRLocations
                           where l.City == "Toronto"
                           select l.LocationId;

            var department = from d in w3ResourceContext.HRDepartments
                             where d.LocationId == location.Single()
                             select d.DepartmentId;


            var result = from e in w3ResourceContext.HREmployees
                         where e.DepartmentId == department.Single()
                         select new
                         {
                             e.EmployeeId,
                             Name = $"{e.FirstName} {e.LastName}",
                             e.JobId
                         };

            System.Console.WriteLine($"{result.Count()}");
            foreach (var r in result)
            {
                System.Console.WriteLine($"{r.EmployeeId} {r.Name}, {r.JobId}");
            }
        }

        /// <summary>
        /// --18. Write a query to display the employee number, name( first name and last name ) and job title 
        ///--for all employees whose salary is greater than any salary of those employees whose job title is SA_MAN.
        ///--Exclude Job title SA_MAN.
        /// </summary>
        public void EighteenthExe()
        {
            var salary = (from e in w3ResourceContext.HREmployees
                          where e.JobId == "SA_MAN"
                          select e.Salary).Min();

            var result = from e in w3ResourceContext.HREmployees
                         where e.Salary > salary &&
                                e.JobId != "SA_MAN"
                         select new
                         {
                             e.EmployeeId,
                             Name = $"{e.FirstName} {e.LastName}",
                             e.JobId
                         };

            System.Console.WriteLine($"{result.Count()}");
            foreach (var r in result)
            {
                System.Console.WriteLine($"{r.EmployeeId} {r.Name}, {r.JobId}");
            }
        }
    }
}
