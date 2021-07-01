using DemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.DataAccess
{
    public class DemoDataAccess : IDataAccess
    {
        private List<PersonModel> people = new();

        public DemoDataAccess()
        {
            people.Add(new PersonModel { Id = 1, FirstNane = "Tim", LastName = "Corey" });
            people.Add(new PersonModel { Id = 2, FirstNane = "Ngozi", LastName = "Nsofor" });

        }

        public List<PersonModel> GetPeople()
        {
            return people;
        }

        public PersonModel GetPersonById(int id)
        {
            return people.Where(x => x.Id == id).FirstOrDefault();
        }

        public PersonModel InsertPerson(string firstName, string lastName)
        {
            PersonModel p = new() { FirstNane = firstName, LastName = lastName };
            p.Id = people.Max(x => x.Id) + 1;
            people.Add(p);
            return p;
        }

    }
}
