using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIdentityServiceApi.Models
{
    public class Prize
    {
        public string Name { get; set; }
    }

    public class Album
    {
        public string Title { get; set; }
        public int Year { get; set; }
    }

    public class RockBand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Album> Albums { get; set; }
        public ICollection<Prize> Prizes { get; set; }
    }
    public interface IObjectContextFactory
    {
        InMemoryDatabaseObjectContext Create();
    }

    public class LazySingletonObjectContextFactory : IObjectContextFactory
    {
        public InMemoryDatabaseObjectContext Create()
        {
            return InMemoryDatabaseObjectContext.Instance;
        }
    }

    public class InMemoryDatabaseObjectContext
    {
        private List<RockBand> _rockBands;

        public InMemoryDatabaseObjectContext()
        {
            _rockBands = InitialiseRockBands();
        }

        public IEnumerable<RockBand> GetAll()
        {
            return _rockBands;
        }

        public RockBand GetById(int id)
        {
            return (from r in _rockBands where r.Id == id select r).FirstOrDefault();
        }

        public static InMemoryDatabaseObjectContext Instance
        {
            get
            {
                return Nested.instance;
            }
        }

        private class Nested
        {
            static Nested()
            {
            }
            internal static readonly InMemoryDatabaseObjectContext instance = new InMemoryDatabaseObjectContext();
        }

        private List<RockBand> InitialiseRockBands()
        {
            List<RockBand> rockbands = new List<RockBand>();

            RockBand greatBand = new RockBand();
            greatBand.Name = "Great band";
            greatBand.Id = 1;
            greatBand.Albums = new List<Album>(){new Album(){Title = "First album", Year = 2000}, new Album(){Title = "Second album", Year = 2003}
                , new Album(){Title = "Third album", Year=2005}};
            greatBand.Prizes = new List<Prize>() { new Prize() { Name = "Best band" }, new Prize() { Name = "Best newcomers" } };

            RockBand rockBand = new RockBand();
            rockBand.Name = "Funny band";
            rockBand.Id = 2;
            rockBand.Albums = new List<Album>(){new Album(){Title = "Debut", Year = 1979}, new Album(){Title = "Continuation", Year = 1980}
                , new Album(){Title = "New Year", Year=1982}, new Album(){Title ="Summer", Year=1985}};
            rockBand.Prizes = new List<Prize>() { new Prize() { Name = "Cool band" }, new Prize() { Name = "Best band" }, new Prize() { Name = "First choice" } };

            RockBand anotherBand = new RockBand();
            anotherBand.Name = "Sounds good";
            anotherBand.Id = 3;
            anotherBand.Albums = new List<Album>() { new Album() { Title = "The beginning", Year = 1982 }, new Album() { Title = "The end", Year = 1986 } };
            anotherBand.Prizes = new List<Prize>() { new Prize() { Name = "First choice" } };

            RockBand rb = new RockBand();
            rb.Name = "Sounds good";
            rb.Id = 4;
            rb.Albums = new List<Album>() { new Album() { Title = "Cool", Year = 1988 }, new Album() { Title = "Yeah", Year = 1989 }
                , new Album() { Title = "Oooooohhh", Year = 1990 }, new Album() { Title = "Entertain", Year = 1991 }, new Album() { Title = "Go home", Year = 1992 }};
            rb.Prizes = new List<Prize>() { new Prize() { Name = "First choice" }, new Prize() { Name = "Cool band" } };

            rockbands.Add(greatBand);
            rockbands.Add(rockBand);
            rockbands.Add(anotherBand);
            rockbands.Add(rb);

            return rockbands;
        }
    }

}
