using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TestEntretien
{
    public class TestAlgo
    {

        /// <summary>
        /// grouper les anagrammes 
        /// 10 min
        /// </summary>
        public static void GroupAnagram()
        {
            Console.WriteLine("GroupAnagram start");
            
            string[] input = { "reza", "eat", "tea", "tan", "ate", "nat", "bat", "bta", "azer" };

            var anagramGroups = input.GroupBy(a => string.Join(null,a.OrderBy(a => a))).Select(a=>a.ToList());

            foreach (var anagramGroup in anagramGroups)
            {
                Console.WriteLine($"{string.Join(", ",anagramGroup)}");
            }          
        }

        public static void SortInt()
        {
            int[] numbers = Enumerable.Range(0, 10).OrderBy(xp => Guid.NewGuid()).ToArray();

            Console.WriteLine(string.Join(",", numbers.OrderBy(a=>a)));

        }


        /// <summary>
        /// Reconstruire une liste en fusionnant les infos, de manière performante ( < 200ms pour 100_000 itérations)
        /// 10 min
        /// </summary>
        public static void PerfSeach()
        {
            int count = 100_000;
            IEnumerable<(string Id, string Name)> persons = Enumerable.Range(0, count)
                .Select(i => (i.ToString(), $"username_{i}"));

            IEnumerable<(string Id, string Email)> persons2 = Enumerable.Range(0, count)
                .Select(i => (i.ToString(), $"mail_{i}@citeo.com"));

            List<(string Id, string Email, string Name)> result = new List<(string Id, string Email, string Name)>();
            
            Stopwatch watch = Stopwatch.StartNew();

            var dico = persons2.ToDictionary(a=>a.Id, a=>a.Email); // search complexity O(1)

            result.AddRange(persons.Select(i => (i.Id, i.Name, dico[i.Id])));            
            
            Console.WriteLine(watch.Elapsed.TotalMilliseconds);
        }
    }
}
