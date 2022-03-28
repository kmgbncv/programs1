using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Анна_Бычкова
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Напишите путь к начальному файлу.");
            string inpath = Console.ReadLine();

            Console.WriteLine("Напишите путь к конечному файлу.");
            string outpath = Console.ReadLine();

            
            if (outpath.Last<char>() != '\\')
            {
                outpath += "\\";
            }

            
            DirectoryInfo indir = new DirectoryInfo(inpath);

            
            FileInfo[] files = indir.GetFiles();

            
            foreach (FileInfo file in files)
            {
                string name = file.Name; 							
                string extension = file.Extension; 					
                string filename = name.Replace(extension, ""); 		

                filename = filename.ToLower(); 						

                string newname = Translate(filename); 				

                string fullname = outpath + newname + extension;    

                file.CopyTo(fullname); 								
            }
        }


        static public string Translate(string name)
        {
            string newname = string.Empty;

            #region Var1
            string[,] array = new string[,] 
            {
                {"а","a" },{ "б","b" },{ "в","v" },{ "г" ,"g" },{ "д" ,"d" },{ "е" ,"e" },{ "ё" ,"eo"},{ "ж" ,"j" },{ "з" ,"z" },{ "и" ,"i" },
                { "й","iy" },{ "к","k" },{ "л","l" },{"м","m"},{ "н","n" },{ "о","o" },{ "п","p" },{ "р","r" },{ "с","s" },{ "т","t" },{ "у","u" },
                { "ф","f" },{ "х","h" },{ "ц","c" },{ "ч","ch" },{ "ш","sh" },{ "щ","sh" },{ "ъ"," " },{ "ы","y" },{ "ь"," " },{ "э","e" },{ "ю","yu" },
                { "я","ia" },{ "-","-" },{ " ","_"},
                
            };
            #endregion

            char [] word = name.ToCharArray();

            foreach (char i in word)
            {

                int o = array.Length / 2;
                string t = Convert.ToString(i);
                for (int u = 0; u < o; u++)
                {
                    if (array[u,0]==t)
                    {
                        t = array[u, 1];
                        
                    }
                    
                }


                newname += t;
            }
           

            

            return newname;
        }
    }
}
