using Linq.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Linq.LinqQuery.Inventory
{
    public class InventoryLinqSubQueries
    {
        private readonly W3ResourceContext w3ResourceContext;

        public InventoryLinqSubQueries(W3ResourceContext w3ResourceContext)
        {
            this.w3ResourceContext = w3ResourceContext;
        }

        /// <summary>
        /// 1. Write a query to display all the orders from the orders table issued by the salesman 'Paul Adam'.
        /// </summary>
        public void FirstExe()
        {
            var salesman = from s in w3ResourceContext.InventorySalesman
                           where s.Name == "Paul Adam"
                           select new
                           {
                               s.SalesmanId
                           };

            var result = from o in w3ResourceContext.InventoryOrders
                         where o.SalesmanId == salesman.Single().SalesmanId
                         select o;

            Console.WriteLine(result.Count());
            foreach (var r in result)
            {
                Console.WriteLine($"{r.OrdDate}, {r.OrdNo}, {r.CustomerId}");
            }
        }

        /// <summary>
        /// 3. Write a query to find all the orders issued against the salesman who may works for customer whose id is 3007.
        /// </summary>
        public void ThirdExe()
        {
            var salesmanId = from c in w3ResourceContext.InventoryCustomer
                             where c.CustomerId == 3007
                             select new
                             {
                                 c.SalesmanId
                             };

            var result = from o in w3ResourceContext.InventoryOrders
                         where o.SalesmanId == salesmanId.Single().SalesmanId
                         select o;


            Console.WriteLine(result.Count());
            foreach (var r in result)
            {
                Console.WriteLine($"{r.OrdDate}, {r.OrdNo}, {r.CustomerId}, {r.SalesmanId}");
            }
        }

        /// <summary>
        /// 4. Write a query to display all the orders which values are greater than the average order value for 10th October 2012.
        /// </summary>
        public void FourthExe()
        {
            var date = new DateTime(2012, 10, 10);

            var avg = (from c in w3ResourceContext.InventoryOrders
                       where DateTime.Compare(c.OrdDate.Value, date) == 0
                       group c by new { c.CustomerId, c.SalesmanId, c.PurchAmt } into a
                       select new
                       {
                           PurchAmt = a.Key.PurchAmt
                       }).Average(x => x.PurchAmt);

            var result = (from o in w3ResourceContext.InventoryOrders
                          where o.PurchAmt > avg
                          select o).ToList();

            Console.WriteLine(avg);
            Console.WriteLine(result.Count());
            foreach (var r in result)
            {
                Console.WriteLine($"{r.OrdDate}, {r.OrdNo}, {r.CustomerId}, {r.SalesmanId}");
            }
        }

        /// <summary>
        /// 8. Write a query to count the customers with grades above New York's average.
        /// </summary>
        public void EighthExe()
        {
            var avg = (from c in w3ResourceContext.InventoryCustomer
                       where c.City == "New York"
                       group c by new { c.CustomerId, c.Grade } into a
                       select new
                       {
                           Grade = a.Key.Grade
                       }).Average(x => x.Grade);

            var result = from c in w3ResourceContext.InventoryCustomer
                         where c.Grade > avg
                         group c by c.Grade into a
                         select new
                         {
                             a.Key,
                             Count = a.Count()
                         };

            foreach (var r in result)
            {
                Console.WriteLine($"{r.Key} {r.Count}");
            }
        }

        /// <summary>
        /// 9. Write a query to extract the data from the orders table for those salesman who earned the maximum commission
        /// </summary>
        public void NinethExe()
        {
            var salesman = from s in w3ResourceContext.InventorySalesman
                           orderby s.Commission descending
                           select s;

            var result = from o in w3ResourceContext.InventoryOrders
                         where o.SalesmanId == salesman.FirstOrDefault().SalesmanId
                         select o;

            Console.WriteLine(result.Count());
            foreach (var r in result)
            {
                Console.WriteLine($"{r.OrdDate}, {r.OrdNo}, {r.CustomerId}, {r.SalesmanId}");
            }
        }

        ////// <summary>
        ///16. Write a query to find the salesmen who have multiple customers.
        /// </summary>
        public void SixteenthExe()
        {
            var result = (from c in w3ResourceContext.InventoryCustomer
                          group c by c.SalesmanId into que
                          select new
                          {
                              que.Key,
                              Count = que.Count()
                          })
                         .Where(x => x.Count > 1);


            var salesman = from s in w3ResourceContext.InventorySalesman
                           join r in result
                                on s.SalesmanId equals r.Key
                           select new
                           {
                               s.SalesmanId,
                               s.Name,
                               s.Commission,
                               s.City,
                               r.Count
                           };


            foreach (var r in salesman)
            {
                Console.WriteLine($"{r.SalesmanId}, {r.Name}, {r.City}, {r.Commission}, {r.Count}");
            }
        }

        /// <summary>
        /// 17. Write a query to find all the salesmen who worked for only one customer.
        /// </summary>
        public void SeventeenthExe()
        {
            var result = from c in w3ResourceContext.InventoryCustomer
                         group c by c.SalesmanId into que
                         select new
                         {
                             que.Key,
                             Quantity = que.Count()
                         };

            var salesman = from s in w3ResourceContext.InventorySalesman
                           join r in result
                                on s.SalesmanId equals r.Key
                           where r.Quantity == 1
                           select s;

            foreach (var r in salesman)
            {
                Console.WriteLine($"{r.SalesmanId}, {r.Name}, {r.City}, {r.Commission}");
            }
        }

        /// <summary>
        /// 21. Write a query to display the salesmen which name are alphabetically lower than the name of the customers.
        /// </summary>
        public void TwentyFirstExe()
        {
            var salesman = from s in w3ResourceContext.InventorySalesman
                           join c in w3ResourceContext.InventoryCustomer
                              on s.SalesmanId equals c.SalesmanId
                           where String.Compare(s.Name, c.CustName) == 1
                           select s.SalesmanId;

            var result = from s in w3ResourceContext.InventorySalesman
                         where salesman.Contains(s.SalesmanId)
                         select s;


            foreach (var r in result)
            {
                Console.WriteLine($"{r.SalesmanId}, {r.Name}, {r.City}, {r.Commission}");
            }
        }

        /// <summary>
        /// ///23. Write a query to display all the orders that had
        //amounts that were greater than at least one of the orders on September 10th 2012.
        /// </summary>
        public void TwentyThirdExe()
        {
            var date = new DateTime(2012, 9, 10);

            var september = from o in w3ResourceContext.InventoryOrders
                            where o.OrdDate == date
                            select o.PurchAmt;

            var result = from o in w3ResourceContext.InventoryOrders
                         where o.PurchAmt > september.Min()
                         select o;

            foreach (var r in result)
            {
                Console.WriteLine($"{r.OrdDate}, {r.OrdNo}, {r.PurchAmt}");
            }
        }

        /// <summary>
        ///25. Write a query to display all orders with an amount smaller than any amount for a customer in London. (Using MAX)
        /// </summary>
        public void TwentyFifthExe()
        {
            var max = (from o in w3ResourceContext.InventoryOrders
                       join c in w3ResourceContext.InventoryCustomer
                             on o.CustomerId equals c.CustomerId
                       where c.City == "London"
                       select o.PurchAmt).Max();


            var result = from o in w3ResourceContext.InventoryOrders
                         where o.PurchAmt < max
                         select o;


            foreach (var r in result)
            {
                Console.WriteLine($"{r.OrdNo}, {r.PurchAmt}");
            }
        }

        /// <summary>
        /// 27. Write a query in sql to find the name, city, and the total sum of orders amount a salesman collects.
        //Salesman should belong to the cities where any of the customer belongs.
        /// </summary>
        public void TwentySeventhExe()
        {
            var orders = from s in w3ResourceContext.InventorySalesman
                         join o in w3ResourceContext.InventoryOrders
                             on s.SalesmanId equals o.SalesmanId
                         group o by s.SalesmanId into que
                         select new
                         {
                             que.Key,
                             Sum = que.Sum(x => x.PurchAmt)
                         };

            var cities = from c in w3ResourceContext.InventoryCustomer
                         select c.City;

            var result = (from s in w3ResourceContext.InventorySalesman
                         join x in orders
                             on s.SalesmanId equals x.Key
                         where cities.Contains(s.City)
                         select new
                         {
                             Salesman = s,
                             x.Sum
                         }).Distinct();

            Console.WriteLine($"Rawrr");

            foreach (var r in result)
            {
                Console.WriteLine($"{r.Salesman.Name}, {r.Salesman.City}, {r.Sum}");
            }
        }
    }

}

