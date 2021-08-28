using Linq.LinqQuery.HR;
using Linq.LinqQuery.Inventory;
using Linq.LinqQuery.Movies;
using Linq.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    public class Program
    {
        static void Main(string[] args)
        {
            var dbcontext = new W3ResourceContext();
            var movie = new MoviesLinqJoins(dbcontext);
            movie.Exe15th();
        }
    }
}
