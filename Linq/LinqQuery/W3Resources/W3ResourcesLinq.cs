using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq.LinqQuery.W3Resources
{
    public class W3ResourcesLinq
    {
        //All methods in this class are solution for W3Resources Linq examples
        public void Dictionary()
        {
            string[] cities =
                        {
                "ROME","LONDON","NAIROBI","CALIFORNIA","ZURICH","NEW DELHI","AMSTERDAM","ABU DHABI", "PARIS", "CANNAS"
            };

            var result = cities.OrderByDescending(x => x).GroupBy(c => c.ToString().Substring(0, 1),
                (key, value) => new { Key = key, Mark = value.First() }).ToList();

            var result2 = from c in cities
                          orderby c descending
                          group c by c.Substring(0, 1) into y
                          select new
                          {
                              Key = y.Key,
                              City = y.First()
                          };


            foreach (var i in result2.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{i.Key}: { i.City}");
            }
        }

        public void OrderByAndSelect()
        {
            string[] cities =
                        {
                "ROME","LONDON","NAIROBI","CALIFORNIA","ZURICH","NEW DELHI","AMSTERDAM","ABU DHABI", "PARIS", "CANNAS"
            };

            var result = from c in cities
                         orderby c.Length
                         select new
                         {
                             City = c,
                             Length = c.Length
                         };

            foreach (var i in result)
            {
                Console.WriteLine($"{i}");
            }
        }

        public void SelectDistinct()
        {
            List<Item_mast> itemlist = new List<Item_mast>();
            itemlist.Add(new Item_mast() { ItemId = 1, ItemDes = "Biscuit  " });
            itemlist.Add(new Item_mast() { ItemId = 2, ItemDes = "Honey    " });
            itemlist.Add(new Item_mast() { ItemId = 3, ItemDes = "Butter   " });
            itemlist.Add(new Item_mast() { ItemId = 4, ItemDes = "Brade    " });
            itemlist.Add(new Item_mast() { ItemId = 5, ItemDes = "Honey    " });
            itemlist.Add(new Item_mast() { ItemId = 6, ItemDes = "Biscuit  " });

            var result = (from i in itemlist
                          select i.ItemDes)
                         .Distinct();

            foreach (var num in result)
            {
                Console.WriteLine($"{num}");
            }
        }

        public void RightJoin()
        {
            List<Item_mast> itemlist = new List<Item_mast>
            {
               new Item_mast { ItemId = 1, ItemDes = "Biscuit  " },
               new Item_mast { ItemId = 2, ItemDes = "Chocolate" },
               new Item_mast { ItemId = 3, ItemDes = "Butter   " },
               new Item_mast { ItemId = 4, ItemDes = "Brade    " },
               new Item_mast { ItemId = 5, ItemDes = "Honey    " }
            };

            List<Purchase> purchlist = new List<Purchase>
            {
               new Purchase { InvNo=100, ItemId = 3,  PurQty = 800 },
               new Purchase { InvNo=101, ItemId = 5,  PurQty = 650 },
               new Purchase { InvNo=102, ItemId = 3,  PurQty = 900 },
               new Purchase { InvNo=103, ItemId = 4,  PurQty = 700 },
               new Purchase { InvNo=104, ItemId = 3,  PurQty = 900 },
               new Purchase { InvNo=105, ItemId = 4,  PurQty = 650 },
               new Purchase { InvNo=106, ItemId = 1,  PurQty = 458 }
            };


            var result = from purch in purchlist
                         join item in itemlist on purch.ItemId equals item.ItemId into res
                         from x in res.DefaultIfEmpty(new Item_mast())
                         orderby x.ItemId
                         select new
                         {
                             ItemId = x.ItemId,
                             ItemDes = x.ItemDes,
                             InvNo = purch.InvNo,
                             PurQty = purch.PurQty
                         };

            foreach (var num in result)
            {
                Console.WriteLine($"{num.ItemId}:  {num.ItemDes}, {num.InvNo}, {num.PurQty}");
            }
        }

        public void LeftJoin()
        {
            List<Item_mast> itemlist = new List<Item_mast>
            {
               new Item_mast { ItemId = 1, ItemDes = "Biscuit  " },
               new Item_mast { ItemId = 2, ItemDes = "Chocolate" },
               new Item_mast { ItemId = 3, ItemDes = "Butter   " },
               new Item_mast { ItemId = 4, ItemDes = "Brade    " },
               new Item_mast { ItemId = 5, ItemDes = "Honey    " }
            };

            List<Purchase> purchlist = new List<Purchase>
            {
               new Purchase { InvNo=100, ItemId = 3,  PurQty = 800 },
               new Purchase { InvNo=101, ItemId = 2,  PurQty = 650 },
               new Purchase { InvNo=102, ItemId = 3,  PurQty = 900 },
               new Purchase { InvNo=103, ItemId = 4,  PurQty = 700 },
               new Purchase { InvNo=104, ItemId = 3,  PurQty = 900 },
               new Purchase { InvNo=105, ItemId = 4,  PurQty = 650 },
               new Purchase { InvNo=106, ItemId = 1,  PurQty = 458 }
            };

            var result = from i in itemlist
                         join p in purchlist on i.ItemId equals p.ItemId into ip
                         from pu in ip.DefaultIfEmpty(new Purchase())
                         select new
                         {
                             ItemId = i.ItemId,
                             ItemDes = i.ItemDes,
                             InvNo = pu.InvNo,
                             PurQty = pu.PurQty
                         };

            foreach (var num in result)
            {
                Console.WriteLine($"{num.ItemId}:  {num.ItemDes}, {num.InvNo}, {num.PurQty}");
            }
        }


        /// <summary>
        /// Write a program in C# Sharp to generate an Inner Join between two data sets.
        /// </summary>
        public void FirstJoinLinq()
        {

            List<Item_mast> itemlist = new List<Item_mast>
            {
               new Item_mast { ItemId = 1, ItemDes = "Biscuit  " },
               new Item_mast { ItemId = 2, ItemDes = "Chocolate" },
               new Item_mast { ItemId = 3, ItemDes = "Butter   " },
               new Item_mast { ItemId = 4, ItemDes = "Brade    " },
               new Item_mast { ItemId = 5, ItemDes = "Honey    " }
            };

            List<Purchase> purchlist = new List<Purchase>
            {
               new Purchase { InvNo=100, ItemId = 3,  PurQty = 800 },
               new Purchase { InvNo=101, ItemId = 2,  PurQty = 650 },
               new Purchase { InvNo=102, ItemId = 3,  PurQty = 900 },
               new Purchase { InvNo=103, ItemId = 4,  PurQty = 700 },
               new Purchase { InvNo=104, ItemId = 3,  PurQty = 900 },
               new Purchase { InvNo=105, ItemId = 4,  PurQty = 650 },
               new Purchase { InvNo=106, ItemId = 1,  PurQty = 458 }
            };

            var result = from i in itemlist
                         join p in purchlist on i.ItemId equals p.ItemId
                         select new
                         {
                             ItemId = i.ItemId,
                             ItemDes = i.ItemDes,
                             InvNo = p.InvNo,
                             PurQty = p.PurQty
                         };

            foreach (var num in result)
            {
                Console.WriteLine($"{num.ItemId}:  {num.ItemDes}, {num.InvNo}, {num.PurQty}");
            }
        }

        /// <summary>
        /// DataSet To Join
        /// </summary>
        public class Item_mast
        {
            public int ItemId { get; set; }
            public string ItemDes { get; set; }
        }

        /// <summary>
        /// DataSet To Join
        /// </summary>
        public class Purchase
        {
            public int InvNo { get; set; }
            public int ItemId { get; set; }
            public int PurQty { get; set; }
        }

        /// <summary>
        /// Write a program in C# Sharp to generate a Cartesian Product of three sets.
        /// </summary>
        public  void CartesianProductThreeSets()
        {
            char[] charset1 = { 'X', 'Y', 'Z' };
            int[] numset1 = { 1, 2, 3 };
            string[] colorset1 = { "Green", "Orange" };

            var result = colorset1.SelectMany(
                    z => charset1.SelectMany(
                        x => numset1.Select(y => x + " " + y + " " + z)))
                .ToList();

            var r = from ch in charset1
                    from n in numset1
                    from c in colorset1
                    select new
                    {
                        Item = $"{ch}, {n}, {c}"
                    };

            foreach (var num in r)
            {
                Console.WriteLine(num.Item);
            }
        }

        /// <summary>
        /// Write a program in C# Sharp to generate a Cartesian Product of two sets.
        /// </summary>
        public  void CartesianProduct()
        {
            char[] charset1 = { 'X', 'Y', 'Z' };
            int[] numset1 = { 1, 2, 3, 4 };

            var result = charset1.SelectMany(x => numset1.Select(y => x + " " + y)).ToList();

            var r = from ch in charset1
                    from n in numset1
                    select new
                    {
                        Item = $"{ch} {n}"
                    };

            foreach (var num in r)
            {
                Console.WriteLine(num.Item);
            }
        }

        /// <summary>
        /// Write a program in C# Sharp to find the strings for a specific minimum length.
        /// </summary>
        public  void FindSrtingWithSpecificLength()
        {
            var str = "Find the strings for a specific minimum length orr aaaaa";
            var length = 7;

            var result = str.Split(" ").Where(x => x.Length == length).ToList();

            var r = from s in str.Split(" ")
                    where s.Length == length
                    select s;

            foreach (var num in r)
            {
                Console.WriteLine(num);
            }
        }

        /// <summary>
        /// Write a program in C# Sharp to Remove Items from List using remove function by passing object.
        /// </summary>
        public  void FindAndRemoveChar()
        {
            List<string> listOfString = new List<string>();
            listOfString.Add("m");
            listOfString.Add("n");
            listOfString.Add("o");
            listOfString.Add("p");
            listOfString.Add("q");
            var result = listOfString.FirstOrDefault(x => x == "o");

            var r = from o in listOfString
                    where o == "o"
                    select o;

            listOfString.Remove(r.First());
            //In Line
            //listOfString.Remove(
            //    listOfString.FirstOrDefault(x => x == "o"));
            foreach (var num in listOfString)
            {
                Console.WriteLine(num);
            }
        }

        /// <summary>
        /// Write a program in C# Sharp to find the uppercase words in a string.
        /// </summary>
        public  void FindUpperCaseWords()
        {
            var str = "The UPPER CASE words are RAWRRR";
            var arr = str.Split(" ");

            var result = arr.Where(x => String.Equals(x, x.ToUpper())).ToList();

            var r = from s in str.Split(" ")
                    where s.Equals(s.ToUpper())
                    select s;

            foreach (var num in r)
            {
                Console.WriteLine(num);
            }
        }

        /// <summary>
        /// Write a program in C# Sharp to display the top nth records.
        /// </summary>
        public  void FindNBiggestInts()
        {
            List<int> templist = new List<int>();
            templist.Add(5);
            templist.Add(7);
            templist.Add(13);
            templist.Add(24);
            templist.Add(6);
            templist.Add(9);
            templist.Add(8);
            templist.Add(7);

            var result = templist.OrderByDescending(x => x).Take(3);

            var r = from n in templist
                    orderby n descending
                    select n;

            foreach (var num in r.Take(3))
            {
                Console.WriteLine(num);
            }
        }

        /// <summary>
        /// Write a program in C# Sharp to find the string which starts and ends with a specific character.
        /// </summary>
        public  void FindNameWithStratWithAndEndWith()
        {
            string[] cities =
                        {
                "ROME","LONDON","NAIROBI","CALIFORNIA","ZURICH","NEW DELHI","AMSTERDAM","ABU DHABI", "PARIS"
            };

            var start = "a";
            var end = "i";

            var result = cities.Where(x => x.StartsWith(start, StringComparison.CurrentCultureIgnoreCase)
                                        && x.EndsWith(end, StringComparison.CurrentCultureIgnoreCase)).ToList();

            var r = from c in cities
                    where c.StartsWith(start, StringComparison.CurrentCultureIgnoreCase)
                        && c.EndsWith(end, StringComparison.CurrentCultureIgnoreCase)
                    select c;

            foreach (var num in r)
            {
                Console.WriteLine(num);
            }
        }

        /// <summary>
        /// Write a program in C# Sharp to display numbers, multiplication of number with frequency and the frequency of number of giving array.
        /// </summary>
        public  void SelectConfigurationOfInt()
        {
            int[] nums = new int[] { 5, 1, 9, 2, 3, 7, 4, 5, 6, 8, 7, 6, 3, 4, 5, 2 };

            var result = nums.GroupBy(x => x, (key, value) => new
            {
                Key = key,
                Quantity = value.Count(),
                Multi = value.Count() * key
            }).ToList();

            var r = from n in nums
                    group n by n
                    into y
                    select new
                    {
                        Num = y.Key,
                        Quantity = y.Count(),
                        Multi = y.Count() * y.Key
                    };


            foreach (var num in r)
            {
                Console.WriteLine($"{num.Num}, {num.Multi}, {num.Quantity}");
            }
        }

        /// <summary>
        /// Write a program in C# Sharp to display the characters and frequency of character from giving string.
        /// </summary>
        public  void LetterFrequency()
        {
            var str = "Display the characters and frequency of character from giving string";
            var result = str.ToLower()
                .GroupBy(x => x, (key, value) => new
                {
                    Key = key,
                    Quantity = value.Count()
                }).OrderByDescending(x => x.Quantity)
                .Where(x => !String.IsNullOrWhiteSpace(x.Key.ToString()))
                .ToList();

            var r = from s in str.ToLower()
                    where s != ' '
                    group s by s into x
                    orderby x.Count() descending
                    select new
                    {
                        Item = x.Key,
                        Quantity = x.Count()
                    };

            foreach (var num in r)
            {
                Console.WriteLine(num);
            }
        }

        /// <summary>
        /// Write a program in C# Sharp to display the number and frequency of number from giving array.
        /// </summary>
        public  void NumFrequency()
        {
            int[] arr1 = new int[] { 5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2 };
            var result = arr1.GroupBy(n => n).Select(n => new { Key = n.Key, Quantity = n.Count() }).OrderByDescending(x => x.Quantity);

            var r = from num in arr1
                    group num by num into y
                    orderby y.Count() descending
                    select new
                    {
                        Num = y.Key,
                        Quantity = y.Count()
                    };

            foreach (var num in r)
            {
                Console.WriteLine(num);
            }
        }

        /// <summary>
        /// Write a program in C# Sharp to find the number of an array and the square of each number.
        /// </summary>
        public void SelectNumAndSqr()
        {
            var arr1 = new[] { 3, 9, 2, 8, 6, 5, 1, 7, 4 };
            var result = arr1.Select(n => new { Num = n, Sqr = n * n }).OrderBy(n => n.Num);

            var r = from n in arr1
                    orderby n
                    select new
                    {
                        Num = n,
                        Sqr = n * n
                    };

            foreach (var num in r)
            {
                Console.WriteLine(num);
            }
        }

        /// <summary>
        /// Write a program in C# Sharp to find the n-th Maximum grade point achieved by the students from the list of students.
        /// </summary>
        public void GroupByAndSelect()
        {
            Students students = new Students();

            var list = students.GtStuRec();

            var result = list.GroupBy(s => s.GrPoint,
                                            (key, value) => new { Key = key, Students = value.Where(s => s.GrPoint == key) })
                            .OrderByDescending(s => s.Key)
                            .Take(1);

            var r = (from s in list
                     group s by s.GrPoint into studs
                     orderby studs.Key descending
                     select new
                     {
                         Students = studs
                     }).ToList();

            var c = r[0].Students.Select(x => new { Name = x.StuName, Points = x.GrPoint }).ToList();

            foreach (var i in c)
            {
                Console.WriteLine($"{i.Points}: {i.Name}");
            }

            //OR

            var r2 = (from s in list
                      group s by s.GrPoint into studs
                      orderby studs.Key descending
                      select new
                      {
                          Students = studs.ToList()
                      }).ToList();

            r2[0].Students.ForEach(i =>
                Console.WriteLine($"{i.GrPoint}: {i.StuName}"));
        }
    }
    /// <summary>
    /// Class to GroupByAndSelect Exercise
    /// </summary>
    public class Students
    {
        public string StuName { get; set; }
        public int GrPoint { get; set; }
        public int StuId { get; set; }

        public List<Students> GtStuRec()
        {
            List<Students> stulist = new List<Students>();
            stulist.Add(new Students { StuId = 1, StuName = " Joseph ", GrPoint = 800 });
            stulist.Add(new Students { StuId = 2, StuName = "Alex", GrPoint = 458 });
            stulist.Add(new Students { StuId = 3, StuName = "Harris", GrPoint = 900 });
            stulist.Add(new Students { StuId = 4, StuName = "Taylor", GrPoint = 900 });
            stulist.Add(new Students { StuId = 5, StuName = "Smith", GrPoint = 458 });
            stulist.Add(new Students { StuId = 6, StuName = "Natasa", GrPoint = 700 });
            stulist.Add(new Students { StuId = 7, StuName = "David", GrPoint = 750 });
            stulist.Add(new Students { StuId = 8, StuName = "Harry", GrPoint = 700 });
            stulist.Add(new Students { StuId = 9, StuName = "Nicolash", GrPoint = 597 });
            stulist.Add(new Students { StuId = 10, StuName = "Jenny", GrPoint = 750 });
            return stulist;
        }
    }
}
