using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private Hero[] heroes = new Hero[] {
               new Hero()
               {
                   id= 1,
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
                   id= 2,
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
                   id= 3,
                   name= "Iron Man",
                   power="Strength from iron man suit",
                   stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 4500 ),
                       new KeyValuePair<string, int>( "intelligence", 250),
                       new KeyValuePair<string, int>( "stamina", 4500 )
                   }
               }
            };

        // GET: api/Heroes
        [HttpGet]
        public IEnumerable<Hero> Get()
        {
            return this.heroes;
        }

        // GET: api/Heroes/5
        [HttpGet("{id}")]
        public Hero Get(int id)
        {
            return this.heroes.Where(hero => hero.id == id).FirstOrDefault();
        }

        // POST: api/Heroes
        [HttpPost]
        public Hero Post(int id, [FromBody] string action = "none")
        {
            this.heroes.FirstOrDefault().Evolve();
            return this.heroes.FirstOrDefault();
        }

        // PUT: api/Heroes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.heroes = this.heroes.Where(hero => hero.id != id).ToArray();
        }
    }
}
