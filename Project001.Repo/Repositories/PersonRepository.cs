using Microsoft.EntityFrameworkCore;
using Project001.Repo.Interfaces;
using Project001.Repo.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project001.Repo.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        // how do i use the DataBase?
        private readonly DataContext _context;

        public PersonRepository()
        {
            _context = new();
        }
        public PersonRepository( DataContext _context)
        {
            this._context = _context;
        }


        public async Task<List<Person>> getPerson()
        {
            return await _context.Person.ToListAsync();
        }
        public async Task<Person> getPersonById(int id)
        {
            var PersonReturn = await _context.Person.FindAsync(id);
            return PersonReturn;
        }
        public async Task<Person> getPersonByName(string name)
        {
            var PersonReturn = await _context.Person.FirstOrDefaultAsync(x => x.Name == name);
            return PersonReturn;
        }
        public async Task<Person> CreatePerson(Person person)
        {
            _context.Person.Add(person);
            await _context.SaveChangesAsync();
            return person;

        }
        public async Task<Person> UpdatePerson(Person person)
        {
            var PersonUpdate = await _context.Person.FindAsync(person.Id);

            PersonUpdate.Name = person.Name;
            PersonUpdate.Age = person.Age;
            PersonUpdate.cars = person.cars;

            await _context.SaveChangesAsync();
            return person;
        }
        public async Task<Person> DeletePerson(int id)
        {
            var PersonDel = await _context.Person
                .Include(c => c.cars)
                .FirstOrDefaultAsync(c => c.Id == id);
           


            _context.Person.Remove(PersonDel);
            await _context.SaveChangesAsync();
            return PersonDel;
        }
        public async Task<Person> DeletePersonByName(string name)
        {
            var personDel = await _context.Person
                .Include(c => c.cars)
                .FirstOrDefaultAsync(c => c.Name == name);

            _context.Person.Remove(personDel);

            await _context.SaveChangesAsync();
            return personDel;
        }
        public string GetName() { return "Killing this shit"; }
    }
}
