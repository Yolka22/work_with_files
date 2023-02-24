using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace work_with_files
{
    static class RandomExtensions
    {
        public static void Shuffle<T>(this Random rng, T[] array)
        {
            int n = array.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
    }
    internal class Program
    {


        static void Main(string[] args)
        {
            string user_path = "Users.txt";
            string quiz_path = "Quizes.txt";
            Base baza = new Base();


            baza.Read_Users(user_path);
            baza.Read_Quizes(quiz_path);

            //baza.add_user();
            //baza.add_user();
            //baza.add_user();



            baza.Show_User_List();

            baza.Login();
            
            //baza.add_quiz();
            baza.Save_Quizes(quiz_path);
            baza.Save_Users(user_path);


            Console.ReadLine();

        }
    }
}