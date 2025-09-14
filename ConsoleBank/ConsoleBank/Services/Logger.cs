using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication.Services
{
    public class Logger
    {
        private static readonly string logFilePath = "bank-log.txt";

        public static void Log(string message)
        {
            string logEntry = $"{DateTime.Now}: {message}";
            File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
        }
    }
}
