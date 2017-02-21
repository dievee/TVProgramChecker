using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVProgramChecker.Managers;

namespace TVProgramChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            OVVAManager ovva = new OVVAManager();
            ovva.GetTodayTVProgram();
        }
    }
}
