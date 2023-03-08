using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work_with_files
{
    internal class User
    {

        public User()
        {


        }

        public User(string name)
        {
            Name = name;


        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        private string login;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private int score;

        public int Score
        {
            get { return score; }
            set { score = value; }
        }



        public void Start_Quiz(Quiz quiz, User user)

        {


            for (int i = 0; i < quiz.tasks.Count; i++)
            {

                string answer = quiz.tasks[i].correct;

                Console.WriteLine(quiz.tasks[i].question);

                string[] general = new string[quiz.tasks[i].incorrect.Count + 1];

                general[0] = quiz.tasks[i].correct;

                for (int j = 0; j < quiz.tasks[i].incorrect.Count; j++)
                {
                    general[j + 1] = quiz.tasks[i].incorrect[j];
                }

                var rand = new Random();
                rand.Shuffle(general);

                for (int j = 0; j < general.Length; j++)
                {
                    Console.WriteLine(general[j]);
                }

                Console.Write("введите свой ответ : ");
                string user_answer = Console.ReadLine().ToLower();
                if (user_answer == answer)
                {
                    user.Score += 100;
                }
            }


            quiz.Add_To_Table(user.Name, user.Score);
            user.Score = 0;
        }

        public void Change_Password()
        {

            Console.WriteLine("Введите новый пароль");

            Password = Console.ReadLine();

        }

    }
}
