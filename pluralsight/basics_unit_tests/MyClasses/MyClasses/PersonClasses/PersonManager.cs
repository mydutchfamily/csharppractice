using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses.PersonClasses
{
    public class PersonManager
    {

        public Person CreatePerson(string first, string last, bool isSupervisor)
        {
            Person ret = null;

            if (!string.IsNullOrEmpty(first))
            {
                if (isSupervisor)
                {
                    ret = new Supervisor();
                }
                else
                {
                    ret = new Employee();
                }

                ret.FirstName = first;
                ret.LastName = last;
            }

            return ret;
        }

        public List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();

            people.Add(new Person() { FirstName = "Paul", LastName = "Sheriff" });
            people.Add(new Person() { FirstName = "John", LastName = "Kuhn" });
            people.Add(new Person() { FirstName = "Jim", LastName = "Ruhl" });

            return people;
        }

        public List<Person> GetSupervisor()
        {
            List<Person> people = new List<Person>();

            people.Add(CreatePerson(first : "Paul", last : "Sheriff", isSupervisor: true));
            people.Add(CreatePerson("John", "Kuhn", true));

            return people;
        }

        public List<Person> GetEmployees()
        {
            List<Person> people = new List<Person>();

            people.Add(CreatePerson(first: "Paul", last: "Sheriff", isSupervisor: false));
            people.Add(CreatePerson("John", "Kuhn", false));

            return people;
        }
    }
}
