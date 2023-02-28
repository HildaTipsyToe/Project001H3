using Microsoft.EntityFrameworkCore;
using Project001.Repo.Interfaces;
using Project001.Repo.ModelsDTO;


namespace Project001.Repo.Repositories
{
    public class CarRepository : IcarRepository
    {
        private readonly DataContext _context;

        public CarRepository()
        {
            _context = new();
        }
        public CarRepository(DataContext _context)
        {
            this._context = _context;
        }
        public async Task<List<Car>> getCar()
        {
            return await _context.Cars.ToListAsync();
        }
        public async Task<List<Car>> getCarByName(string Brandname)
        {
            return await _context.Cars.Where(c => c.Brand == Brandname).ToListAsync();
        }
        public async Task<Car> getCarById(int id)
        {
            var temp = await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);
            return temp;
        }
        public async Task<Car> UpdateCar(Car car)
        {
            var UpdateCar = await _context.Cars.FindAsync(car.Id);
            UpdateCar.Brand = car.Brand;

            await _context.SaveChangesAsync();

            return UpdateCar;
        }
        public async Task<Car> CreateCar(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return car;
        }
        public async Task<Car> DeleteCar(int id)
        {
            var delcar = await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);

            _context.Remove(delcar);
            await _context.SaveChangesAsync();
            return delcar;
        }
    }
}
