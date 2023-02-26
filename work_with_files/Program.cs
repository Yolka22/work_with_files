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
            

            Base baze = new Base();

            baze.Read_Users();
            baze.Read_Quizes();
            baze.Main_Menu();
        }
    }
}