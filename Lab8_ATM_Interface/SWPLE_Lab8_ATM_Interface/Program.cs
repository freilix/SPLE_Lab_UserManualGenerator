namespace SWPLE_Lab8_ATM_Interface
{
    public class Program
    {
        public static void Main()
        {
            var german = new LanguageFile("de", 'u', 'v');
            var english = new LanguageFile("en", 't', 'x');
            var french = new LanguageFile("fr", 'q', 'w');

            var atm = new AtmUserInterface(german, english, french);
            atm.Start();
        }
    }
}
