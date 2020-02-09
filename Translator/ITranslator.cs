namespace DeepFryBot
{
    public interface ITranslator
    {
        string TranslateText(string text, string sourceLanguage, string targetLanguage);
    }
}