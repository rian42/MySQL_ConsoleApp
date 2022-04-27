using System.Collections.Generic;
using LogFileReader_ConsoleApp.Models;

namespace LogFileReader_ConsoleApp.DB_Context
{
    public interface IWriter
    {
        void WriteLogToDb(IEnumerable<Log> file);
    }

    public class CF_Writer : IWriter
    {
        public CF_Writer()
        { }

        public void WriteLogToDb(IEnumerable<Log> file)
        {
            using (var ctx = new CF_Context())
            {
                ctx.Database.EnsureCreated();

                foreach (var log in file)
                {
                    ctx.LogFile.Add(log);
                }

                ctx.SaveChanges();
            }
        }
    }
}
