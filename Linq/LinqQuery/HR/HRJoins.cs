using Linq.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Linq.LinqQuery.HR
{
    public class HRJoins
    {
        private readonly W3ResourceContext _w3ResourceContext;

        public HRJoins(W3ResourceContext w3ResourceContext)
        {
            _w3ResourceContext = w3ResourceContext;
        }


        /// <summary>
        /// 1. Write a query in SQL to display the first name, last name, department number, and department name for each employee.
        /// </summary>
        public void Exe1st()
        {
            var data = from e in _w3ResourceContext.HREmployees
                       join d in _w3ResourceContext.HRDepartments
                            on e.DepartmentId equals d.DepartmentId
                       select new
                       {
                           e.FirstName,
                           e.LastName,
                           d.DepartmentId,
                           d.DepartmentName
                       };

            System.Console.WriteLine($"Count: {data.Count()}");
            foreach (var ele in data)
            {
                System.Console.WriteLine($"{ ele.FirstName}, {ele.LastName}, {ele.DepartmentId}, {ele.DepartmentName}");
            }
        }

        /// <summary>
        /// 2. Write a query in SQL to display the first and last name, department, city, and state province for each employee.
        /// </summary>
        public void Exe2nd()
        {
            var result = from e in _w3ResourceContext.HREmployees
                         join d in _w3ResourceContext.HRDepartments
                                on e.DepartmentId equals d.DepartmentId
                         join l in _w3ResourceContext.HRLocations
                                 on d.LocationId equals l.LocationId
                         select new
                         {
                             e.FirstName,
                             e.LastName,
                             d.DepartmentName,
                             l.City,
                             l.StateProvince
                         };

            System.Console.WriteLine($"Count: {result.Count()}");
            foreach (var ele in result)
            {
                System.Console.WriteLine($"{ ele.FirstName}, {ele.LastName}, {ele.DepartmentName}, {ele.City}, {ele.StateProvince}");
            }
        }

        /// <summary>
        /// 3. Write a query in SQL to display the first name, last name, salary, and job grade for all employees.
        /// </summary>
        public void Exe3rd()
        {
            var result = from e in _w3ResourceContext.HREmployees
                         from g in _w3ResourceContext.HRJobGrades
                         where e.Salary >= g.LowestSal && e.Salary <= g.HighestSal
                         select new
                         {
                             e.FirstName,
                             e.LastName,
                             e.Salary,
                             g.GradeLevel
                         };

            System.Console.WriteLine($"Count: {result.Count()}");
            foreach (var ele in result)
            {
                System.Console.WriteLine($"{ ele.FirstName}, {ele.LastName}, {ele.GradeLevel}");
            }
        }

        /// <summary>
        /// 4. Write a query in SQL to display the first name, last name, department number and department name, 
        /// for all employees for departments 80 or 40.
        /// </summary>
        public void Exe4th()
        {
            var result = from e in _w3ResourceContext.HREmployees
                         join d in _w3ResourceContext.HRDepartments
                            on e.DepartmentId equals d.DepartmentId
                         where d.DepartmentId == 40 || d.DepartmentId == 80
                         select new
                         {
                             e.FirstName,
                             e.LastName,
                             d.DepartmentId,
                             d.DepartmentName
                         };

            System.Console.WriteLine($"Count: {result.Count()}");
            foreach (var ele in result)
            {
                System.Console.WriteLine($"{ ele.FirstName}, {ele.LastName}, {ele.DepartmentId}, {ele.DepartmentName}");
            }
        }

        /// <summary>
        /// 5. Write a query in SQL to display those employees who contain a letter m to their first name 
        /// and also display their last name, department, city, and state province.
        /// </summary>
        public void Exe5th()
        {
            var result = from e in _w3ResourceContext.HREmployees
                         where e.FirstName.StartsWith("M")
                         join d in _w3ResourceContext.HRDepartments
                            on e.DepartmentId equals d.DepartmentId
                         join c in _w3ResourceContext.HRLocations
                             on d.LocationId equals c.LocationId
                         select new
                         {
                             e.FirstName,
                             e.LastName,
                             d.DepartmentName,
                             c.City,
                             c.StateProvince
                         };

            System.Console.WriteLine($"Count: {result.Count()}");
            foreach (var ele in result)
            {
                System.Console.WriteLine($"{ ele.FirstName}, {ele.LastName}, {ele.DepartmentName}, {ele.City}, {ele.StateProvince}");
            }
        }


        /// <summary>
        /// 6. Write a query in SQL to display all departments where are hire  10 and more employees .
        /// </summary>
        public void Exe6()
        {
            var data = (from e in _w3ResourceContext.HREmployees
                        group e by e.DepartmentId into que
                        select new
                        {
                            que.Key,
                            Count = que.Count()
                        }).Where(x => x.Count >= 10);

            var result = from d in _w3ResourceContext.HRDepartments
                         join x in data
                            on d.DepartmentId equals x.Key
                         select new
                         {
                             d,
                             x.Count
                         };

            System.Console.WriteLine($"Count: {result.Count()}");
            foreach (var ele in result)
            {
                System.Console.WriteLine($"{ ele.d.DepartmentId}, {ele.d.DepartmentName}, {ele.Count}");
            }
        }

        /// <summary>
        /// 9. Write a query in SQL to display the department name, city, and state province for each department.
        /// </summary>
        public void Exe9th()
        {
            var result = from d in _w3ResourceContext.HRDepartments
                         join l in _w3ResourceContext.HRLocations
                            on d.LocationId equals l.LocationId
                         select new
                         {
                             d.DepartmentName,
                             l.City,
                             l.StateProvince
                         };

            System.Console.WriteLine($"Count: {result.Count()}");
            foreach (var ele in result)
            {
                System.Console.WriteLine($"{ ele.DepartmentName}, {ele.City}, {ele.StateProvince}");
            }
        }

        /// <summary>
        /// 12. Write a query in SQL to display the first name, last name, and department number for those employees who works 
        /// in the same department as the employee who holds the last name as Taylor.
        /// </summary>
        public void Exe12th()
        {
            var taylor = (from e in _w3ResourceContext.HREmployees
                         where e.LastName == "Taylor"
                         select e.DepartmentId)
                         .ToList();

            var result = from e in _w3ResourceContext.HREmployees
                         where taylor.Contains(e.DepartmentId)
                            && e.LastName != "Taylor"
                         join d in _w3ResourceContext.HRDepartments
                             on e.DepartmentId equals d.DepartmentId
                         select new
                         {
                             e.FirstName,
                             e.LastName,
                             d.DepartmentName
                         };

            System.Console.WriteLine($"Count: {result.Count()}");
            foreach (var ele in result)
            {
                System.Console.WriteLine($"{ ele.FirstName}, {ele.LastName}, {ele.DepartmentName}");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Exe()
        {

        }
    }
}
