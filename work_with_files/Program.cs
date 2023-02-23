using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace ConsoleApp2
{

    internal class Program
    {

        class User
        {

            public User() {


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

        }
        
        class Base
        {
            List<User> users;
            List<Quiz> quizes;
            public Base()
            {

                users = new List<User>();
                quizes = new List<Quiz>();

            }

            public void add_user()
            {

                User user = new User();

                Console.WriteLine("введите свое имя");
                user.Name = Console.ReadLine();
                Console.WriteLine("введите login");

                LOGIN:

                string login_check;
                login_check = Console.ReadLine();

                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].Login==login_check)
                    {
                        Console.WriteLine("этот login уже занят");
                        goto LOGIN;
                    }
                }
                user.Login = login_check;

                Console.WriteLine("введите пароль");
                string password_check = Console.ReadLine();

                user.Password = password_check;

                users.Add(user);
            }

            public void add_quiz()
            {
                Quiz quiz = new Quiz();

                Console.WriteLine("Чтобы добавить новую викторину сначала ввведите её имя");
                quiz.Name = Console.ReadLine();

                Console.WriteLine("На сколько вопросов будет ваша викторина?");
                int size = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < size; i++)
                {
                    quiz.Add_Question();
                }

                quizes.Add(quiz);
            }

            public void Save_Quizes(string path)
            {
                FileStream fs = new FileStream(path, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs, Encoding.Unicode);

                sw.WriteLine(quizes.Count);


                for (int i = 0; i < quizes.Count; i++)
                {
                    sw.WriteLine(quizes[i].Name);

                    sw.WriteLine(quizes[i].tasks.Count);

                    for (int j = 0; j < quizes[i].tasks.Count; j++)
                    {
                        sw.WriteLine(quizes[i].tasks[j].incorrect.Count());

                        sw.WriteLine(quizes[i].tasks[j].question);
                        sw.WriteLine(quizes[i].tasks[j].correct);

                        for (int k = 0;  k < quizes[i].tasks[j].incorrect.Count;  k++)
                        {
                            sw.WriteLine(quizes[i].tasks[j].incorrect[k]);
                        }
                    }

                }

                Console.WriteLine("Info was recorded");

                sw.Close();
                fs.Close();

            }


            public void Read_Quizes(string path)
            {
                String line;
                Quiz quiz = new Quiz();
                Task task = new Task();
                StreamReader sr = new StreamReader(path);


                line = sr.ReadLine();
                int Quizes_size = Convert.ToInt32(line);

                for (int i = 0; i < Quizes_size; i++)
                {


                    line = sr.ReadLine();
                    quiz.Name = line;
                    line = sr.ReadLine();
                    int questions_size = Convert.ToInt32(line);
                    line = sr.ReadLine();
                    int incorrect_size = Convert.ToInt32(line);
                    for (int j = 0; j < questions_size; j++)
                    {
                        line = sr.ReadLine();
                        task.question = line;
                        line = sr.ReadLine();
                        task.correct = line;

                        for (int k = 0; k < incorrect_size; k++)
                        {
                            line = sr.ReadLine();
                            task.incorrect.Add(line);


                        }
                        quiz.tasks.Add(task);
                        task=new Task();
                        line = sr.ReadLine();
                    }
                    
                    quizes.Add(quiz);
                    
                }
            }
            public void Save_Users(string path) {

                FileStream fs = new FileStream(path, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs, Encoding.Unicode);

                sw.WriteLine(users.Count);

                for (int i = 0; i < users.Count; i++)
                {
                        sw.WriteLine(users[i].Name);
                        sw.WriteLine(users[i].Login);
                        sw.WriteLine(users[i].Password);

                }

                Console.WriteLine("Info was recorded");

                sw.Close();
                fs.Close();
            }



            public void Read_Users(string path)
            {

                String line;
                try
                {
                    StreamReader sr = new StreamReader(path);

                    line = sr.ReadLine();
                    int size = Convert.ToInt32(line);

                    for (int i = 0; i < size; i++)
                    {
                        User user = new User();


                        line = sr.ReadLine();
                        user.Name = line;

                        line = sr.ReadLine();
                        user.Login = line;

                        line = sr.ReadLine();
                        user.Password = line;

                        users.Add(user);
                    }

                    //close the file
                    sr.Close();
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }



            public void Show_User_List() {

                for (int i = 0; i < users.Count; i++)
                {
                    Console.WriteLine(users[i].Name);
                }
            
            }
        }

        class Quiz
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
                while (tmp!="")
                {
                    task.incorrect.Add(tmp);
                    tmp = Console.ReadLine();
                }

                tasks.Add(task);

            }
        }

        class Task
        {
            public Task()
            {

                incorrect = new List<string>();

            }

            public string question;
            public string correct;
            public List<string> incorrect;
        }


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