using EsercizioAPI___1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EsercizioAPI___1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        public List<Person> People { get; set; }
        public List<int> Ints { get; set; }
        public Person Person { get; set; }

        public PersonController()
        {
            Ints = new List<int>();
            People = new List<Person>();
        }

        [HttpGet("popInts")]
        public void PopulateInts()
        {            
            Random rnd = new Random();
            for (int i = 0; i < 20; i++)
                Ints.Add(rnd.Next());
        }

        [HttpGet("getInts")]
        public List<int> GetInts()
        {
            return Ints;
        }

        [HttpGet()]
        public string Ciao()
        {
            return "Ciao";
        }
        
        [HttpGet("createPerson/{id}")]
        public void CreatePersonQueryParam(int id, string name, string surname)
        {
            Person = new Person(id, name, surname);
            Console.WriteLine($"Id: {Person.Id} Name: {Person.Name} Surname: {Person.Surname}");
        }


    }
}
