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
            //_context.Database.EnsureCreated();
            //GetSamurais("Before Add:");
            //AddSamurai();
            AddSamurais("Gustavo", "Gomes");
            GetSamurais();
            //GetSamurais("After Add:");
            //GetSamurais("Show: ");
            Console.Write("Press any key...");
            Console.ReadKey();
        }

        
        //Add one at time
        //private static void AddSamurai()
        //{
        //    var samurai = new Samurai { Name = "Edson" };
        //    _context.Samurais.Add(samurai);
        //    _context.SaveChanges();
        //}

        private static void AddSamurais(params string[] names)
        {
            foreach (string name in names)
            {
                _context.Samurais.Add(new Samurai { Name = name });
            }
            _context.SaveChanges();
        }

        //One way to get all values
        //private static void GetSamurais(string text)
        //{
        //    var samurais = _context.Samurais.ToList();
        //    Console.WriteLine($"{text}: Samurai count is {samurais.Count}");
        //    foreach(var samurai in samurais)
        //    {
        //        Console.WriteLine(samurai.Name);
        //    }

        //}

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


    }
}
