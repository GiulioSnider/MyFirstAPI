using EsercizioAPI___1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EsercizioAPI___1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private List<Person> people;
        private Person person;

        [HttpGet()]
        public string Ciao()
        {
            return "Ciao";
        }

        [HttpGet("initialize")]
        public void InizializeList()
        {
            people = new List<Person>();
        }

        [HttpGet("createPerson/{id}")]
        public void CreatePersonQueryParam(int id, string name, string surname)
        {
            person = new Person(id, name, surname);
            Console.WriteLine($"Id: {person.Id} Name: {person.Name} Surname: {person.Surname}");
        }
    }
}
