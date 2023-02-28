using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Project001.Repo.ModelsDTO;
using Project001.Repo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project001.UnitTesting
{
    public class CarRepositoryTest
    {
        private readonly DbContextOptions<DataContext> options;
        private readonly DataContext _context;

        public CarRepositoryTest()
        {
            options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "DataBaseContextCar").Options;

            _context = new DataContext(options);
            _context.Database.EnsureDeleted();

            _context.Cars.Add(new Car { Id = 1, Brand = "Volvo" });
            _context.Cars.Add(new Car { Id = 2, Brand = "BMW" });
            _context.Cars.Add(new Car { Id = 3, Brand = "Toyota" });
            _context.Cars.Add(new Car { Id = 4, Brand = "Skoda" });
            _context.Cars.Add(new Car { Id = 5, Brand = "Mercedes" });
            _context.Cars.Add(new Car { Id = 6, Brand = "Volkswagen" });
            _context.Cars.Add(new Car { Id = 7, Brand = "Hyundai" });
            _context.Cars.Add(new Car { Id = 8, Brand = "Mercedes" });

            _context.SaveChanges();
        }
        [Fact]
        public async Task shouldGetCar()
        {
            //Arrange - Data, initlize objects etc
            CarRepository carRepository = new CarRepository(_context);

            //Act - Invoke our method
            var result = await carRepository.getCar();

            //Assert - Call Assert, Basicly a bool / check the result and the Assert
            Assert.Equal(8, result.Count);
        }
        [Fact]
        public async Task shouldGetCarById()
        {
            //Arrange - Data, initlize objects etc
            CarRepository carRepository = new CarRepository(_context);

            //Act - Invoke our method
            var result = await carRepository.getCarById(1);

            //Assert - Call Assert, Basicly a bool / check the result and the Assert
            Assert.Equal(1, result.Id); Assert.Equal("Volvo", result.Brand);
        }

        [Fact]
        public async Task shouldGetCarByName()
        {
            //Arrange - Data, initlize objects etc
            CarRepository carRepository = new CarRepository(_context);

            //Act - Invoke our method
            var result = await carRepository.getCarByName("Mercedes");

            //Assert - Call Assert, Basicly a bool / check the result and the Assert
            Assert.Equal(2, result.Count); 
        }
        [Fact]
        public async Task shouldCreateCar()
        {
            //Arrange - Data, initlize objects etc
            CarRepository carRepository = new CarRepository(_context);

            //Act - Invoke our method
            var result = await carRepository.CreateCar(new Car { Id = 9, Brand = "Volvo" });
            var resultcheck = await carRepository.getCar();

            //Assert - Call Assert, Basicly a bool / check the result and the Assert
            Assert.Equal(9, result.Id); Assert.Equal("Volvo", result.Brand); Assert.Equal(9, resultcheck.Count);
        }

        [Fact]
        public async Task shouldDeleteCar()
        {
            //Arrange - Data, initlize objects etc
            CarRepository carRepository = new CarRepository(_context);

            //Act - Invoke our method
            var result = await carRepository.DeleteCar(6);
            var resultcheck = await carRepository.getCarById(6);

            //Assert - Call Assert, Basicly a bool / check the result and the Assert
            Assert.Equal(6, result.Id); Assert.Equal("Volkswagen", result.Brand); Assert.Null(resultcheck);
        }
        [Fact]
        public async Task shouldUpdateCar()
        {
            //Arrange - Data, initlize objects etc
            CarRepository carRepository = new CarRepository(_context);

            //Act - Invoke our method
            await carRepository.UpdateCar(new Car { Id = 1, Brand = "John Deere" });
            var resultcheck = await carRepository.getCarById(1);

            //Assert - Call Assert, Basicly a bool / check the result and the Assert
            Assert.Equal(1, resultcheck.Id); Assert.Equal("John Deere", resultcheck.Brand);
        
        }
        //Arrange - Data, initlize objects etc
        //CarRepository carRepository = new CarRepository(_context);

        //Act - Invoke our method

        //Assert - Call Assert, Basicly a bool / check the result and the Assert_
    }
}
