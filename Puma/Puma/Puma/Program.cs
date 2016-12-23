using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Puma.Net;

namespace ConsoleApplication5
{
    internal class Program
    {
        public static string ImageToText(string imageFilename)
        {
            string result = "";

            using (Bitmap load = new Bitmap(imageFilename))
            {
                //Распознавание
                PumaPage image = new PumaPage(load);
                using (image)
                {
                    image.FileFormat = PumaFileFormat.TxtIso;
                    image.AutoRotateImage = false;
                    image.EnableSpeller = true;
                    image.RecognizeTables = false;
                    image.FontSettings.DetectItalic = true;
                    image.Language = PumaLanguage.Russian;

                    try
                    {
                        result = image.RecognizeToString();
                    }
                    catch (Exception)
                    {
                        image.Dispose();
                    }
                }
            }

            return result;
        }

        private static void Main(string[] args)
        {
            var result = ImageToText(@"img/8.png");
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}