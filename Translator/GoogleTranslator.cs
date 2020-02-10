using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace DeepFryBot
{
    public class GoogleTranslator : ITranslator
    {
        private readonly string client;
        private readonly string baseUrl;
        private readonly string addressUrl;
        private readonly List<Language> Languages = new List<Language>
        {
            new Language { Name = "Afrikaans", Code = "af" },
            new Language { Name = "Irish", Code = "ga" },
            new Language { Name = "Albanian", Code = "sq" },
            new Language { Name = "Italian", Code = "it" },
            new Language { Name = "Arabic", Code = "ar" },
            new Language { Name = "Japanese", Code = "ja" },
            new Language { Name = "Azerbaijani", Code = "az" },
            new Language { Name = "Kannada", Code = "kn" },
            new Language { Name = "Basque", Code = "eu" },
            new Language { Name = "Korean", Code = "ko" },
            new Language { Name = "Bengali", Code = "bn" },
            new Language { Name = "Latin", Code = "la" },
            new Language { Name = "Belarusian", Code = "be" },
            new Language { Name = "Latvian", Code = "lv" },
            new Language { Name = "Bulgarian", Code = "bg" },
            new Language { Name = "Lithuanian", Code = "lt" },
            new Language { Name = "Catalan", Code = "ca" },
            new Language { Name = "Macedonian", Code = "mk" },
            new Language { Name = "Chinese Simplified", Code = "zh-CN" },
            new Language { Name = "Malay", Code = "ms" },
            new Language { Name = "Chinese Traditional", Code = "zh-TW" },
            new Language { Name = "Maltese", Code = "mt" },
            new Language { Name = "Croatian", Code = "hr" },
            new Language { Name = "Norwegian", Code = "no" },
            new Language { Name = "Czech", Code = "cs" },
            new Language { Name = "Persian", Code = "fa" },
            new Language { Name = "Danish", Code = "da" },
            new Language { Name = "Polish", Code = "pl" },
            new Language { Name = "Dutch", Code = "nl" },
            new Language { Name = "Portuguese", Code = "pt" },
            new Language { Name = "English", Code = "en" },
            new Language { Name = "Romanian", Code = "ro" },
            new Language { Name = "Esperanto", Code = "eo" },
            new Language { Name = "Russian", Code = "ru" },
            new Language { Name = "Estonian", Code = "et" },
            new Language { Name = "Serbian", Code = "sr" },
            new Language { Name = "Filipino", Code = "tl" },
            new Language { Name = "Slovak", Code = "sk" },
            new Language { Name = "Finnish", Code = "fi" },
            new Language { Name = "Slovenian", Code = "sl" },
            new Language { Name = "French", Code = "fr" },
            new Language { Name = "Spanish", Code = "es" },
            new Language { Name = "Galician", Code = "gl" },
            new Language { Name = "Swahili", Code = "sw" },
            new Language { Name = "Georgian", Code = "ka" },
            new Language { Name = "Swedish", Code = "sv" },
            new Language { Name = "German", Code = "de" },
            new Language { Name = "Tamil", Code = "ta" },
            new Language { Name = "Greek", Code = "el" },
            new Language { Name = "Telugu", Code = "te" },
            new Language { Name = "Gujarati", Code = "gu" },
            new Language { Name = "Thai", Code = "th" },
            new Language { Name = "Haitian Creole", Code = "ht" },
            new Language { Name = "Turkish", Code = "tr" },
            new Language { Name = "Hebrew", Code = "iw" },
            new Language { Name = "Ukrainian", Code = "uk" },
            new Language { Name = "Hindi", Code = "hi" },
            new Language { Name = "Urdu", Code = "ur" },
            new Language { Name = "Hungarian", Code = "hu" },
            new Language { Name = "Vietnamese", Code = "vi" },
            new Language { Name = "Icelandic", Code = "is" },
            new Language { Name = "Welsh", Code = "cy" },
            new Language { Name = "Indonesian", Code = "id" },
            new Language { Name = "Yiddish", Code = "yi" }
        };

        public GoogleTranslator()
        {
            client = "gtx";
            baseUrl = @"https://translate.googleapis.com";
            addressUrl = $@"{baseUrl}/translate_a/single?client={client}";
        }

        public string TranslateText(string text, string sourceLanguage, string targetLanguage)
        {
            Language source = Languages.Find(l => l.Name == sourceLanguage);
            Language target = Languages.Find(l => l.Name == targetLanguage);

            string requestUrl = $"{addressUrl}&sl={source.Code}&tl={target.Code}&dt=t&q={Uri.EscapeDataString(text)}";

            string contents;
            using (var wc = new System.Net.WebClient { Encoding = Encoding.UTF8 })
                contents = wc.DownloadString(requestUrl);

            JArray json = JArray.Parse(contents);

            string translatedText = json[0][0][0].ToObject<string>();

            return translatedText;
        }

    }
}
