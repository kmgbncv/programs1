using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            Camel camel = new Camel("Дромадер", 1, "Высокая", "Средний ", "Низкая", " 16 км/ч");

            string a = camel.ToString();

            Train train = new Train(Transport.SpeciesType.Underground, 960, Transport.СomfortType.VIP, "Большой", "Средняя", "140-200 км/ч");

            string b = train.ToString();

            Plane plane = new Plane("Стреловидное", "Пассажирский", 2250, "Большой", "Высокая", "500 - 800 км/ч");

            string c = plane.ToString();

            Sailboat sailboat = new Sailboat("6 m", 4, "761 т.", "Большой", "Высокая", "90 км/ч");

            string d = sailboat.ToString();
        }



        class Transport
        {
            internal enum SpeciesType
            {
                Aboveground,
                Underground
            }
            internal enum СomfortType
            {
                Сomfort,
                VIP
            }


            public Transport(string size, string cost, string speed)
            {
                this.Size = size;
                this.Cost = cost;
                this.Speed = speed;
            }
            public string Size { get; set; }
            public string Cost { get; set; }
            public string Speed { get; set; }
        }

        class Camel : Transport
        {


            public Camel(string breed, int the_number_of_humps, string endurance, string size, string cost, string speed) : base(size, cost, speed)
            {
                this.Breed = breed;
                this.The_number_of_humps = the_number_of_humps;
                this.Endurance = endurance;
            }
            public string Breed { get; set; }
            public int The_number_of_humps { get; set; }
            public string Endurance { get; set; }

            
        }

        class Train : Transport
        {



            public Train(SpeciesType species, int power_output, СomfortType comfort, string size, string cost, string speed) : base(size, cost, speed)
            {
                this.Species = species;
                this.Power_output = power_output;
                this.Сomfort = comfort;
            }

            public SpeciesType Species { get; set; }
            public int Power_output { get; set; }
            public СomfortType Сomfort { get; set; }
        }
        class Plane : Transport
        {


            public Plane(string wing_view, string appointment, int flying_distance, string size, string cost, string speed) : base(size, cost, speed)
            {
                this.Wing_view = wing_view;
                this.Appointment = appointment;
                this.Flying_distance = flying_distance;
            }

            public string Wing_view { get; set; }
            public string Appointment { get; set; }
            public int Flying_distance { get; set; }
        }
        class Sailboat : Transport

        {


            public Sailboat(string maximum_draft, int number_of_sails, string deadweight, string size, string cost, string speed) : base(size, cost, speed)
            {
                this.Maximum_draft = maximum_draft;
                this.Number_of_sails = number_of_sails;
                this.Deadweight = deadweight;
            }

            public string Maximum_draft { get; set; }
            public int Number_of_sails { get; set; }
            public string Deadweight { get; set; }
        }

        

    }


}

