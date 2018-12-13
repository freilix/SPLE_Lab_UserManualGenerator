using System;
using System.Threading;
using System.Globalization;
using System.Linq;

namespace SWPLE_Lab8_ATM_Interface
{
    class Program
    {
        // private static readonly string[] SupportedCultures = { "de-DE", "en-US" };
    static void Main()
        {
            var german = new LanguageFile("de-DE", 'u', 'v');
            var english = new LanguageFile("en-US", 't', 'x');
            var atm = new AtmUserInterface(german, english);
            atm.Start();
        }
    }

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

    public class AtmUserInterface
    {
        private readonly LanguageFile[] _supportedCultures;
        private LanguageFile currentLanguageFile;
        private int currentLanguageNumber;
        private string separator = "******************";

        public AtmUserInterface(params LanguageFile[] supportedCultures)
        {
            _supportedCultures = supportedCultures;
            currentLanguageFile = supportedCultures.First();
            currentLanguageNumber = 0;
        }

        public void Start()
        {
            GetDebugInformation();

            DoSomething();

            Console.ReadKey();
        }

        private void DoSomething()
        {
            Console.WriteLine(strings.Hello);
            Console.Write(@"'" + currentLanguageFile.ButtonToogleLanguage + @"' ");
            Console.Write(strings.ToSwitchLanguages);
            Console.Write(@" '" + currentLanguageFile.ButtonExit + @"' ");
            Console.WriteLine(strings.ToExit);

            var key = Console.ReadKey();
            Console.WriteLine();

            if (key.KeyChar == currentLanguageFile.ButtonToogleLanguage)
            {
                // switch language
                currentLanguageNumber += 1;
                currentLanguageNumber %= _supportedCultures.Length;
                currentLanguageFile = _supportedCultures[currentLanguageNumber];
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(currentLanguageFile.LanguageCode);
            }
            else if (key.KeyChar == currentLanguageFile.ButtonExit)
            {
                // exit
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                Console.Write(strings.NoValidChoiceStart);
                Console.Write(@" '" + key.KeyChar + @"' ");
                Console.WriteLine(strings.NoValidChoiceEnd);
            }

            Console.WriteLine(separator);
            DoSomething();
        }

        private void GetDebugInformation()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");
            Console.WriteLine(strings.Hello);

            foreach (var supportedCulture in _supportedCultures)
            {
                Console.WriteLine("Supported: " + new CultureInfo(supportedCulture.LanguageCode).DisplayName);
            }
            Console.WriteLine("Default: " + new CultureInfo(currentLanguageFile.LanguageCode).DisplayName);
            Console.WriteLine(separator);
        }
    }
}
