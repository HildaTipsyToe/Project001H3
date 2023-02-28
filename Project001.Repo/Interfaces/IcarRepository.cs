using Project001.Repo.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project001.Repo.Interfaces
{
    public interface IcarRepository
    {
        public Task<List<Car>> getCar();
        public Task<Car> getCarById(int id);
        public Task<List<Car>> getCarByName(string Brandname);
        public Task<Car> CreateCar(Car car);
        public Task<Car> UpdateCar(Car car);
        public Task<Car> DeleteCar(int id);
    }
}
