using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project001.Repo.Interfaces;
using Project001.Repo.ModelsDTO;
using Project001.Repo.Repositories;

namespace Project001.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        IcarRepository icarRepository;
        public CarController(IcarRepository Icar)
        {
            this.icarRepository = Icar;
        }

        [HttpGet("GetPersonAll")]
        public async Task<ActionResult> getCar()
        {
            return Ok(await icarRepository.getCar());
        }
        [HttpGet("GetCarById")]
        public async Task<ActionResult> getCarById(int id)
        {
            return Ok(await icarRepository.getCarById(id));
        }
        [HttpGet("GetCarBybrand")]
        public async Task<ActionResult> getCarByBrand(string name)
        {
            return Ok(await icarRepository.getCarByName(name));
        }
        [HttpPost]
        public async Task<ActionResult> CreateCar(Car car)
        {
            await icarRepository.CreateCar(car);
            return NoContent();
        }
        [HttpPatch]
        public async Task<ActionResult> UpdateCar(Car car)
        {
            await icarRepository.UpdateCar(car);
            return NoContent();
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteCar(int id)
        {
            await icarRepository.DeleteCar(id);
            return NoContent();
        }
    }
}
