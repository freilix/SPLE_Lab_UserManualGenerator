using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace SWPLE_Lab8_ATM_Interface
{
    public class AtmUserInterface
    {
        private readonly LanguageFile[] _supportedCultures;
        private LanguageFile _currentLanguageFile;
        private int _currentLanguageNumber;
        private string separator = "******************";

        public AtmUserInterface(params LanguageFile[] supportedCultures)
        {
            _supportedCultures = supportedCultures;
            _currentLanguageFile = supportedCultures.First();
            _currentLanguageNumber = 0;

            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(_currentLanguageFile.LanguageCode);
            GetDebugInformation();
        }

        public void Start()
        {
            Run();
        }

        private void Run()
        {
            Console.WriteLine(strings.Hello);
            Console.Write(strings.ToSwitchLanguages, _currentLanguageFile.ButtonToogleLanguage);
            Console.WriteLine(strings.ToExit, _currentLanguageFile.ButtonExit);

            var key = Console.ReadKey();
            Console.WriteLine();

            if (key.KeyChar == _currentLanguageFile.ButtonToogleLanguage)
            {
                // switch language
                _currentLanguageNumber += 1;
                _currentLanguageNumber %= _supportedCultures.Length;
                _currentLanguageFile = _supportedCultures[_currentLanguageNumber];
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(_currentLanguageFile.LanguageCode);
            }
            else if (key.KeyChar == _currentLanguageFile.ButtonExit)
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
            foreach (var supportedCulture in _supportedCultures)
            {
                Console.WriteLine("Supported: " + new CultureInfo(supportedCulture.LanguageCode).DisplayName);
            }
            Console.WriteLine("Default: " + new CultureInfo(_currentLanguageFile.LanguageCode).DisplayName);
            Console.WriteLine(separator);
        }
    }
}