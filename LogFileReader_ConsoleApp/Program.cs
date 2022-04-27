using System.IO;
using LogFileReader_ConsoleApp.Adapters;
using LogFileReader_ConsoleApp.DB_Context;

namespace LogFileReader_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("C:\\Users\\User\\Downloads\\stdout_20220221171119_13772.log");
            var provider = new AppProvider(input, new LogFileReader(), new CF_Writer());

            provider.WriteToDb();
        }
    }
}
