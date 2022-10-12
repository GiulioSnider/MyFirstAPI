using EsercizioAPI___1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EsercizioAPI___1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        public static List<Person> People { get; set; } = new List<Person>();
        public static List<int> Ints { get; set; } = new List<int>() { 1, 2, 3, 4, 5, 6, 8, 9, 6, 3, 2, 12, 34 };
        public static Person Person { get; set; } = new Person();

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
            return "ciao";
        }

        [HttpGet("createPerson/{id}")]
        public void CreatePersonQueryParam(int id, string name, string surname)
        {
            Person = new Person(id, name, surname);
            Console.WriteLine($"Id: {Person.Id} Name: {Person.Name} Surname: {Person.Surname}");
        }

        [HttpGet("getPerson")]
        public Person GetPerson()
        {
            return Person;
        }

        [HttpGet("addPersonToList")]
        public void AddToList()
        {
            People.Add(Person);
        }

        [HttpGet("getPeople")]
        public List<Person> GetPeople()
        {
            return People;
        }

        [HttpPost("addFromBody")]
        public void AddPersonFromBody([FromBody] Person person)
        {
            People.Add(person);
        }

        [HttpGet("evenInts")]
        public List<int> GetEven()
        {
            return Ints.Where(number => number % 2 == 0).ToList();
        }

        [HttpGet("getById")]
        public Person CustomWhere(int id)
        {
            return People.Where(person => person.Id == id).Single();
        }

        [HttpGet("custom")]
        public HttpResponseMessage CustomResponse()
        {
            return new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized) { Content = new StringContent("ciaone bellone")};
        }

    }
}
