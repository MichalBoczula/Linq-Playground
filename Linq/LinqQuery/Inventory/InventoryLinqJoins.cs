using Linq.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq.LinqQuery.Inventory
{
    public class InventoryLinqJoins
    {

        private readonly W3ResourceContext dbContext;

        public InventoryLinqJoins(W3ResourceContext dbContext)
        {
            this.dbContext = dbContext;
        }


        /// <summary>
        /// 1. Write a SQL statement to prepare a list with salesman name,
        /// customer name and their cities for the salesmen and customer who belongs to the same city.
        /// </summary>
        public void FirstExe()
        {
            var list = from s in dbContext.InventorySalesman
                       join c in dbContext.InventoryCustomer
                            on s.SalesmanId equals c.SalesmanId
                       where s.City == c.City
                       select new
                       {
                           SName = s.Name,
                           CName = c.CustName,
                           City = s.City
                       };

            Console.WriteLine($"Result count: { list.Count()}");
            foreach (var ele in list)
            {
                Console.WriteLine($"{ele.SName} : {ele.CName} : {ele.City}");
            }
        }

        /// <summary>
        /// 2. Write a SQL statement to make a list with order no, purchase amount, customer name and their 
        //cities for those orders which order amount between 500 and 2000.
        /// </summary>
        public void SecondExe()
        {
            var list = from ord in dbContext.InventoryOrders
                       join cus in dbContext.InventoryCustomer
                            on ord.CustomerId equals cus.CustomerId
                       where ord.PurchAmt > 500 && ord.PurchAmt < 2000
                       select new
                       {
                           CName = cus.CustName,
                           City = cus.City,
                           OrdNo = ord.OrdNo,
                           PurchAmt = ord.PurchAmt
                       };
            Console.WriteLine($"Result count: { list.Count()}");
            foreach (var ele in list)
            {
                Console.WriteLine($"{ele.CName} : {ele.City} : {ele.OrdNo} : {ele.PurchAmt}");
            }
        }

        /// <summary>
        /// 3. Write a SQL statement to know which salesman are working for which customer.
        /// </summary>
        public void ThirdExe()
        {
            var list = from sal in dbContext.InventorySalesman
                       join cus in dbContext.InventoryCustomer
                            on sal.SalesmanId equals cus.SalesmanId
                       select new
                       {
                           sal.Name,
                           cus.CustName
                       };
            Console.WriteLine($"Result count: { list.Count()}");
            foreach (var ele in list)
            {
                Console.WriteLine($"{ele.Name} : {ele.CustName}");
            }
        }

        /// <summary>
        /// 4. Write a SQL statement to find the list of customers who appointed a salesman for their
        //jobs who gets a commission from the company is more than 12%.
        /// </summary>
        public void FourthExe()
        {
            var list = from cus in dbContext.InventoryCustomer
                       join sal in dbContext.InventorySalesman
                            on cus.SalesmanId equals sal.SalesmanId
                       where sal.Commission > 0.12m
                       select new
                       {
                           sal.Name,
                           cus.CustName,
                           sal.Commission
                       };

            Console.WriteLine($"Result count: { list.Count()}");
            foreach (var ele in list)
            {
                Console.WriteLine($"{ele.Name} : {ele.Commission} : {ele.CustName}");
            }

        }

        /// <summary>
        ///5.  Write a SQL statement to find the list of customers who appointed a salesman for their jobs who does not
        //live in the same city where their customer lives, and gets a commission is above 12%
        /// </summary>
        public void FifthExe()
        {
            var list = from cus in dbContext.InventoryCustomer
                       join sal in dbContext.InventorySalesman
                            on cus.SalesmanId equals sal.SalesmanId
                       where cus.City != sal.City &&
                       sal.Commission > 0.12m
                       select new
                       {
                           cus.CustName,
                           sal.Name,
                           sal.City,
                           sal.Commission
                       };

            Console.WriteLine($"Result count: { list.Count()}");
            foreach (var ele in list)
            {
                Console.WriteLine($"{ele.Name} : {ele.Commission} : {ele.CustName} : {ele.City}");
            }
        }

        /// <summary>
        ///  Write a SQL statement to find the details of a order i.e. order number, order date, amount of order, 
        //which customer gives the order and which salesman works for that customer and how much commission he gets for an order.
        /// </summary>
        public void SixthExe()
        {
            var list = from ord in dbContext.InventoryOrders
                       join cus in dbContext.InventoryCustomer
                            on ord.CustomerId equals cus.CustomerId
                       join sal in dbContext.InventorySalesman
                            on ord.SalesmanId equals sal.SalesmanId
                       select new
                       {
                           sal.Name,
                           cus.CustName,
                           ord.OrdNo,
                           OrdDate = $"{ord.OrdDate.Value.Day}/{ord.OrdDate.Value.Month}/{ord.OrdDate.Value.Year}",
                           sal.Commission
                       };

            Console.WriteLine($"Result count: { list.Count()}");
            foreach (var ele in list)
            {
                Console.WriteLine($"{ele.Name}: {ele.Commission} : {ele.CustName} : {ele.OrdNo}  : {ele.OrdDate}");
            }
        }

        /// <summary>
        /// 7. Write a SQL statement to make a join on the tables salesman, customer and orders in such a form that the same
        //column of each table will appear once and only the relational rows will come.
        /// </summary>
        public void SeventhExe()
        {
            var list = from ord in dbContext.InventoryOrders
                       join cus in dbContext.InventoryCustomer
                            on ord.CustomerId equals cus.CustomerId
                       join sal in dbContext.InventorySalesman
                            on ord.SalesmanId equals sal.SalesmanId
                       select new
                       {
                           sal.Name,
                           cus.CustName,
                           ord.OrdNo,
                           OrdDate = $"{ord.OrdDate.Value.Day}/{ord.OrdDate.Value.Month}/{ord.OrdDate.Value.Year}"
                       };

            Console.WriteLine($"Result count: { list.Count()}");
            foreach (var ele in list)
            {
                Console.WriteLine($"{ele.Name} : {ele.CustName} : {ele.OrdNo}  : {ele.OrdDate}");
            }
        }

        /// <summary>
        /// 8. Write a SQL statement to make a list in ascending order for the customer
        //who works either through a salesman or by own.
        /// </summary>
        public void EighthExe()
        {
            var list = from cus in dbContext.InventoryCustomer
                       join sal in dbContext.InventorySalesman
                            on cus.SalesmanId equals sal.SalesmanId
                       orderby cus.CustomerId
                       select new
                       {
                           cus.CustName,
                           sal.Name
                       };

            Console.WriteLine($"Result count: { list.Count()}");
            foreach (var ele in list)
            {
                Console.WriteLine($"{ele.Name} : {ele.CustName}");
            }
        }

        /// <summary>
        /// 11. Write a SQL statement to make a report with customer name, city, order number, order date, order amount
        //salesman name and commission to find that either any of the existing customers have
        //placed no order or placed one or more orders by their salesman or by own.   
        /// </summary>
        public void EleventhExe()
        {
            var list = dbContext.InventoryCustomer.Join(
                dbContext.InventorySalesman,
                cus => cus.SalesmanId,
                sal => sal.SalesmanId,
                (cus, sal) => new
                {
                    Customer = cus,
                    Salesman = sal
                })
                .Join(
                    dbContext.InventoryOrders,
                    cus => cus.Customer.CustomerId,
                    ord => ord.CustomerId,
                    (cus, ord) => new
                    {
                        cus,
                        ord
                    })
                .Select(result => new
                {
                    result.cus.Customer.CustName,
                    result.cus.Salesman.City,
                    result.cus.Salesman.Name,
                    result.ord.PurchAmt,
                    result.ord.OrdDate,
                    result.ord.OrdNo
                })
                .OrderBy(x => x.CustName);

            Console.WriteLine($"Result count: { list.Count()}");
            foreach (var ele in list)
            {
                Console.WriteLine($"{ele.Name} : {ele.CustName} : {ele.City} : {ele.PurchAmt} : {ele.OrdDate} : {ele.OrdNo}");
            }
        }

        /// <summary>
        /// 14. Write a SQL statement to make a list for the salesmen who either work for one or more customers or
        //yet to join any of the customer.The customer may have placed, either one or more orders on or
        //above order amount 2000 and must have a grade, or he may not have placed any order to the associated supplier.
        /// </summary>
        public void FourteenthExe()
        {
            var list = dbContext.InventorySalesman.Join(
                dbContext.InventoryCustomer,
                sal => sal.SalesmanId,
                cus => cus.SalesmanId,
                (sal, cus) => new
                {
                    sal,
                    cus
                })
                .Join(
                    dbContext.InventoryOrders,
                    result => result.cus.CustomerId,
                    ord => ord.CustomerId,
                    (result, ord) => new
                    {
                        result,
                        ord
                    })
                .Select(obj => new
                {
                    obj.result.cus,
                    obj.result.sal,
                    obj.ord
                })
                .Where(x => x.ord.PurchAmt > 2000 &&
                    x.cus.Grade != null);

            Console.WriteLine($"Result count: { list.Count()}");
            foreach (var ele in list)
            {
                Console.WriteLine($"{ele.cus.CustName} : {ele.sal.Name} : {ele.ord.OrdNo} : {ele.ord.OrdDate} : {ele.ord.PurchAmt}");
            }
        }

        public void TestWithAggragation()
        {
            var list = from o in dbContext.InventoryOrders
                       group o by o.CustomerId into res
                       select new
                       {
                           res.Key,
                           Count = res.Count()
                       };

            var data = from c in dbContext.InventoryCustomer
                       join l in list
                            on c.CustomerId equals l.Key
                       join s in dbContext.InventorySalesman
                           on c.SalesmanId equals s.SalesmanId
                       select new
                       {
                           Name = c.CustName,
                           Id = c.CustomerId,
                           City = c.City,
                           OrdersNum = l.Count,
                           SName = s.Name,
                           SCity = s.City,
                           Commission = s.Commission
                       };


            //Second way but too much code, Aggregation funciton in
            //var data2 = from c in dbContext.InventoryCustomer
            //            join l in
            //            (
            //                from o in dbContext.InventoryOrders
            //                group o by o.CustomerId into res
            //                select new
            //                {
            //                    res.Key,
            //                    Count = res.Count()
            //                })
            //                 on c.CustomerId equals l.Key
            //            join s in dbContext.InventorySalesman
            //                 on c.SalesmanId equals s.SalesmanId
            //            select new
            //            {
            //                Name = c.CustName,
            //                Id = c.CustomerId,
            //                City = c.City,
            //                OrdersNum = l.Count,
            //                SName = s.Name,
            //                SCity = s.City,
            //                Commission = s.Commission
            //            };

            Console.WriteLine($"Result count: { list.Count()}");
            foreach (var ele in data.OrderByDescending(x => x.OrdersNum))
            {
                Console.WriteLine($"{ele.Id}, {ele.Name}, {ele.City}, {ele.OrdersNum}, {ele.SName}, {ele.SCity}, {ele.Commission}");
            }
        }
    }
}
