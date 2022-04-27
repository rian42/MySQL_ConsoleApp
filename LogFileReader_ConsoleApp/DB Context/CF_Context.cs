using LogFileReader_ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LogFileReader_ConsoleApp
{
    public class CF_Context : DbContext
    {
        public CF_Context()
        { }

        public DbSet<Log> LogFile { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=consoleapp;user=root;password=mypassword");
        }
    }
}