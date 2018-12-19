using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace SWPLE_Lab8_ATM_Interface
{
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

            Run();

            Console.ReadKey();
        }

        private void Run()
        {
            Console.WriteLine(strings.Hello);
            Console.Write(strings.ToSwitchLanguages, currentLanguageFile.ButtonToogleLanguage);
            Console.WriteLine(strings.ToExit, currentLanguageFile.ButtonExit);

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
                Console.WriteLine(strings.NoValidChoice, key.KeyChar);
            }

            Console.WriteLine(separator);
            Run();
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