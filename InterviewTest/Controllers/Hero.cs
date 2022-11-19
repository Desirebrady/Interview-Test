using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewTest.Controllers
{
    public class Hero : IHero
    {
        public long id { get; set; }
        public string name { get; set; }
        public string power { get; set; }
        public List<KeyValuePair<string, int>> stats { get; set; }
        public void Evolve(int statIncrease = 5)
        {
            foreach (var stat in stats.ToList())
            {
                Console.WriteLine(stat.Key);

                //var removeIndex = stats.FindIndex(stat => stat.Key == stat.key);
                //removeIndex.RemoveAt(removeIndex);
                //stats.Add(new KeyValuePair<string, string>(stat.key,  stat.Value + statIncrease));
            }
        }
    }
}
