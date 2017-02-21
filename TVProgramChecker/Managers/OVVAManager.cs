using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TVProgramChecker.Managers
{
    class OVVAManager
    {
        private string url = "https://api.ovva.tv/v2/ua/tvguide/1plus1/";

        public object GetTodayTVProgram()
        {
            ShowData sd = new ShowData();
            try
            {
                WebClient wc = new WebClient();
                var json = wc.DownloadString(url);
                dynamic tvProgram = JsonConvert.DeserializeObject(json);

                List<Show> Shows = new List<Show>();
                sd.Shows = tvProgram.data.programs.ToObject<List<Show>>();
                sd.Date = tvProgram.data.date;
            }
            catch(Exception)
            {
                return null;
            }

            return sd;
        }
    }
}
