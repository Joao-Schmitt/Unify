using System;
using System.IO;
using System.Text;
using System.Threading;

namespace Unify.CrossCutting.Logging
{
    public class Logger : ILogger
    {
        private readonly SemaphoreSlim _mutex = new SemaphoreSlim(1, 1);
        public void Write(string message, LogLevel level = LogLevel.Info, Exception ex = null)
        {
            try
            {
                var basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");

                _mutex.Wait();

                if (!Directory.Exists(basePath))
                    Directory.CreateDirectory(basePath);

                string fileName = $"log_{DateTime.Now:yyyyMMdd}.txt";
                string fullPath = Path.Combine(basePath, fileName);

                var sb = new StringBuilder();
                sb.Append($"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] ");
                sb.Append($"[{level}] ");
                sb.Append(message);

                if (ex != null)
                    sb.Append(" | ").Append(ex.ToString());

                sb.AppendLine();

                File.AppendAllText(fullPath, sb.ToString(), Encoding.UTF8);
            }
            finally
            {
                _mutex.Release();
            }

        }
    }
}
