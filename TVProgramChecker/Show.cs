using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVProgramChecker
{
    public class Show
    {
        public Image image { get; set; }
        public int Realtime_begin { get; set; }
        public int Realtime_end { get; set; }
        public bool Will_broadcast_available { get; set; }
        public bool Is_on_the_air { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
    }
    public class Image
    {
        public string Preview { get; set; }
    }
    public class ShowData
    {
        public string Date { get; set; }
        public List<Show> Shows { get; set; }
    }
}
