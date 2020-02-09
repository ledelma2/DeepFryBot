using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepFryBot
{
    class Program
    {
        static void Main(string[] args)
        {
            GoogleTranslator translator = new GoogleTranslator();

            string result = translator.TranslateText("i have seepage in my toaster", "English", "Slovenian");
            string back = translator.TranslateText(result, "Slovenian", "English");

            Console.WriteLine(back);

            Console.ReadKey();
        }
    }
}
