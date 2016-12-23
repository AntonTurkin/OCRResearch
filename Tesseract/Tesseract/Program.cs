using System;
using Tesseract;

namespace ConsoleApplication4
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var language = @"rus";//@"eng";//@"rus";
            var text = "No text";

            var blogPostImage = @"C:\2.png";

            using (var ocrEngine = new TesseractEngine(@".\tessdata", language, EngineMode.Default))
            {
                using (var imageWithText = Pix.LoadFromFile(blogPostImage))
                {
                    using (var page = ocrEngine.Process(imageWithText))
                    {
                        text = page.GetText();
                        Console.WriteLine(text);
                        Console.ReadLine();
                    }
                }
            }
        }
    }
}