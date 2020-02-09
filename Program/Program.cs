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
            DeepFryBot deepFryBot = new DeepFryBot(new GoogleTranslator());

            string result = deepFryBot.DeepFry("This is a test string.");

            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
