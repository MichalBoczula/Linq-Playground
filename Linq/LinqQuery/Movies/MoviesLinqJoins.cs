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
        /// Write a query in SQL to find the name of all reviewers who have rated their ratings with a NULL value. 
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
        /// who were cast in the movie 'Annie Hall',
        /// and the roles they played in that production.
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
        /// Write a query in SQL to find the name of movie and director(first and last names)
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
        /// Write a query in SQL to find the name of movie and director (first and last names)
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
        /// Write a query in SQL to list all the actors who have not acted in any movie between 1990 and 2000.
        /// </summary>
        public void Exe5th()
        {
            var result = from m in _context.Movie
                         join mc in _context.MovieCast on m.MovId equals mc.MovId
                         join a in _context.Actor on mc.ActId equals a.ActId
                         where !(m.MovYear >= 1990 && m.MovYear <= 2000)
                         select new
                         {
                             Name = $"{a.ActFname} {a.ActLname}"
                         };
            foreach (var r in result)
            {
                System.Console.WriteLine($"{r.Name}");
            }

            var result2 = _context.Movie
                .Join(_context.MovieCast,
                    m => m.MovId,
                    mc => mc.MovId,
                    (m, mc) => new
                    {
                        mc.ActId,
                        m.MovYear
                    })
                .Join(_context.Actor,
                    any => any.ActId,
                    a => a.ActId,
                    (any, a) => new
                    {
                        Name = $"{a.ActFname} {a.ActLname}",
                        Year = any.MovYear
                    })
                .Where(any => !(any.Year >= 1990 && any.Year < 2000))
                .Select(any => any.Name);
            foreach (var r in result2)
            {
                System.Console.WriteLine($"{r}");
            }
        }

        /// <summary>
        /// Write a query in SQL to list first and last name of all the directors with 
        /// number of genres movies the directed with genres name, 
        /// and arranged the result alphabetically with the first and last name of the director.
        /// </summary>
        public void Exe6th()
        {
            var result = from g in _context.Genres
                         join mg in _context.MovieGenres on g.GenId equals mg.GenId
                         join md in _context.MovieDirection on mg.MovId equals md.MovId
                         join d in _context.Director on md.DirId equals d.DirId
                         group g by new { g.GenTitle, d.DirLname, d.DirFname } into x
                         orderby x.Key.DirLname, x.Key.DirFname, x.Key.GenTitle
                         select new
                         {
                             Name = $"{x.Key.DirFname} {x.Key.DirLname}",
                             Title = x.Key.GenTitle,
                             Quantity = x.Count()
                         };

            foreach (var r in result)
            {
                System.Console.WriteLine($"{r.Name} {r.Title} {r.Quantity}");
            }

            var result2 = _context.Genres
                .Join(_context.MovieGenres,
                    g => g.GenId,
                    mg => mg.GenId,
                    (g, mg) => new
                    {
                        mg.MovId,
                        g.GenTitle
                    })
                .Join(_context.MovieDirection,
                    any => any.MovId,
                    md => md.MovId,
                    (any, md) => new
                    {
                        any.GenTitle,
                        md.DirId
                    })
                .Join(_context.Director,
                    any => any.DirId,
                    d => d.DirId,
                    (any, d) => new
                    {
                        d.DirFname,
                        d.DirLname,
                        any.GenTitle
                    })
                .GroupBy(x => new { x.GenTitle, x.DirFname, x.DirLname })
                .OrderBy(x => x.Key.DirLname)
                .ThenBy(x => x.Key.DirFname)
                .ThenBy(x => x.Key.GenTitle)
                .Select(group => new
                {
                    Name = $"{group.Key.DirFname} {group.Key.DirLname}",
                    Title = group.Key.GenTitle,
                    Quantity = group.Count()
                });

            System.Console.WriteLine($"");
            foreach (var r in result2)
            {
                System.Console.WriteLine($"{r.Name} {r.Title} {r.Quantity}");
            }
        }

        /// <summary>
        /// Write a query in SQL to compute a report which contain the genres of those movies 
        /// with their average time and number of movies for each genres.
        /// </summary>
        public void Exe7th()
        {
            var result = from g in _context.Genres
                         join mg in _context.MovieGenres on g.GenId equals mg.GenId
                         join m in _context.Movie on mg.MovId equals m.MovId
                         group new { g, m } by g.GenTitle into x
                         select new
                         {
                             x.Key,
                             Quantity = x.Count(),
                             AvgTime = x.Average(x => x.m.MovTime)
                         };

            foreach (var r in result)
            {
                System.Console.WriteLine($"{r.Key} {r.AvgTime} {r.Quantity}");
            }

            var result2 = _context.Genres
                .Join(_context.MovieGenres,
                    g => g.GenId,
                    mg => mg.GenId,
                    (g, mg) => new
                    {
                        g.GenTitle,
                        mg.MovId
                    })
                .Join(_context.Movie,
                    any => any.MovId,
                    m => m.MovId,
                    (any, m) => new
                    {
                        m.MovTime,
                        any.GenTitle
                    })
                .GroupBy(any => any.GenTitle,
                    any => new
                    {
                        any.GenTitle,
                        any.MovTime
                    })
                .Select(any => new
                {
                    any.Key,
                    Quantity = any.Count(),
                    AvgTime = any.Average(x => x.MovTime)
                });

            System.Console.WriteLine($"");
            foreach (var r in result2)
            {
                System.Console.WriteLine($"{r.Key} {r.AvgTime} {r.Quantity}");
            }
        }

        /// <summary>
        ///  Write a query in SQL to find movie title and number of stars for each movie 
        ///  that has at least one rating and find the highest number of stars that 
        ///  movie received and sort the result by movie title.
        /// </summary>
        public void Exe8th()
        {
            var result = from m in _context.Movie
                         join r in _context.Rating
                            on m.MovId equals r.MovId
                         group new { m, r } by m.MovTitle into x
                         where x.Max(x => x.r.RevStars) != null
                         orderby x.Key ascending
                         select new
                         {
                             x.Key,
                             MaxStar = x.Max(x => x.r.RevStars)
                         };

            foreach (var r in result)
            {
                System.Console.WriteLine($"{r.Key} {r.MaxStar}");
            }

            var result2 = _context.Movie
                .Join(_context.Rating,
                    m => m.MovId,
                    r => r.MovId,
                    (m, r) => new
                    {
                        m.MovTitle,
                        r.RevStars
                    })
                .GroupBy(any => any.MovTitle,
                any => new
                {
                    any.MovTitle,
                    any.RevStars
                })
                .Select(any => new
                {
                    any.Key,
                    MaxStar = any.Max(x => x.RevStars)
                })
                .Where(any => any.MaxStar != null);

            System.Console.WriteLine($"");
            foreach (var r in result2)
            {
                System.Console.WriteLine($"{r.Key} {r.MaxStar}");
            }
        }

        public void Exe9th()
        {
            var query = from mc in _context.MovieCast
                        group mc by mc.ActId into x
                        select new
                        {
                            x.Key,
                            Quantity = x.Count()
                        };

            var result = from m in _context.Movie
                         join mc in _context.MovieCast
                            on m.MovId equals mc.MovId
                         join a in _context.Actor
                            on mc.ActId equals a.ActId
                         join q in query
                             on a.ActId equals q.Key
                         where q.Quantity > 1
                         orderby a.ActLname, a.ActFname
                         select new
                         {
                             m.MovTitle,
                             Name = $"{a.ActFname} {a.ActLname}",
                         };

            foreach (var r in result)
            {
                System.Console.WriteLine($"{r.MovTitle} {r.Name}");
            }


            var query2 = _context.MovieCast
                .GroupBy(a => a.ActId)
                .Select(a => new
                {
                    a.Key,
                    Quantity = a.Count()
                });

            var result2 = _context.Movie
                .Join(_context.MovieCast,
                    m => m.MovId,
                    mc => mc.MovId,
                    (m, mc) => new
                    {
                        m.MovTitle,
                        mc.ActId
                    })
                .Join(_context.Actor,
                    any => any.ActId,
                    a => a.ActId,
                    (any, a) => new
                    {
                        any.MovTitle,
                        a.ActFname,
                        a.ActLname,
                        a.ActId
                    })
                .Join(query2,
                    any => any.ActId,
                    q => q.Key,
                    (any, q) => new
                    {
                        any.MovTitle,
                        any.ActFname,
                        any.ActLname,
                        q.Quantity
                    })
                .Where(any => any.Quantity > 1)
                .OrderBy(any => any.ActLname)
                .ThenBy(any => any.ActFname)
                .Select(any => new
                {
                    any.MovTitle,
                    Name = $"{any.ActFname} {any.ActLname}"
                });

            System.Console.WriteLine($"");
            foreach (var r in result2)
            {
                System.Console.WriteLine($"{r.MovTitle} {r.Name}");
            }
        }

        /// <summary>
        /// Write a query in SQL to generate a report which shows the year when the Mystery
        /// movies produces title and rating.
        /// </summary>
        public void Exe10th()
        {
            var result = from m in _context.Movie
                         join mg in _context.MovieGenres
                             on m.MovId equals mg.MovId
                         join g in _context.Genres
                             on mg.GenId equals g.GenId
                         where g.GenTitle == "Mystery"
                         select new
                         {
                             m.MovTitle,
                             g.GenTitle,
                             m.MovYear
                         };

            foreach (var r in result)
            {
                System.Console.WriteLine($"{r.MovTitle} {r.GenTitle} {r.MovYear}");
            }

            var result2 = _context.Movie
                .Join(_context.MovieGenres,
                    m => m.MovId,
                    mg => mg.MovId,
                    (m, mg) => new
                    {
                        m.MovTitle,
                        m.MovYear,
                        mg.GenId
                    })
                .Join(_context.Genres,
                    any => any.GenId,
                    g => g.GenId,
                    (any, g) => new
                    {
                        any.MovTitle,
                        any.MovYear,
                        g.GenTitle
                    })
                .Where(any => any.GenTitle == "Mystery")
                .Select(any => any);


            System.Console.WriteLine($"");
            foreach (var r in result2)
            {
                System.Console.WriteLine($"{r.MovTitle} {r.GenTitle} {r.MovYear}");
            }
        }

        /// <summary>
        /// Write a query in SQL to find the movie title, year, date of release, 
        /// director and actor for those movies which reviewer is unknown. SELECT A.mov_title, A.mov_year, A.mov_dt_rel,
        /// </summary>
        public void Exe11th()
        {
            var result = from rev in _context.Reviewer
                         join ra in _context.Rating
                            on rev.RevId equals ra.RevId
                         join mov in _context.Movie
                             on ra.MovId equals mov.MovId
                         where rev.RevName == null
                         select new
                         {
                             mov.MovTitle,
                             mov.MovYear,
                             mov.MovDtRel,
                         };

            foreach (var r in result)
            {
                System.Console.WriteLine($"{r.MovTitle} {r.MovDtRel} {r.MovYear}");
            }

            var result2 = _context.Reviewer
                .Join(_context.Rating,
                    rev => rev.RevId,
                    ra => ra.RevId,
                    (rev, ra) => new
                    {
                        ra.MovId,
                        rev.RevName
                    })
                .Join(_context.Movie,
                    any => any.MovId,
                    mov => mov.MovId,
                    (any, mov) => new
                    {
                        any.RevName,
                        mov.MovTitle,
                        mov.MovYear,
                        mov.MovDtRel
                    })
                .Where(any => any.RevName == null)
                .Select(any => new
                {
                    any.MovTitle,
                    any.MovYear,
                    any.MovDtRel
                });

            foreach (var r in result2)
            {
                System.Console.WriteLine($"{r.MovTitle} {r.MovDtRel} {r.MovYear}");
            }
        }

        /// <summary>
        /// Write a query in SQL to find all the years which produced at least one movie and
        /// that received a rating of more than 8 stars.Show the results in increasing order.
        /// </summary>
        public void Exe12th()
        {
            var query = from ra in _context.Movie
                        group ra by ra.MovYear into x
                        select new
                        {
                            x.Key,
                            Quantity = x.Count()
                        };

            var result = from mov in _context.Movie
                         join ra in _context.Rating
                            on mov.MovId equals ra.MovId
                         join q in query
                             on mov.MovYear equals q.Key
                         where ra.RevStars > 8
                            && q.Quantity > 1
                         select new
                         {
                             mov.MovTitle,
                             mov.MovYear
                         };

            foreach (var r in result)
            {
                System.Console.WriteLine($"{r.MovTitle} {r.MovYear}");
            }

            var query2 = _context.Movie
                .GroupBy(x => x.MovYear)
                .Select(x => new
                {
                    x.Key,
                    Quantity = x.Count()
                });

            var result2 = _context.Movie
                .Join(_context.Rating,
                    mov => mov.MovId,
                    ra => ra.MovId,
                    (mov, ra) => new
                    {
                        mov.MovTitle,
                        mov.MovYear,
                        ra.RevStars
                    })
                .Join(query2,
                    any => any.MovYear,
                    q => q.Key,
                    (any, q) => new
                    {
                        any.MovTitle,
                        any.MovYear,
                        any.RevStars,
                        q.Quantity
                    })
                .Where(any => any.RevStars > 8
                    && any.Quantity > 1)
                .Select(any => new
                {
                    any.MovTitle,
                    any.MovYear
                });

            foreach (var r in result2)
            {
                System.Console.WriteLine($"{r.MovTitle} {r.MovYear}");
            }
        }

        /// <summary>
        /// Write a query in SQL to find the reviewer's name and the title of the movie
        /// for those reviewers who rated more than one movies.
        /// </summary>
        public void Exe13th()
        {
            var query = from ra in _context.Rating
                        group ra by ra.RevId into x
                        select new
                        {
                            x.Key,
                            Quantity = x.Count()
                        };

            var result = from mov in _context.Movie
                         join ra in _context.Rating
                            on mov.MovId equals ra.MovId
                         join rev in _context.Reviewer
                            on ra.RevId equals rev.RevId
                         join q in query
                             on rev.RevId equals q.Key
                         where q.Quantity > 1 &&
                             rev.RevName != null
                         select new
                         {
                             rev.RevName,
                             mov.MovTitle
                         };

            foreach (var r in result)
            {
                System.Console.WriteLine($"{r.MovTitle} {r.RevName}");
            }

            var query2 = _context.Rating
                .GroupBy(x => x.RevId)
                .Select(x => new
                {
                    x.Key,
                    Quantity = x.Count()
                });

            var result2 = _context.Movie
                .Join(_context.Rating,
                    mov => mov.MovId,
                    ra => ra.MovId,
                    (mov, ra) => new
                    {
                        ra.RevId,
                        mov.MovTitle,
                    })
                .Join(_context.Reviewer,
                    any => any.RevId,
                    rev => rev.RevId,
                    (any, rev) => new
                    {
                        any.MovTitle,
                        rev.RevName,
                        rev.RevId
                    })
                .Join(query2,
                    any => any.RevId,
                    q => q.Key,
                    (any, q) => new
                    {
                        any.MovTitle,
                        any.RevName,
                        q.Quantity
                    })
                .Where(any => any.Quantity > 1
                    && any.RevName != null)
                .Select(any => new
                {
                    any.MovTitle,
                    any.RevName
                });

            foreach (var r in result2)
            {
                System.Console.WriteLine($"{r.MovTitle} {r.RevName}");
            }
        }

        /// <summary>
        /// Write a query in SQL to find the movie title, and the highest number of stars that movie received and arranged 
        /// the result according to the group of a movie and the movie title appear alphabetically in ascending order.
        /// </summary>
        public void Exe14th()
        {
            var query = from ra in _context.Rating
                        group ra by ra.MovId into x
                        select new
                        {
                            x.Key,
                            Max = x.Max(x => x.RevStars)
                        };

            var result = from mov in _context.Movie
                         join q in query
                             on mov.MovId equals q.Key
                         orderby mov.MovTitle ascending
                         select new
                         {
                             mov.MovTitle,
                             q.Max
                         };

            foreach (var r in result)
            {
                System.Console.WriteLine($"{r.MovTitle} {r.Max}");
            }

            var query2 = _context.Rating
                .GroupBy(x => x.MovId)
                .Select(x => new
                {
                    x.Key,
                    Max = x.Max(x => x.RevStars)
                });

            var result2 = _context.Movie
                .Join(query2,
                    mov => mov.MovId,
                    q => q.Key,
                    (mov, q) => new
                    {
                        mov.MovTitle,
                        q.Max
                    })
                .OrderBy(any => any.MovTitle)
                .Select(any => new
                {
                    any.MovTitle,
                    any.Max
                });

            foreach (var r in result2)
            {
                System.Console.WriteLine($"{r.MovTitle} {r.Max}");
            }
        }


        /// <summary>
        /// Write a query in SQL to find the name of those movies where one or more actors acted in two or more movies.
        /// </summary>
        public void Exe15th()
        {
            var query = from ra in _context.MovieCast
                        group ra by ra.ActId into x
                        select new
                        {
                            x.Key,
                            Quantity = x.Count()
                        };

            var result = from mov in _context.Movie
                         join mc in _context.MovieCast
                            on mov.MovId equals mc.MovId
                         join a in _context.Actor
                            on mc.ActId equals a.ActId
                         join q in query
                             on a.ActId equals q.Key
                         where q.Quantity > 1
                         select new
                         {
                             Name = $"{a.ActFname} { a.ActLname}",
                             mov.MovTitle
                         };

            foreach (var r in result)
            {
                System.Console.WriteLine($"{r.Name} {r.MovTitle}");
            }

            var query2 = _context.MovieCast
                .GroupBy(x => x.ActId)
                .Select(x => new
                {
                    x.Key,
                    Quantity = x.Count()
                });

            var result2 = _context.Movie
                .Join(_context.MovieCast,
                    mov => mov.MovId,
                    mc => mc.MovId,
                    (mov, mc) => new
                    {
                        mov.MovTitle,
                        mc.ActId
                    })
                .Join(_context.Actor,
                    any => any.ActId,
                    a => a.ActId,
                    (any, a) => new
                    {
                        any.ActId,
                        any.MovTitle,
                        Name = $"{a.ActFname} {a.ActLname}"
                    })
                .Join(query2,
                    any => any.ActId,
                    q => q.Key,
                    (any, q) => new
                    {
                        any.MovTitle,
                        any.Name,
                        q.Quantity
                    })
                .Where(any => any.Quantity > 1)
                .Select(any => new
                {
                    any.MovTitle,
                    any.Name
                });

            foreach (var r in result2)
            {
                System.Console.WriteLine($"{r.MovTitle} {r.Name}");
            }
        }
    }
}
