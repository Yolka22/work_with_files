using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace work_with_files
{

    internal class Program
    {

        
        
        

       

        


        static void Main(string[] args)
        {
            //string path = "Users.txt";
            
            Base baza = new Base();


            //baza.Read_Users(path);

            //baza.add_user();
            //baza.add_user();
            //baza.add_user();

            //baza.Save_Users(path);

            baza.Show_User_List();

            //baza.add_quiz();
            //baza.Save_Quizes("Quizes.txt");
            baza.Read_Quizes("Quizes.txt");
            Console.ReadLine();

        }
    }
}