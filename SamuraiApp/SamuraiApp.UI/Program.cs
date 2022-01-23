using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Linq;


namespace SamuraiApp.UI
{
    class Program
    {
        private static SamuraiContext _context = new SamuraiContext();

        static void Main(string[] args)
        {

            //AddSamuraisByName("Shimada", "Okamoto", "Kikuchio", "Hayashida");
            //GetSamurais();
            //AddVariousTypes();
            //QueryFilters();
            //QueryAggregates();
            //RetrieveAndUpdateSamurai();
            //RetrieveAndUpdateMultipleSamurais();
            MultipleDatabaseOperations();
            Console.Write("Press any key...");
            Console.ReadKey();
        }

       

        private static void AddVariousTypes()
        {
            _context.AddRange(
                new Samurai { Name = "Shimada" },
                new Samurai { Name = "Okamoto" },
                new Battle { Name = "Battle of Anegawa" },
                new Battle { Name = "Battle of Nagashino" });
            //_context.Samurais.AddRange(
            //    new Samurai { Name = "Shimada"},
            //    new Samurai { Name = "Okamoto"}
            //    );
            //_context.Battles.AddRange(
            //    new Battle { Name = "Battle of Anegawa"},
            //    new Battle { Name = "Battle of Nagashino"});
            _context.SaveChanges();
        }

        private static void AddSamuraisByName(params string[] names)
        {
            foreach (string name in names)
            {
                _context.Samurais.Add(new Samurai { Name = name });
            }
            _context.SaveChanges();
        }

        private static void GetSamurais()
        {
            var samurais = _context.Samurais
                .TagWith("ConsoleApp.Program.GetSamurais method")
                .ToList();
            Console.WriteLine($"Samurai count is {samurais.Count}");
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
        }

        private static void QueryFilters()
        {
            //var name = "Sampson";
            //var samurais = _context.Samurais.Where(s => s.Name == name).ToList();
            var samurais = _context.Samurais
                .Where(s => EF.Functions.Like(s.Name, "J%")).ToList();

            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
                Console.WriteLine(samurais.Count);
        }

        private static void QueryAggregates()
        {
            var name = "Sampson";
            //var samurai = _context.Samurais.FirstOrDefault(s => s.Name == name);
            var samurai = _context.Samurais.Find(2);
        }

        private static void RetrieveAndUpdateSamurai()
        {
            var samurai = _context.Samurais.FirstOrDefault();
            samurai.Name += "San";
            _context.SaveChanges();
        }

        private static void RetrieveAndUpdateMultipleSamurais()
        {
            var samurais = _context.Samurais.Skip(1).Take(4).ToList();
            samurais.ForEach(s => s.Name += "_Don");
            _context.SaveChanges();
        }

        private static void MultipleDatabaseOperations()
        {
            var samurai = _context.Samurais.FirstOrDefault();
            samurai.Name += "Eds";
            _context.Samurais.Add(new Samurai { Name = "Shino" });
            _context.SaveChanges();
        }
    }
}
