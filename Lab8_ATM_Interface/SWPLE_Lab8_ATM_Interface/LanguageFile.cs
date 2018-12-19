namespace SWPLE_Lab8_ATM_Interface
{
    public class LanguageFile
    {
        public readonly string LanguageCode;
        public readonly char ButtonToogleLanguage;
        public readonly char ButtonExit;

        public LanguageFile(string languageCode, char buttonToogleLanguage, char buttonExit)
        {
            LanguageCode = languageCode;
            ButtonToogleLanguage = buttonToogleLanguage;
            ButtonExit = buttonExit;
        }
    }
}