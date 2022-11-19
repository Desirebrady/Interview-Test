using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace InterviewTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private static Hero[] heroes = new Hero[] {
               new Hero()
               {
                   id=1,
                   name= "Hulk",
                   power="Strength from gamma radiation",
                   stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 5000 ),
                       new KeyValuePair<string, int>( "intelligence", 50),
                       new KeyValuePair<string, int>( "stamina", 2500 )
                   }
               },
               new Hero()
               {
                   id=2,
                   name= "Spider Man",
                   power="Strength from spider",
                   stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 2500 ),
                       new KeyValuePair<string, int>( "intelligence", 105),
                       new KeyValuePair<string, int>( "stamina", 3500 )
                   }
               },
               new Hero()
               {
                   id=3,
                   name= "Iron Man",
                   power="Strength from iron man suit",
                   stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 4500 ),
                       new KeyValuePair<string, int>( "intelligence", 250),
                       new KeyValuePair<string, int>( "stamina", 4500 )
                   }
               },
               new Hero()
               {
                   id=4,
                   name= "Bat Man",
                   power="Strength from bat suit and money",
                   stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 3500 ),
                       new KeyValuePair<string, int>( "intelligence", 225),
                       new KeyValuePair<string, int>( "stamina", 3500 )
                   }
               }
            };

        // GET: api/Heroes
        [HttpGet]
        public IEnumerable<Hero> Get()
        {
            return heroes;
        }

        // GET: api/Heroes/5
        [HttpGet("{name}")]
        public Hero Get(string name)
        {
            return heroes.First(hero => hero.name == name);
        }

        // POST: api/Heroes
        [HttpPost("{name}/{value}")]
        public Hero Post(string name, string value = "none")
        {
            var hero = heroes.First(x => x.name == name);
            if (value == "action")
                hero.Evolve();
            return hero;
        }

        // PUT: api/Heroes/5
        [HttpPut("{name}")]
        public void Put(string name, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            heroes = heroes.Where(hero => hero.id != id).ToArray();
        }
    }
}
