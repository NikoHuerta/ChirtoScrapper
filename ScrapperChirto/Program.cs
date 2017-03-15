using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace ScrapperChirto
{
    class Program
    {
        static void Main(string[] args)
        {

            //URL CARTAS GRANDES http://www.chirto.com.ar/img/cards/1.jpg
            //URL CARTAS PEQUEÑAS http://www.chirto.com.ar/img/cards2/1.jpg

            string url_comun_norm = "http://www.chirto.com.ar/img/cards/";
            string final_url_jpg = ".jpg";
            string final_url_gif = ".gif";
            string url_comun_mini = "http://www.chirto.com.ar/img/cards2/";

            Console.WriteLine("Scrapper Trucho by N.Huerta!");

            int contador = 1;
            Console.WriteLine("Guardado automatico en carpetas: C:/ChirtoExports/Full - C:/ChirtoExports/Mini");
            Console.WriteLine();
            Console.WriteLine("Iniciando RESCATEEEE...  " + DateTime.Now.ToString());

            while (contador < 1338)
            {
                using (WebClient webClient = new WebClient())
                {
                    //INICIO FULL ART
                    try
                    {
                        byte[] data = webClient.DownloadData(url_comun_norm + contador.ToString() + final_url_jpg);
                        File.WriteAllBytes("C:/ChirtoExports/Full/" + contador.ToString() + ".jpg", data);
                    }
                    catch
                    {
                        byte[] data = webClient.DownloadData(url_comun_norm + contador.ToString() + final_url_gif);
                        File.WriteAllBytes("C:/ChirtoExports/Full/" + contador.ToString() + ".gif", data);
                    }
                    
                    //INICIO MINIATURAS
                    try
                    {
                        byte[] data = webClient.DownloadData(url_comun_mini + contador.ToString() + final_url_jpg);
                        File.WriteAllBytes("C:/ChirtoExports/Mini/" + contador.ToString() + ".jpg", data);
                    }
                    catch
                    {
                        byte[] data = webClient.DownloadData(url_comun_mini + contador.ToString() + final_url_gif);
                        File.WriteAllBytes("C:/ChirtoExports/Mini/" + contador.ToString() + ".gif", data);
                    }
                   
                    
                }
                
                contador++;
            }
            Console.WriteLine("Finalizado, rescate exitoso. " + DateTime.Now.ToString());
            
        }

    }
}
