using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepFryBot
{
    public class DeepFryBot
    {
        private readonly ITranslator translator;

        public DeepFryBot(ITranslator translator)
        {
            this.translator = translator;
        }

        public string DeepFry(string text)
        {
            string result = translator.TranslateText(text, "English", "Slovenian");
            return translator.TranslateText(result, "Slovenian", "English");
        }
    }
}
