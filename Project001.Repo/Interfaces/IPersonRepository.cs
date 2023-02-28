using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project001.Repo.ModelsDTO;
using Project001.Repo.Repositories;

namespace Project001.Repo.Interfaces
{
    public interface IPersonRepository
    {
        //Define methods - CRUD +/-
        public Task<List<Person>> getPerson();
        public Task<Person> getPersonById(int id);
        public Task<Person> getPersonByName(string name);
        public Task<Person> CreatePerson(Person person);
        public Task<Person> UpdatePerson(Person person);
        public Task<Person> DeletePerson(int id);
        public Task<Person> DeletePersonByName(string name);

    }
}
