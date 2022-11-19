using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
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
                var newStat = (stat.Value / 2) + stat.Value;
                stats.Remove(stats.First( x=> x.Key == stat.Key));
                stats.Add(new KeyValuePair<string, int>(stat.Key, newStat));
            }
        }
    }
}
