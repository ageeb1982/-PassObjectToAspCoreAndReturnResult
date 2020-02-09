using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ageebSoft.PassObjectToAspCoreAndReturnResult.WebAndApi.Models;

namespace ageebSoft.PassObjectToAspCoreAndReturnResult.WebAndApi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }




        private List<Person> People = new List<Person>
        {
            new Person{Id=1,Name="Mohamed ageeb",Gender=Gender.Male},
            new Person{Id=2,Name="AbuBaker Saleh",Gender=Gender.Male},
            new Person{Id=3,Name="Omer Altyeb",Gender=Gender.Male},
            new Person{Id=4,Name="Osman Mobark",Gender=Gender.Male},
            new Person{Id=5,Name="Ali Jubara",Gender=Gender.Male},
            new Person{Id=6,Name="Abdullah Rabee",Gender=Gender.Male},
            new Person{Id=7,Name="AbduRahman Khaled",Gender=Gender.Male},
            new Person{Id=8,Name="AlHarih Amjad",Gender=Gender.Male},
            new Person{Id=9,Name="Mansor Omda",Gender=Gender.Male},
            new Person{Id=10,Name="Khaled Zuhir",Gender=Gender.Male},

        };

        public Person GetPerson(int Id)
        {
            return People.FirstOrDefault(x => x.Id == Id);
        }

        public List<Person> GetSrchName(string Name)
        {
            return People.Where(x => x.Name.Contains(Name,StringComparison.OrdinalIgnoreCase)).ToList();

        }
        public List<Person> GetSrchSalary(double Salary)
        {
            return People.Where(x => x.Salary == Salary).ToList();

        }  
        public List<Person> GetSrchTwoSalary(double Salary1,double Salary2)
        {
            return People.Where(x => x.Salary == Salary1).ToList();

        }



        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
