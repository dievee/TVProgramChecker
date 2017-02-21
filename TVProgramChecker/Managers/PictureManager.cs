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
        public ShowData ReduceImageResolution(ShowData sd)
        {
            int i = 0;
            foreach( Show s in sd.Shows)
            {
                string path = DownloadImage(s.image.Preview, i.ToString());

                using (Bitmap bitmap = new Bitmap(path))
                {
                    Size size = new Size(bitmap.Width / 6, bitmap.Height / 6);
                    using (Bitmap newBitmap = new Bitmap(bitmap, size))
                    {
                        newBitmap.Save("n" + path);
                    }
                }
                s.image.Preview = "n" + path;
                File.Delete(path);
                // s.image.Preview = "n" + i.ToString() + "jpg"; // delete this after uncomment
                i++;
            }

            return sd;
        }

        public string DownloadImage(string url, string fileName)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(url,  fileName + ".jpg");

                return fileName + ".jpg";
            }
        }

        public string GetFullProgramImage(ShowData sd)
        {
            int i = 0, currentHeight = 0;
            Bitmap fullProgramImage = new Bitmap(1000, sd.Shows.Count * 100);
            Graphics g = Graphics.FromImage(fullProgramImage);
            string status = "";
            foreach ( Show s in sd.Shows)
            {
                var beginTime = DateTimeOffset.FromUnixTimeSeconds(s.Realtime_begin).LocalDateTime;
                var endTime = DateTimeOffset.FromUnixTimeSeconds(s.Realtime_end).LocalDateTime;  // fix for bad localtime
                /// Drawling

                Bitmap showLogo = new Bitmap("n" + i.ToString() + ".jpg");
                g.DrawImage(showLogo, 0, i * 100, 128, 96);
                using (Font font = new Font("Arial", 10))
                {
                    g.DrawString(
                            s.Title,
                            font,
                            Brushes.Black,
                            138,
                            i * 100
                            );

                    g.DrawString(
                            s.Subtitle,
                            font,
                            Brushes.Black,
                            138,
                            i * 100 + 12
                            );

                    g.DrawString(
                            beginTime.TimeOfDay.ToString() + " - " + endTime.TimeOfDay.ToString(),
                            font,
                            Brushes.Black,
                            138,
                            i * 100 + 24
                            );

                    if (s.Is_on_the_air)
                        status = "Online";
                    else
                        status = "Offline";

                    g.DrawString(
                            status,
                            font,
                            Brushes.Black,
                            138,
                            i * 100 + 36
                            );

                    if (s.Will_broadcast_available)
                        status = "Broadcast available";
                    else
                        status = "Broadcast is not available";
                    g.DrawString(
                            status,
                            font,
                            Brushes.Black,
                            138,
                            i * 100 + 48
                            );
                }
                    ///
                    i++;
            }
            g.Dispose();
            fullProgramImage.Save("result.jpg");

            return null;
        }
    }
}
