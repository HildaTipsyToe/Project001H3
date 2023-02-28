using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using Project001.API.Controllers;
using Project001.Repo.Interfaces;
using Project001.Repo.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project001.UnitTesting
{
    public class CarControllerTest
    {
        private readonly CarController carController;
        private readonly Mock<IcarRepository> Repo = new();

        public CarControllerTest()
        {
            this.carController= new CarController(Repo.Object);
        }

        public object ISstatusCodeActionResult { get; private set; }
        Car car = (new Car { Id = 1, Brand = "Volvo" });
        List<Car> cars = new List<Car>
            {
                new Car{Id = 1, Brand="Volvo"},
                new Car{Id = 2, Brand="BMW"},
                new Car{Id = 3, Brand="Toyota"}
            };
        [Fact]
        public async Task shouldGetAllCar()
        {
            //Arrange - Data, Initialize objects etc
            
            Repo.Setup(s => s.getCar()).ReturnsAsync(cars);

            //Act - Invoke our methods
            var result = await carController.getCar();

            //Assert - Call Assert, basicly a bool/ Chek the result and the Assert
            var statuscode = (IStatusCodeActionResult)result;
            Assert.Equal(200, statuscode.StatusCode);
        }
        [Fact]
        public async Task shouldGetCarById()
        {
            //Arrange - Data, initilize objects etc
            Repo.Setup(s => s.getCarById(It.IsAny<int>())).ReturnsAsync(car);

            //Act - Invoke our methods
            var result = await carController.getCarById(It.IsAny<int>());

            //Assert - Call Assert, bassicly a bool / check the result and the Assert
            var statuscode = (IStatusCodeActionResult)result;
            Assert.Equal(200, statuscode.StatusCode);
            
        }
        [Fact]
        public async Task shouldGetCarByName()
        {
            //Arrange - Data, initlize objects etc
            Repo.Setup(s => s.getCarByName(It.IsAny<string>())).ReturnsAsync(cars);

            //Act - Invoke our method
            var result = await carController.getCarByBrand(It.IsAny<string>());

            //Assert - Call 
            var statuscode = (IStatusCodeActionResult)result;
            Assert.Equal(200, statuscode.StatusCode);        
        }
        [Fact]
        public async Task shouldCreateCar()
        {
            //Arrange - Data, initlize objects etc
            Car car = (new Car { Id = 0, Brand = "Volvo" });
            Repo.Setup(s => s.CreateCar(It.IsAny<Car>())).ReturnsAsync(car);

            //Act - Invoke our method
            var result = await carController.CreateCar(car);

            //Assert - Call 
            var statuscode = (IStatusCodeActionResult)result;
            Assert.Equal(204, statuscode.StatusCode);
        }
        [Fact]
        public async Task shouldDeleteCar()
        {
            //Arrange - Data, initlize objects etc
            Car car = (new Car { Id = 10, Brand = "Volvo" });
            Repo.Setup(s => s.DeleteCar(It.IsAny<int>())).ReturnsAsync(car);

            //Act - Invoke our method
            var result = await carController.DeleteCar(It.IsAny<int>());

            //Assert - Call
            var statuscode = (IStatusCodeActionResult)result;
            Assert.Equal(204, statuscode.StatusCode);
        }
        [Fact]
        public async Task shouldUpdateCar()
        {
            //Arrange - Data, initlize objects etc
            Car car = (new Car { Id = 10, Brand = "Volvo" });
            Repo.Setup(s => s.UpdateCar(It.IsAny<Car>())).ReturnsAsync(car);

            //Act - Invoke our method
            var result = await carController.UpdateCar(It.IsAny<Car>());

            //Assert - Call 
            var statuscode = (IStatusCodeActionResult)result;
            Assert.Equal(204, statuscode.StatusCode);
        }
    }
}

//Arrange - Data, initlize objects etc

//Act - Invoke our method

//Assert - Call 

