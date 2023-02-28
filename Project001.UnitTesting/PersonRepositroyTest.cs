using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project001.Repo.ModelsDTO;
using Project001.API.Controllers;
using Project001.Repo.Interfaces;
using Project001.Repo.Repositories;
using Moq;

namespace Project001.UnitTesting
{
    public class PersonRepositroyTest
    {
        private readonly DbContextOptions<DataContext> options;
        private readonly DataContext _context;

        public PersonRepositroyTest()
        {
            options = new DbContextOptionsBuilder<DataContext>()
              .UseInMemoryDatabase(databaseName: "DatabaseContextPerson")
              .Options;

            _context = new DataContext(options);
            _context.Database.EnsureDeleted();

            _context.Person.Add(new Person { Id = 1, Name = "John", Age = 10 });
            _context.Person.Add(new Person { Id = 2, Name = "Karl", Age = 13 });
            _context.Person.Add(new Person { Id = 3, Name = "Johanne", Age = 13 });
            _context.Person.Add(new Person { Id = 4, Name = "Elmer", Age = 11 });
            _context.Person.Add(new Person { Id = 5, Name = "Inger", Age = 17 });
            _context.Person.Add(new Person { Id = 6, Name = "Ingolf", Age = 14 });
            _context.Person.Add(new Person { Id = 7, Name = "Lars", Age = 15 });

            _context.SaveChanges();
        }

        [Fact]
        public async Task shouldGetPersonALl()
        {
            //Arrange - Data, initlize objects etc
            PersonRepository personRepository = new PersonRepository(_context);

            //Act - Invoke our method
            var result = await personRepository.getPerson();

            //Assert - Call Assert, Basicly a bool / check the result and the Assert
            Assert.Equal(7, result.Count);
        }
        [Fact]
        public async Task shouldGetPersonById()
        {
            //Arrange - Data, initlize objects etc
            PersonRepository personRepository = new PersonRepository(_context);

            //Act - Invoke our method
            var result = await personRepository.getPersonById(1);

            //Assert - Call Assert, Basicly a bool / check the result and the Assert
            Assert.Equal(1, result.Id); Assert.Equal("John", result.Name); Assert.Equal(10, result.Age);
        }
        [Fact]
        public async Task shouldGetPersonByName()
        {

            //Arrange - Data, initlize objects etc
            PersonRepository personRepository = new PersonRepository(_context);

            //Act - Invoke our method
            var result = await personRepository.getPersonByName("Lars");

            //Assert - Call Assert, Basicly a bool / check the result and the Assert
            Assert.Equal(7, result.Id); Assert.Equal("Lars", result.Name); Assert.Equal(15, result.Age);
        }
        [Fact]
        public async Task shouldCreatePerson()
        {
            //Arrange - Data, initlize objects etc
            PersonRepository personRepository = new PersonRepository(_context);

            //Act - Invoke our method
            var result = await personRepository.CreatePerson(new Person { Id = 8, Name = "Jeppe", Age = 22 });

            //Assert - Call Assert, Basicly a bool / check the result and the Assert
            Assert.Equal(8, result.Id); Assert.Equal("Jeppe", result.Name); Assert.Equal(22, result.Age);
        }
        [Fact]
        public async Task shouldUpdatePerson()
        {
            //Arrange - Data, initlize objects etc
            PersonRepository personRepository = new PersonRepository(_context);

            //Act - Invoke our method
            var result = await personRepository.UpdatePerson(new Person { Id = 7, Name = "Ulla", Age = 15 });
            var resultcheck = await personRepository.getPersonById(7);

            //Assert - Call 
            Assert.Equal(7, result.Id); Assert.Equal("Ulla", result.Name); Assert.Equal(15, result.Age);
            Assert.Equal(7, resultcheck.Id); Assert.Equal("Ulla", resultcheck.Name); Assert.Equal(15, resultcheck.Age);
        }
        [Fact]
        public async Task shouldDeletePersonById()
        {
            //Arrange - Data, initlize objects etc
            PersonRepository personRepository = new PersonRepository(_context);

            //Act - Invoke our method
            var result = await personRepository.DeletePerson(7);
            var resultcheck = await personRepository.getPersonById(7);

            //Assert - Call
            Assert.Equal(7, result.Id); Assert.Equal("Lars", result.Name); Assert.Equal(15, result.Age); Assert.Null(resultcheck);
        }
        [Fact]
        public async Task shouldDeletePersonByName()
        {
            //Arrange - Data, initlize objects etc
            PersonRepository personRepository = new PersonRepository(_context);

            //Act - Invoke our method
            var result = await personRepository.DeletePersonByName("Lars");
            var resultcheck = await personRepository.getPersonByName("Lars");

            //Assert - Call Assert, Basicly a bool / check the result and the Assert
            Assert.Equal(7, result.Id); Assert.Equal("Lars", result.Name); Assert.Equal(15, result.Age); Assert.Null(resultcheck);
        }
        //Arrange - Data, initlize objects etc

        //Act - Invoke our method

        //Assert - Call Assert, Basicly a bool / check the result and the Assert
    }
}
