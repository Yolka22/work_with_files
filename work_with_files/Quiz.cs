using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work_with_files
{
    internal class Quiz
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public List<Task> tasks = new List<Task>();


        public void Add_Question()
        {
            Task task = new Task();

            Console.WriteLine("введите вопрос");
            task.question = Console.ReadLine();

            Console.WriteLine("введите ответ на него");
            task.correct = Console.ReadLine();


            Console.WriteLine("введите пару неправильных ответов после чего с пустой строки введите Enter");
            string tmp = Console.ReadLine();
            while (tmp != "")
            {
                task.incorrect.Add(tmp);
                tmp = Console.ReadLine();
            }

            tasks.Add(task);

        }
    }
}
