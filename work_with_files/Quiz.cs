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
        public List<Score> scores = new List<Score>();

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

        public void Add_To_Table(string name, int score)
        {

            Score unit = new Score();
            unit.name = name;
            unit.score = score;

            scores.Add(unit);
        }



        public void Show_Top()

        {

           scores.Sort();


            if (scores.Count == 20) {

                for (int i = 0; i < 20; i++)
                {

                    scores[i].Show();

                }

            }
            else
            {
                for (int i = 0; i < scores.Count; i++)
                {
                    scores[i].Show();
                }
            }
            
        }

    }

   
}
