using System;
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

            var sortedImput = new List<string>();

            foreach (var item in input)
            {
                var word = item.ToList();
                word.Sort();
                sortedImput.Add(string.Join("", word));
            }

            var indexes = new List<int>();

            foreach (var item in sortedImput)
            {
                foreach (var item2 in sortedImput)
                {                    
                    if(item == item2)
                    {
                        indexes.Add(sortedImput.IndexOf(item2));
                    }
                }

            }


        }

        public static void SortInt()
        {
            int[] numbers = Enumerable.Range(0, 10).OrderBy(xp => Guid.NewGuid()).ToArray();






            Console.WriteLine(string.Join(",", numbers));

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

            // 
            Console.WriteLine(watch.Elapsed.TotalSeconds);


        }
    }
}
