using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work_with_files
{
    internal class Score : IComparable
    {

            public int CompareTo(object obj)
            {
                if (obj is Score)
                {
                    return score.CompareTo((obj as Score).score);
                }
                throw new NotImplementedException();
            }

        public void Show()
        {

            Console.WriteLine(name+ ": " + score);

        }
            
            public string name;
            public int score;
    }
}
