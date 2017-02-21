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
            PictureManager pm = new PictureManager();

            string s = AppDomain.CurrentDomain.BaseDirectory;

            ShowData sd = new ShowData();
            sd = ovva.GetTodayTVProgram();

          sd = pm.ReduceImageResolution(sd);
            pm.GetFullProgramImage(sd);

        }
    }
}
