using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using Project001.API.Controllers;
using Project001.Repo.Interfaces;
using Project001.Repo.ModelsDTO;
using Project001.Repo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project001.UnitTesting
{
    public class PersonControllerTest
    {
        // Simulate our PersonControllers...
        //cause, we dont use it.

        private readonly PersonController personController;

        //Using Moq
        private readonly Mock<IPersonRepository> Repo = new(); //I skal prøve med en class her
        public PersonControllerTest()
        {
            //this.personController = personController; // Autogenereet.
            //this.mockdata = mockdata; //Det er måske rigtig
            this.personController = new PersonController(Repo.Object);
        }
        // ? er om vores objekter skal initialiseres....
        
        //Method getPersonAll
        [Fact]
        public async Task ShouldGetAllPerson()
        {
            //Arrange - Data, initialize objects etc.
            List<Person> persons = new List<Person>
            {
                new Person {Id = 1, Name = "Casper"},
                new Person {Id = 2, Name = "Anders"},
                new Person {Id = 3, Name = "Jeppe"}
            };

            //We need to Mock our data!!! how??
            // mockdata is an object, "that is started" with the method
            //Setup(). ReturnsAsync- returns an obj, when getperson() is invoked
            Repo.Setup(s => s.getPerson()).ReturnsAsync(persons);

            //Act - Invoke our methods
            var result = await personController.GetPersonAll();

            //Assert - Call Assert, basicly a bool
            // Check the result and the Assert
            var content = (OkObjectResult)result;
            var statuscode = (IStatusCodeActionResult)result;
            Assert.Equal(200, statuscode.StatusCode);
            Assert.Equal(persons, content.Value);
        }
        [Fact]
        public async Task ShouldGetPersonById()
        {
            //Arrange - Data, initialize objects etc.

            Person person = (new Person { Id = 2, Name = "Bjarne" });
            Repo.Setup(s => s.getPersonById(2)).ReturnsAsync(person);

            //Act - Invoke our methods
            var result = await personController.getPersonById(2);

            //Assert - Call Assert, basicly a bool / Check the result and the Assert
            var Content = (OkObjectResult)result;
            var statuscode = (IStatusCodeActionResult)result;
            Assert.Equal(200, statuscode.StatusCode);
            Assert.Equal(person, Content.Value);
        }
        [Fact]
        public async Task shoudlGetPersonByName()
        {
            //Arrange - Data, initialize objects etc.
            Person person = (new Person { Id = 1, Name = "Bjarne" });
            Repo.Setup(s => s.getPersonByName("Bjarne")).ReturnsAsync(person);

            //Act - invoke our methods
            var result = await personController.getPersonByName("Bjarne");

            //Assert - Call Assert, Basicly a bool / check the result and the Assert
            var Content = (OkObjectResult)result; // for at få selve dataen ud
            var statuscode = (IStatusCodeActionResult)result;
            Assert.Equal(200, statuscode.StatusCode);   
            Assert.Equal(person, Content.Value);
        }
        [Fact]
        public async Task shouldCreatePerson()
        {
            //Arrange - Data, initialize objects etc.
            Person person = (new Person { Id = 0, Name = "Jens" });
            Repo.Setup(s => s.CreatePerson(It.IsAny<Person>())).ReturnsAsync(person);

            //Act - invoke our method
            var result = await personController.CreatePerson(person);

            //Assert - Call Assert, basicly a bool / check the result and the Assert
            var content = (CreatedAtActionResult)result;
            var statuscode = (IStatusCodeActionResult)result;
            Assert.Equal(201, statuscode.StatusCode);
            Assert.Equal(person, content.Value);
        }
        [Fact]
        public async Task shouldDeletePerson()
        {
            //Arrange - Data, initialize object etc.
            Person person = (new Person { Id = 10, Name = "Jens" });
            Repo.Setup(s => s.DeletePerson(It.IsAny<int>())).ReturnsAsync(person);

            //Act - invoke our method
            var result = await personController.DeletePerson(It.IsAny<int>());

            //Assert - Call Assert, basicly a bool / check the result and the Assert
            var statuscode = (IStatusCodeActionResult)result;
            Assert.Equal(204, statuscode.StatusCode);
        }
        [Fact]
        public async Task shouldDeletePersonByName()
        {
            //Arrange - Data, initilize object etc
            Person person = (new Person { Id = 10, Name = "Jens" });
            Repo.Setup(s => s.DeletePersonByName(It.IsAny<String>())).ReturnsAsync(person);

            //Act - invoke our method
            var result = await personController.deletePersonName(It.IsAny<String>());

            //Assert - Call Assert, basicly a bool / check the result and the Assert
            var statuscode = (IStatusCodeActionResult)result;
            Assert.Equal(204, statuscode.StatusCode);
        }
        [Fact]
        public async Task shouldUpdatePerson()
        {
            //Arrange - Data, initilize object etc
            Person person = (new Person { Id = 10, Name = "Jens" });
            Repo.Setup(s => s.UpdatePerson(It.IsAny<Person>())).ReturnsAsync(person);

            //Act - Invoke our method
            var result = await personController.UpdatePerson(It.IsAny<Person>());

            //Assert - Call Assert, basicly a bool / check the result and the Assert
            var statuscode = (IStatusCodeActionResult)result;
            Assert.Equal(204, statuscode.StatusCode);
        }
    }
}
