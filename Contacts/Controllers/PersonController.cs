using ContactsDataAccess;
using ContactsDataAccess.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Controllers
{
    public class PersonController : Controller
    {

        private readonly ContactsContext context;

        public PersonController(ContactsContext context)
        {
            this.context = context;
        }
       
        [HttpGet("Persons")]
        public async Task<IEnumerable<Person>> Index() => await context.Persons.AsNoTracking().ToListAsync();
        
        [HttpGet("Person")]
        public async Task<Person> Details(int id) => await context.Persons.AsNoTracking().SingleOrDefaultAsync(p => p.PersonId == id);
       

        [HttpPost("Person")]
        public async Task<Person> Create([FromBody]Person person)
        {
            await context.Persons.AddAsync(person);

            await context.SaveChangesAsync();

            return person;
        }

        [HttpPut("Person")]
        public async Task<Person> Update([FromBody]Person person)
        {
            context.Persons.Update(person);

            await context.SaveChangesAsync();
            
            return person;
        }

        [HttpDelete("Person")]
        public async Task<Person> Delete(int id)
        {
            var person = await context.Persons.SingleOrDefaultAsync(p => p.PersonId == id);

            context.Persons.Remove(person);

            await context.SaveChangesAsync();

            return person;
        }
    }
}
