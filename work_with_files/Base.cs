using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work_with_files
{
    internal class Base
    {
        List<User> users;
        List<Quiz> quizes;
        public Base()
        {

            users = new List<User>();
            quizes = new List<Quiz>();

        }

        string users_path = "Users.txt";
        string quizes_path = "Quizes.txt";



        public Quiz Choose_Quiz()
        {
            Console.WriteLine("Выберите викторину из списка");
            int answer;
            int count = 1;
            for (int i = 0; i < quizes.Count; i++)
            {
                Console.WriteLine(count + " " +quizes[i].Name);
            }
            answer = Convert.ToInt32(Console.ReadLine());

            return quizes[answer-1];
        }
        public void Menu(User user)
        {
           
            int e;

            do
            {
                Console.WriteLine("\nЧто вы хотите?");
                Console.WriteLine("\nНачать викторину - 1;" +
                                  "\nПоказать топ по викторине - 2"+
                                  "\nДобавить викторину - 3"+
                                  "\nИзменить пароль - 4" +
                                  "\nВыйти - 5;" +
                                  "\n"); 

                e = Convert.ToInt32(Console.ReadLine());



                switch (e)
                {
                    case 1:

                        user.Start_Quiz(Choose_Quiz(), user);

                        break;

                    case 2:
                        Choose_Quiz().Show_Top();
                        break;

                    case 3:

                        add_quiz();

                        break;

                        case 4:

                        user.Change_Password();

                            break;

                    case 5:

                        Main_Menu();

                        break;
                }
                
            } while (e != 5);

            

        }
        public void Main_Menu()
        {

            Console.WriteLine("Зарегистрироваться - 1");
            Console.WriteLine("Войти - 2");
            Console.WriteLine("Выйти - 3");

            int e = Convert.ToInt32(Console.ReadLine());

            do
            {
                switch (e)
                {
                    case 1:

                        add_user();


                        break;

                    case 2:

                        Login();

                        break;

                    case 3:

                        Save_Quizes();
                        Save_Users();
                        Environment.Exit(0);
                        break;
                }
            } while (true);

           

        }
        public void Login()
        {


            Console.WriteLine("Введите login");
            
            string tmp_login = Console.ReadLine();
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Login == tmp_login)
                {
                
                    Console.WriteLine("Введите пароль");

                    string tmp_password = Console.ReadLine();
                    if (users[i].Password == tmp_password)
                    {
                            Menu(users[i]);
                    }
                    else
                    {

                        Console.WriteLine("Неверный пароль");

                    }


                }
                
            }
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
                if (users[i].Login == login_check)
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

            quiz.scores.Add(new Score());

            quizes.Add(quiz);
        }
        public void Save_Quizes()
        {
            FileStream fs = new FileStream(quizes_path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, Encoding.Unicode);

            sw.WriteLine(quizes.Count);


            for (int i = 0; i < quizes.Count; i++)
            {
                if (i>0)
                {
                    sw.WriteLine();
                }
                
                sw.WriteLine(quizes[i].Name);

                sw.WriteLine(quizes[i].tasks.Count);

                sw.WriteLine(quizes[i].scores.Count);

                for (int j = 0; j < quizes[i].scores.Count; j++)
                {
                    sw.WriteLine(quizes[i].scores[j].name);
                    sw.WriteLine(quizes[i].scores[j].score);
                }

                for (int j = 0; j < quizes[i].tasks.Count; j++)
                {
                    sw.WriteLine(quizes[i].tasks[j].incorrect.Count());

                    sw.WriteLine(quizes[i].tasks[j].question);
                    sw.WriteLine(quizes[i].tasks[j].correct);

                    for (int k = 0; k < quizes[i].tasks[j].incorrect.Count; k++)
                    {
                        sw.WriteLine(quizes[i].tasks[j].incorrect[k]);
                    }
                }

            }

            Console.WriteLine("Info was recorded");

            sw.Close();
            fs.Close();

        }
        public void Read_Quizes()
        {
            String line;
            
            Task task = new Task();
            StreamReader sr = new StreamReader(quizes_path);
            Score score = new Score();

            line = sr.ReadLine();
            int Quizes_size = Convert.ToInt32(line);

            for (int i = 0; i < Quizes_size; i++)
            {
                Quiz quiz = new Quiz();

                line = sr.ReadLine();
                quiz.Name = line;
                line = sr.ReadLine();
                int questions_size = Convert.ToInt32(line);

                line= sr.ReadLine();
                int score_board_size = Convert.ToInt32(line);
                for (int j = 0; j < score_board_size; j++)
                {
                    
                    line = sr.ReadLine();
                    score.name = line;
                    line = sr.ReadLine();
                    score.score = Convert.ToInt32(line);
                    quiz.scores.Add(score);
                }


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
                    task = new Task();
                    line = sr.ReadLine();
                }

                quizes.Add(quiz);

            }

            sr.Close();
        }
        public void Save_Users()
        {

            FileStream fs = new FileStream(users_path, FileMode.Create);
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
        public void Read_Users()
        {
            StreamReader sr = new StreamReader(users_path);
            String line;
            try
            {
                

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
                sr.Close();
                Console.WriteLine("Exception: " + e.Message);
            }
        }
        public void Show_User_List()
        {

            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine(users[i].Name);
            }

        }
    }
}
