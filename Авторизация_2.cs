using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace лист_задание_2
{
    class Program
    {
        static List<string> mylist = null;
        static string path = "users.txt";
        static string UserName = "Никто не авторизован";
        static string[,] Users = null;
        
        
        static void Main(string[] args)
        {
            mylist = new List<string>();
            string cmd = null;
            bool gamerule = GetUsers();
            Console.WriteLine("Введите команду.");
            while (true)
            {
                Console.Write("$> ");
                cmd = Console.ReadLine();
                Command(cmd);
            }
            
        }

        static void Command(string cmd)
        {
            switch (cmd)
            {
                case "login":
                    Authorization();
                    break;
                case "logout":
                    UserName = "Никто не авторизован";
                    break;
                case "check":
                     CheckUsers();
                    break;
                case "delete":
                    Delete();
                    break;
                case "change":
                    ///Изменение логина или паролья для авторизированного пользователя
                    Change();
                    break;
                case "reg":
                    Registration();
                    break;
                case "status":
                    ///Вывод логина пользователя который авторизовался, либо сообщить о том что никого нет.
                    GetUser();
                    break;
                case "exit":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Неизвестная команда.");
                    break;
            }
        }

            static void GetUser()
            {
                if (String.IsNullOrEmpty(UserName))
                {
                    Console.WriteLine("Ни один пользователь не авторизован");

                }
                else
                {
                    Console.WriteLine("Пользователь авторизован: " + UserName);
                }
            }
        
        static bool GetUsers()
        {

            if (GetCountLines() < 1)
            {
                return false;
            }


            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                while (true)
                {
                    string line = sr.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    mylist.Add(line);
                }
            }

            return true;
        }

        static int GetCountLines()
        {
            int count = 0;

            if (!File.Exists(path))
            {
                return -1;
            }

            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                while (true)
                {
                    string line = sr.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    count++;
                }
            }

            return count;

        }
        static string[,] Registration()
        {
            string a;
            string o;
            string t;
            int z = 1;
            Console.WriteLine("Введите логин");
            a = Console.ReadLine();
            foreach (string item in mylist)
            {
                 string[] data = item.Split("|");
                if (a == data[0])
                {
                    z = 0;
                    Console.WriteLine("Данный логин занят другим пользователем");
                    break;
                }
            }
            if (z == 1)
            {
                Console.WriteLine("Введите пароль");
                o = Console.ReadLine();
                mylist.Add(a + "|" + o);
                t = (a + "|" + o);
                StreamWriter sw = new StreamWriter(path, true, Encoding.Default);
                foreach (string item in mylist)
                {
                    if (item == t)
                    {
                        sw.WriteLine(item);
                    }
                }
                sw.Close();
                sw.Dispose();
            }
            else
            {
                
            }
            return Users;
        }
        static void Authorization()
        {
            int t = -1;
            for (int i = -1; i < GetCountLines(); i++)
            {
                t = i;
            }
            if (t < 0)
            {
                Console.WriteLine("Ни один пользователь не зарегистрирован");
                Console.WriteLine("Зарегистрируйтесь пожалуйста");
                Registration();
                Console.WriteLine("Авторизируйтесь пожалуйста");
            }
            if (UserName != "Никто не авторизован")
            {
                Console.WriteLine("Один из пользователей уже авторизован,пожалуйста введите команду logout");
                return;
            }
            Console.Write("введите логин:");
            string login = Console.ReadLine();
            string anime = null;
            Console.Write("введите пароль:");
            string pass = Console.ReadLine();
            foreach (string item in mylist)
            {
                string[] data = item.Split('|');
                if (login == data[0])
                {
                    if (pass == data[1])
                    {
                        anime = "yes";
                        break;
                    }
                    else
                    {
                        anime = "no";
                    }
                }
                else
                {
                    anime = "no";
                }
                
            }
            if (anime == "yes")
            {
                Console.WriteLine("Вы авторизированы");
                UserName = login;
            }
            else
            {
                Console.WriteLine("Вы ввели неправильный логин или пароль");
            }


        }
        static void Change()
        {
            if (UserName == "Никто не авторизован")
            {
                Console.WriteLine("Вы не авторизированы");
            }
            else
            {
                string unicorn = null;
                Console.WriteLine("Введите команду.");
                while (true)
                {
                    Console.Write("&> ");
                    unicorn = Console.ReadLine();
                    Tblgdblk(unicorn);
                }
            }
        }
        static string Stroka()
        {
            string stroka = null;
            if (UserName != "Никто не авторизован")
            {
                string f = mylist.Find((h) => h.Contains(UserName));
                stroka = f;
            }
            return stroka;
        }
        static void Tblgdblk(string unicorn)
        {
            switch (unicorn)
            {
                case "login":
                    Changelogin();
                    break;
                case "pass":
                    Changepass();
                    break;
                case "exit":
                    string cmd = null;
                    Console.WriteLine("Введите команду.");
                    while (true)
                    {
                        Console.Write("$> ");
                        cmd = Console.ReadLine();
                        Command(cmd);
                    }
                    break;
                default:
                    Console.WriteLine("Неизвестная команда.");
                    break;
            }
        }
        static void Changelogin()
        {
            string stroka = Stroka();
            string prim;
            Console.WriteLine("Введите новый логин");
            prim = Console.ReadLine();
            string[] data = stroka.Split('|');
            data[0] = prim;
            string new_line = String.Join("|", data);
            mylist.Remove(stroka);
            mylist.Add(new_line);
            StreamWriter sw = new StreamWriter(path, false, Encoding.Default);
            foreach (string item in mylist)
            {
                sw.WriteLine(item);
            }
            sw.Close();
            sw.Dispose();

        }
        static void Changepass()
        {
            string stroka = Stroka();
            string prem;
            Console.WriteLine("Введите новый пароль");
            prem = Console.ReadLine();
            string[] data = stroka.Split('|');
            data[1] = prem;
            string new_line = String.Join("|", data);
            mylist.Remove(stroka);
            mylist.Add(new_line);
            StreamWriter sw = new StreamWriter(path, false, Encoding.Default);
            foreach (string item in mylist)
            {
                sw.WriteLine(item);
            }
            sw.Close();
            sw.Dispose();
        }
        static void CheckUsers()
        {
            foreach (string item in mylist)
            {
                string[] data = item.Split('|');
                Console.WriteLine(data[0]);
            }
        }
        static void Delete()
        {
            if (UserName != "Никто не авторизован")
            {
                string stroka = Stroka();
                mylist.Remove(stroka);
                Console.WriteLine("Вы успешно удалили свой аккаунт");
                StreamWriter sw = new StreamWriter(path, false, Encoding.Default);
                foreach (string item in mylist)
                {
                    sw.WriteLine(item);
                }
                sw.Close();
                sw.Dispose();
            }
            else
            {
                Console.WriteLine("Для удаления своего аккаунта нужно быть авторизованным");
            }
        }
    }
}
