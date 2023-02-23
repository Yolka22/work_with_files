using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work_with_files
{
    internal class Task
    {
        public Task()
        {

            incorrect = new List<string>();

        }

        public string question;
        public string correct;
        public List<string> incorrect;
    }
}
