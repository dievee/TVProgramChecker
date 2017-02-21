using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TVProgramChecker.Managers
{
    class PictureManager
    {
        public string ReduceImageResolution(ShowData sd)
        {
            int i = 0;
            foreach( Show s in sd.Shows)
            {
                DownloadImage( s.image.Preview, i.ToString() );

                i++;
            }

            return null;
        }

        public void DownloadImage(string url, string fileName)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(url,  fileName + ".jpg");  
            }
        }
    }
}
