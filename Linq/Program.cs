using Linq.LinqQuery.Inventory;
using Linq.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbcontext = new W3ResourceContext();
            var inventoryLinqJoins = new InventoryLinqSubQueries(dbcontext);
            inventoryLinqJoins.TwentySeventhExe();
        }
    }
}
