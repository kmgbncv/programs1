using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    
    class Program
    {
        static string path = "D:/Users.txt";
        static void Main(string[] args)
        {
            List<User> users = new List<User>();
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                string line = null;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] array = line.Split('|');
                    users.Add(new User(int.Parse(array[0]), array[1], array[2]));
                }
            }
            foreach(User user in users)
                user.Print();
            Console.ReadLine();
        }
    }
    
    public class User
    {
        private int id;
        private string log;
        private string pass;
        public int Id
        { 
              set { id = value; }
              get { return id; }
        }

        public string Login
        {
            set { log = value; }
            get { return log; } 
        }

        public string Pass 
        {
            set { pass = value; }
            get { return pass; } 
        }

        public User(int Id, string Login, string Pass)
        {
            this.id = Id;
            this.log = Login;
            this.pass = Pass;
        }



        
        public string Print()
        {
            string Out = String.Join(" ", this.id, this.log, this.pass);
            Console.WriteLine(Out);
            return Out;
        }

        
    }
}
