using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogFileReader_ConsoleApp.Models
{
    public class Log
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string LogType { get; set; }
        public string Middleware { get; set; }
        public string Message { get; set; }
        public string FailedClass { get; set; }
        public string StackTrace { get; set; }
    }
}
