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
        /// --13. Write a query in SQL to display the 
        ///--job title, department name, full name(first and last name) of employee, and starting date for all the jobs which started on 
        ///--or after 1st January, 1993 and ending with on or before 2006-08-31 
        /// </summary>
        public void Exe13th()
        {
            var startDate = new DateTime(1993, 1, 1);
            var endDate = new DateTime(2006, 8, 31);

            var result = from e in _w3ResourceContext.HREmployees
                         join h in _w3ResourceContext.HRJobHistory
                              on e.EmployeeId equals h.EmployeeId
                         where h.StartDate >= startDate &&
                              h.EndDate <= endDate
                         select new
                         {
                             FullName = $"{e.FirstName} {e.LastName}",
                             h.StartDate,
                             e.JobId
                         };

            System.Console.WriteLine($"Count: {result.Count()}");
            foreach (var ele in result)
            {
                System.Console.WriteLine($"{ ele.FullName}, {ele.StartDate}, {ele.JobId}");
            }
        }

        /// <summary>
        /// 14. Write a query in SQL to display job title, full name (first and last name) of employee, and the difference 
        ///--between maximum salary for the job and salary of the employee.
        /// </summary>
        public void Exe14th()
        {
            var result = from e in _w3ResourceContext.HREmployees
                         from g in _w3ResourceContext.HRJobGrades
                         where e.Salary >= g.LowestSal && e.Salary <= g.HighestSal
                         select new
                         {
                             FullName = $"{e.FirstName} {e.LastName}",
                             e.JobId,
                             Difference = g.HighestSal - e.Salary
                         };

            System.Console.WriteLine($"Count: {result.Count()}");
            foreach (var ele in result)
            {
                System.Console.WriteLine($"{ ele.FullName}, {ele.JobId}, {ele.Difference}");
            }
        }

        /// <summary>
        /// 15. Write a query in SQL to display the name of the department, average salary and number of employees 
        ///--working in that department who got commission.
        /// </summary>
        public void Exe15th()
        {
            var aggregate = from e in _w3ResourceContext.HREmployees
                            group e by e.DepartmentId into que
                            select new
                            {
                                que.Key,
                                Count = que.Count(),
                                AvgSalary = que.Average(x => x.Salary)
                            };

            var result = from d in _w3ResourceContext.HRDepartments
                         join x in aggregate
                            on d.DepartmentId equals x.Key
                         select new
                         {
                             d.DepartmentName,
                             x.Count,
                             x.AvgSalary
                         };

            System.Console.WriteLine($"Count: {result.Count()}");
            foreach (var ele in result)
            {
                System.Console.WriteLine($"{ ele.DepartmentName}, {ele.Count}, {ele.AvgSalary}");
            }
        }

        /// <summary>
        /// 21. Write a query in SQL to display the country name, city, and number of those departments where at leaste 2 employees are working.
        /// </summary>
        public void Exe21th()
        {
            var agg = (from e in _w3ResourceContext.HREmployees
                       group e by e.DepartmentId into que
                       select new
                       {
                           que.Key,
                           Count = que.Count()
                       }).Where(x => x.Count >= 2);

            var result = from d in _w3ResourceContext.HRDepartments
                         join x in agg
                            on d.DepartmentId equals x.Key
                         join l in _w3ResourceContext.HRLocations
                             on d.LocationId equals l.LocationId
                         join c in _w3ResourceContext.HRCountries
                            on l.CountryId equals c.CountryId
                         select new
                         {
                             d.DepartmentName,
                             l.City,
                             c.CountryName
                         };

            System.Console.WriteLine($"Count: {result.Count()}");
            foreach (var ele in result)
            {
                System.Console.WriteLine($"{ ele.DepartmentName}, {ele.City}, {ele.CountryName}");
            }
        }

        /// <summary>
        /// 22. Write a query in SQL to display the department name, full name (first and last name) of manager, and their city.
        /// </summary>
        public void Exe22th()
        {
            var managers = from e in _w3ResourceContext.HREmployees
                           select e.ManagerId;

            var result = from e in _w3ResourceContext.HREmployees
                         where managers.ToList().Contains(e.EmployeeId)
                         join d in _w3ResourceContext.HRDepartments
                            on e.DepartmentId equals d.DepartmentId
                         join l in _w3ResourceContext.HRLocations
                            on d.LocationId equals l.LocationId
                         select new
                         {
                             FullName = $"{e.FirstName} {e.LastName}",
                             d.DepartmentName,
                             l.City
                         };

            System.Console.WriteLine($"Count: {result.Count()}");
            foreach (var ele in result)
            {
                System.Console.WriteLine($"{ ele.FullName}, {ele.DepartmentName}, {ele.City}");
            }
        }

        /// <summary>
        /// 24. Write a query in SQL to display the full name (first and last name), and salary
        ///--of those employees who working in any department located in Seatlle.
        /// </summary>
        public void Exe24th()
        {
            var result = from e in _w3ResourceContext.HREmployees
                         join d in _w3ResourceContext.HRDepartments
                            on e.DepartmentId equals d.DepartmentId
                         join l in _w3ResourceContext.HRLocations
                             on d.LocationId equals l.LocationId
                         where l.City == "Seattle"
                         select new
                         {
                             FullName = $"{e.FirstName} {e.LastName}",
                             e.Salary
                         };

            System.Console.WriteLine($"Count: {result.Count()}");
            foreach (var ele in result)
            {
                System.Console.WriteLine($"{ ele.FullName}, {ele.Salary}");
            }
        }

        /// <summary>
        /// 27. Write a query in SQL to display the full name (first and last name ) 
        ///--of employee with ID and name of the country presently where(s)he is working.
        /// </summary>
        public void Exe27th()
        {
            var result = from e in _w3ResourceContext.HREmployees
                         join d in _w3ResourceContext.HRDepartments
                            on e.DepartmentId equals d.DepartmentId
                         join l in _w3ResourceContext.HRLocations
                             on d.LocationId equals l.LocationId
                         join c in _w3ResourceContext.HRCountries
                             on l.CountryId equals c.CountryId
                         select new
                         {
                             FullName = $"{e.FirstName} {e.LastName}",
                             c.CountryId,
                             c.CountryName
                         };

            System.Console.WriteLine($"Count: {result.Count()}");
            foreach (var ele in result)
            {
                System.Console.WriteLine($"{ ele.FullName}, {ele.CountryId}, {ele.CountryName}");
            }
        }
    }
}
