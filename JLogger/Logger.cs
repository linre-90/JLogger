using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLogger
{
    internal abstract class Logger
    {
        protected string Format(LogLevel logLevel, string message, int code = 0)
        {
            return $"{DateTime.UtcNow.ToString("dd/MM/yyyy-HH:mm:ss")}-{logLevel}-{code}-{message}";
        }
    }
}
