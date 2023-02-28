using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Project001.Repo.Interfaces;
using Project001.Repo.ModelsDTO;
using Project001.Repo.Repositories;

namespace Project001.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        IPersonRepository ipersonRepository;
        public PersonController(IPersonRepository per)
        {
            ipersonRepository = per;
        }

        [HttpGet("GetPersonAll")]
        public async Task<ActionResult> GetPersonAll()
        {
            return Ok(await ipersonRepository.getPerson());
        }
        [HttpGet("getPersonById")]
        public async Task<ActionResult> getPersonById(int id)
        {
            return Ok(await ipersonRepository.getPersonById(id));
        }
        [HttpGet("getPersonByName")]
        public async Task<ActionResult> getPersonByName(string name)
        {
            return Ok(await ipersonRepository.getPersonByName(name));
        }
        [HttpPost]
        public async Task<ActionResult> CreatePerson(Person Person)
        {
            var temp = await ipersonRepository.CreatePerson(Person);
            return CreatedAtAction("", temp);
        }
        [HttpPatch]
        public async Task<ActionResult> UpdatePerson(Person person)
        {
            await ipersonRepository.UpdatePerson(person);
            return NoContent();
        }
        [HttpDelete]    
        public async Task<ActionResult> DeletePerson(int id)
        {
            await ipersonRepository.DeletePerson(id);
            return NoContent();
        }
        [HttpDelete("DeletePersonByName")]

        public async Task<ActionResult> deletePersonName(string name) 
        {
            await ipersonRepository.DeletePersonByName(name);
            return NoContent();
        }
    }
}
