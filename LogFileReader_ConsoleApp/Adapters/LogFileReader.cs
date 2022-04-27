using System;
using System.Collections.Generic;
using LogFileReader_ConsoleApp.Models;

namespace LogFileReader_ConsoleApp.Adapters
{
    public interface ILogFileReader
    {
        IEnumerable<Log> ParseLogIntoObject(string[] input);
    }

    public class LogFileReader : ILogFileReader
    {
        public LogFileReader()
        { }

        public IEnumerable<Log> ParseLogIntoObject(string[] input)
        {
            var logList = new List<Log>();

            foreach (var line in input)
            {
                if (line.StartsWith('i'))
                {
                    var log = new Log { LogType = "info" };
                    log.Middleware = line.Substring(6).Trim();
                    var index = Array.IndexOf(input, line);
                    log.Message = input[index + 1].Trim();

                    Console.WriteLine("--- Info entry parsed");
                    logList.Add(log);
                }

                if (line.StartsWith('f'))
                {
                    var log = new Log { LogType = "fail" };
                    log.FailedClass = line.Substring(6).Trim();
                    var index = Array.IndexOf(input, line);
                    log.Message = input[++index].Trim();

                    var stackTraceLine = input[++index].Trim();

                    while (input[++index].StartsWith(" "))
                        stackTraceLine = string.Join(" ", stackTraceLine, input[index].Trim());

                    log.StackTrace = stackTraceLine;

                    Console.WriteLine("--- Fail entry parsed");
                    logList.Add(log);
                }

                if (line.StartsWith('w'))
                {
                    var log = new Log { LogType = "warn" };
                    log.FailedClass = line.Substring(6).Trim();
                    var index = Array.IndexOf(input, line);
                    log.Message = input[index + 1].Trim();

                    Console.WriteLine("--- Warn entry parsed");
                    logList.Add(log);
                }
            }

            return logList;
        }

    }
}
