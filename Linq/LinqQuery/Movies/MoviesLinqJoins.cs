using Linq.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Linq.LinqQuery.Movies
{
    public class MoviesLinqJoins
    {
        private readonly W3ResourceContext _context;

        public MoviesLinqJoins(W3ResourceContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 1. Write a query in SQL to find the name of all reviewers who have rated their ratings with a NULL value. 
        /// </summary>
        public void Exe1st()
        {
            var result = from r in _context.Rating
                         join re in _context.Reviewer on r.RevId equals re.RevId
                         where r.RevStars == null
                         select new
                         {
                             re.RevName,
                         };
            foreach (var r in result)
            {
                System.Console.WriteLine($"{r.RevName}");
            }

            var result2 = _context.Rating
                .Join(_context.Reviewer,
                        rating => rating.RevId,
                        reviewer => reviewer.RevId,
                        (rating, reviewer) => new { reviewer.RevName, rating.RevStars })
                .Where(res => res.RevStars == null)
                .Select(res => new { res.RevName });

            foreach (var r in result2)
            {
                System.Console.WriteLine($"{r.RevName}");
            }
        }

        /// <summary>
        /// Write a query in SQL to list the first and last names of all the actors 
        /// who were cast in the movie 'Annie Hall'
        ///, and the roles they played in that production.
        /// </summary>
        public void Exe2nd()
        {
            var result = from m in _context.Movie
                         join c in _context.MovieCast on m.MovId equals c.MovId
                         join a in _context.Actor on c.ActId equals a.ActId
                         where m.MovTitle == "Annie Hall"
                         select new
                         {
                             Name = $"{a.ActFname} {a.ActLname}",
                             c.Role
                         };
            foreach (var r in result)
            {
                System.Console.WriteLine($"{r.Name} {r.Role}");
            }

            var result2 = _context.MovieCast
                .Join(_context.Actor,
                    mov => mov.ActId,
                    act => act.ActId,
                    (mov, act) => new
                    {
                        mov.MovId,
                        Name = $"{act.ActFname} {act.ActLname}",
                        mov.Role
                    })
                .Join(_context.Movie,
                    any => any.MovId,
                    movie => movie.MovId,
                    (any, movie) => new
                    {
                        any.Name,
                        any.Role,
                        movie.MovTitle
                    })
                .Where(any => any.MovTitle == "Annie Hall")
                .Select(any => new
                {
                    any.Name,
                    any.Role
                });
            foreach (var r in result2)
            {
                System.Console.WriteLine($"{r.Name} {r.Role}");
            }
        }

        /// <summary>
        /// 3. Write a query in SQL to find the name of movie and director(first and last names)
        /// who directed a movie that casted a role for 'Eyes Wide Shut'.
        /// </summary>
        public void Exe3rd()
        {
            var result = from m in _context.Movie
                         join md in _context.MovieDirection on m.MovId equals md.MovId
                         join d in _context.Director on md.DirId equals d.DirId
                         where m.MovTitle == "Eyes Wide Shut"
                         select new
                         {
                             Name = $"{d.DirFname} {d.DirLname}",
                         };
            foreach (var r in result)
            {
                System.Console.WriteLine($"{r.Name}");
            }

            var result2 = _context.Movie
                .Join(_context.MovieDirection,
                    m => m.MovId,
                    md => md.MovId,
                    (m, md) => new
                    {
                        md.DirId,
                        m.MovTitle
                    })
                .Join(_context.Director,
                    any => any.DirId,
                    d => d.DirId,
                    (any, d) => new
                    {
                        any.MovTitle,
                        Name = $"{d.DirFname} {d.DirLname}"
                    })
                .Where(any => any.MovTitle == "Eyes Wide Shut")
                .Select(any => any.Name);
            foreach (var r in result2)
            {
                System.Console.WriteLine($"{r}");
            }
        }

        /// <summary>
        /// --4. Write a query in SQL to find the name of movie and director (first and last names)
        /// who directed a movie that casted a role as Sean Maguire
        /// </summary>
        public void Exe4th()
        {
            var result = from m in _context.Movie
                         join md in _context.MovieDirection on m.MovId equals md.MovId
                         join mc in _context.MovieCast on m.MovId equals mc.MovId
                         join d in _context.Director on md.DirId equals d.DirId
                         where mc.Role == "Sean Maguire"
                         select new
                         {
                             Name = $"{d.DirFname} {d.DirLname}",
                             Title = $"{m.MovTitle}"
                         };
            foreach (var r in result)
            {
                System.Console.WriteLine($"{r.Name} {r.Title}");
            }

            var result2 = _context.Movie
                .Join(_context.MovieDirection,
                    m => m.MovId,
                    md => md.MovId,
                    (m, md) => new
                    {
                        m.MovTitle,
                        md.DirId,
                        m.MovId
                    })
                .Join(_context.MovieCast,
                    any => any.MovId,
                    mc => mc.MovId,
                    (any, mc) => new
                    {
                        any.MovTitle,
                        any.DirId,
                        mc.Role
                    })
                .Join(_context.Director,
                    any => any.DirId,
                    d => d.DirId,
                    (any, d) => new
                    {
                        Title = any.MovTitle,
                        Name = $"{d.DirFname} {d.DirLname}",
                        Role = any.Role
                    })
                .Where(any => any.Role == "Sean Maguire")
                .Select(any => new
                {
                    any.Name,
                    any.Title
                });
            foreach (var r in result2)
            {
                System.Console.WriteLine($"{r.Name} {r.Title}");
            }
        }

        /// <summary>
        /// 5. Write a query in SQL to list all the actors who have not acted in any movie between 1990 and 2000.
        /// </summary>
        public void Exe5th()
        {
            var result = from m in _context.Movie
                         join md in _context.MovieDirection on m.MovId equals md.MovId
                         join mc in _context.MovieCast on m.MovId equals mc.MovId
                         join d in _context.Director on md.DirId equals d.DirId
                         where mc.Role == "Sean Maguire"
                         select new
                         {
                             Name = $"{d.DirFname} {d.DirLname}",
                             Title = $"{m.MovTitle}"
                         };
            foreach (var r in result)
            {
                System.Console.WriteLine($"{r.Name} {r.Title}");
            }

            var result2 = _context.Movie
                .Join(_context.MovieDirection,
                    m => m.MovId,
                    md => md.MovId,
                    (m, md) => new
                    {
                        m.MovTitle,
                        md.DirId,
                        m.MovId
                    })
                .Join(_context.MovieCast,
                    any => any.MovId,
                    mc => mc.MovId,
                    (any, mc) => new
                    {
                        any.MovTitle,
                        any.DirId,
                        mc.Role
                    })
                .Join(_context.Director,
                    any => any.DirId,
                    d => d.DirId,
                    (any, d) => new
                    {
                        Title = any.MovTitle,
                        Name = $"{d.DirFname} {d.DirLname}",
                        Role = any.Role
                    })
                .Where(any => any.Role == "Sean Maguire")
                .Select(any => new
                {
                    any.Name,
                    any.Title
                });
            foreach (var r in result2)
            {
                System.Console.WriteLine($"{r.Name} {r.Title}");
            }
        }
    }
}
