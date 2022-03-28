using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication24
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee person = new Employee("Vasya", Person.GenderType.Male, "Стажер");

            //person.DateBirth = DateTime.Parse("05/14/2001");

            string a = person.ToString();

        }
    }

    class Person
    {
        internal enum GenderType
        {
            Male,
            Female
        }

        public Person(string name, GenderType gender)
        {
            this.Name = name;
            this.Gender = gender;
        }

        public string Name { get; set; }
        public DateTime DateBirth { get; set; }
        public GenderType Gender { get; set; }

        public virtual void PrintName()
        {
            Console.WriteLine(Name);
        }
    }

    class Employee : Person
    {

        public Employee(string name, GenderType gender, string rank) 
            : base(name, gender)
        {
            Rank = rank;
        }

        public string Rank { get; set; }


        public override void PrintName()
        {
            Console.WriteLine(base.Name + " " + Rank);
        }

        public override string ToString()
        {
            return base.Name + " " + Rank;
        }

    }

}
