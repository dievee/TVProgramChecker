using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TVProgramChecker.Managers
{
    class PictureManager
    {
        public void ReduceImageResolution(ShowData sd)
        {
            int i = 0;
            foreach( Show s in sd.Shows)
            {
               string path = DownloadImage( s.image.Preview, i.ToString() );

                using (Bitmap bitmap = new Bitmap(path))
                {
                    Size size = new Size(bitmap.Width / 6, bitmap.Height / 6);
                    using (Bitmap newBitmap = new Bitmap(bitmap, size))
                    {
                        newBitmap.Save("n" + path);
                    }
                }

                File.Delete(path);
                i++;
            }

        }

        public string DownloadImage(string url, string fileName)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(url,  fileName + ".jpg");

                return fileName + ".jpg";
            }
        }
    }
}
