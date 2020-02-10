using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ageebSoft.PassObjectToAspCoreAndReturnResult.WebAndApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ageebSoft.PassObjectToAspCoreAndReturnResult.WebAndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        // GET: api/Person
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return People;
        }

        // GET: api/Person/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return People.FirstOrDefault(x=>x.Id==id).Name;
        }

        // POST: api/Person
        [HttpPost]
        public IEnumerable<Person> Post([FromBody] Person value)
        {
            People.Add(value);
            return People;
        }

        // PUT: api/Person/5
        [HttpPut("{id}")]
        public IEnumerable<Person> Put(int id, [FromBody] string value)
        {
            var p=People.FirstOrDefault(x => x.Id == id);
            p.Name = value;
            return People;
        }


        private List<Person> People = new List<Person>
        {
            new Person{Id=1,Name="Mohamed ageeb",Gender=Gender.Male,Salary=10},
            new Person{Id=2,Name="AbuBaker Saleh",Gender=Gender.Male,Salary=20},
            new Person{Id=3,Name="Omer Altyeb",Gender=Gender.Male,Salary=30},
            new Person{Id=4,Name="Osman omer",Gender=Gender.Male,Salary=40},
            new Person{Id=5,Name="Ali Jubara",Gender=Gender.Male,Salary=50},
            new Person{Id=6,Name="Abdullah Rabee",Gender=Gender.Male,Salary=50},
            new Person{Id=7,Name="AbduRahman Omer",Gender=Gender.Male,Salary=60},
            new Person{Id=8,Name="AlHarih Amjad",Gender=Gender.Male,Salary=70},
            new Person{Id=9,Name="Mansor Omer",Gender=Gender.Male,Salary=80},
            new Person{Id=10,Name="Khaled Zuhir",Gender=Gender.Male,Salary=90},

        };

  


        [HttpPost(nameof(NewPersonStr))]
        public List<Person> NewPersonStr( Person person)
        {
            //var QueryString = HttpContext.Request.QueryString;
            //var body = HttpContext.Request.Body;
            //var header = HttpContext.Request.Headers;
            

            try
            {
                Person person1 = (Person)Convert.ChangeType(person, typeof(Person));

                People.Add(person1);
            }
            catch
            {

            }
            return People;
        }

        [HttpGet(nameof(SrchById))]
        public Person SrchById(int Id)
        {
            var ee = HttpContext.Request.QueryString;
            return People.FirstOrDefault(x => x.Id == Id);
        }

        [HttpGet(nameof(SrchByName))]
        public List<Person> SrchByName(string Name)
        {
            
            var ee = HttpContext.Request.QueryString;
            return People.Where(x =>  x.Name.Contains(Name, StringComparison.OrdinalIgnoreCase)).ToList();

        }


        [HttpGet(nameof(SrchBySalary))]

        public List<Person> SrchBySalary(double Salary)
        {
            var ee = HttpContext.Request.QueryString;
            return People.Where(x => x.Salary == Salary).ToList();

        }

        [HttpGet(nameof(SrchByTwoSalary))]
        public List<Person> SrchByTwoSalary(double Salary1, double Salary2)
        {
            var ee = HttpContext.Request.QueryString;
            double max = 0, min = 0;
            if(Salary1>Salary2)
            {
                max = Salary1;
                min = Salary2;
            }
            else
            {
                max = Salary2;
                min = Salary1;
            }



            return People.Where(x => x.Salary <= max && x.Salary>=min).ToList();

        }


    }
}
