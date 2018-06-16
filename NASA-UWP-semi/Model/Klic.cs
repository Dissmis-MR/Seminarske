using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NASA_UWP_semi.Model
{
    class Klic
    {
        
        public static async Task NabiSlike(List<Photo> photo)
        {
            string url = "https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?sol=1000&api_key=Lrz4OkyLYiK8hlmziy8n0So6SyaQwMjXB0z9Ect3";
            using (var klient = new HttpClient())
            {
                HttpResponseMessage p = await klient.GetAsync(url);
                Podatki vsa = await p.Content.ReadAsAsync<Podatki>();
                foreach (var ph in vsa.photos)
                    photo.Add(ph);
            }
        }
    }
}
