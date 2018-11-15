using System;
using System.IO;
using System.Text;

namespace ConfigCreator
{
    public class Program
    {
        public static string RadioName;
        public static bool HoldTuning;
        public static bool NumericKeypadSearch;
        public static string BluedotButtonTypeLeft;
        public static string BluedotButtonTypeRight;
        public static Language BluedotManualLanguage;
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Please name your radio: ");
            RadioName = Console.ReadLine();

            Console.WriteLine("Do you want the possibility to hold tuning button for faster search? Yes(y) or No(n)");
            var key = Console.ReadKey();
            Console.WriteLine();
            if (key.Key == ConsoleKey.Y)
                HoldTuning = true;

            Console.WriteLine("Which button type do you want for the left button? <-- (1) or &larr; (2)");
            var keyButtonLeft = Console.ReadKey();
            Console.WriteLine();
            if (keyButtonLeft.KeyChar == '1')
                BluedotButtonTypeLeft = "&lt;&lt;";
            else if (keyButtonLeft.KeyChar == '2')
                BluedotButtonTypeLeft = "&larr;";
            else
                BluedotButtonTypeLeft = "&lt;&lt;";

            Console.WriteLine("Which button type do you want for the right button? --> (1) or &rarr; (2)");
            var keyButtonRight = Console.ReadKey();
            Console.WriteLine();
            if (keyButtonRight.KeyChar == '1')
                BluedotButtonTypeRight = "&gt;&gt;";
            else if (keyButtonLeft.KeyChar == '2')
                BluedotButtonTypeRight = "&rarr;";
            else
                BluedotButtonTypeRight = "&gt;&gt;";

            Console.WriteLine("Do you want the numeric keypad search? Yes(y) or No(n)");
            var key1 = Console.ReadKey();
            Console.WriteLine();
            if (key1.Key == ConsoleKey.Y)
                NumericKeypadSearch = true;

            Console.WriteLine("Which language? English(e) or german(g)");
            var languageKey = Console.ReadKey();
            Console.WriteLine();
            if (languageKey.KeyChar == 'g')
                BluedotManualLanguage = Language.Bluedot_Manual_Language_German;
            else
                BluedotManualLanguage = Language.Bluedot_Manual_Language_English;

            var configString = BuildConfig();
            var fileNamePath = "Config_" + RadioName + ".txt";
            var fileStream = File.Create(fileNamePath);
            fileStream.Close();
            var streamWriter = File.AppendText(fileNamePath);
            streamWriter.Write(configString);
            streamWriter.Flush();
            streamWriter.Close();

            WriteFirstLine("_RadioManual.cpp", "#include \"" + fileNamePath + "\"");
        }

        private static string BuildConfig()
        {
            var sb = new StringBuilder();
            sb.AppendLine("#ifdef " + RadioName.ToUpper());
            sb.AppendLine("\t#define Bluedot_City_Name " + RadioName);
            if (HoldTuning)
                sb.AppendLine("\t#define HoldTuning");
            sb.AppendLine("\t#define Bluedot_Button_Type_Left " + BluedotButtonTypeLeft);
            sb.AppendLine("\t#define Bluedot_Button_Type_Right " + BluedotButtonTypeRight);
            if (NumericKeypadSearch)
                sb.AppendLine("\t#define NumericKeypadSearch");
            sb.AppendLine("\t#define Bluedot_Manual_Language " + BluedotManualLanguage);
            sb.AppendLine("#endif");
            return sb.ToString();
        }

        private static void WriteFirstLine(string filename, string firstLine)
        {
            string tempfile = Path.GetTempFileName();
            using (var writer = new StreamWriter(tempfile))
            using (var reader = new StreamReader(filename))
            {
                writer.WriteLine(firstLine);
                while (!reader.EndOfStream)
                    writer.WriteLine(reader.ReadLine());
            }
            File.Copy(tempfile, filename, true);
        }
    }

    public enum Language
    {
        Bluedot_Manual_Language_English,
        Bluedot_Manual_Language_German
    }
}
