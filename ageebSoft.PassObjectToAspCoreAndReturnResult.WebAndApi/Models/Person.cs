using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ageebSoft.PassObjectToAspCoreAndReturnResult.WebAndApi.Models
{
    public class Person
    {

        public int Id { set; get; }

        public string Name { set; get;  }

        public Gender Gender { set; get; }

        public double Salary { set; get; }
    }
}

namespace ageebSoft.PassObjectToAspCoreAndReturnResult.WebAndApi
{
   public  enum Gender
    {
        Male=0,
        Female=1
    }
}