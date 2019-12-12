using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Laba_13
{
    public static class PISLog
    {
        static PISLog() { File.AppendAllText("pislogfile.txt", $"\n\nНОВЫЙ ЗАПУСК: {DateTime.Now}\n"); }

        public static void Log(string action, string path = null)
        {
            if (path != null)
                File.AppendAllText("pislogfile.txt", $"{DateTime.Now}: {action} | {path}\n");
            else
                File.AppendAllText("pislogfile.txt", $"{DateTime.Now}: {action}\n");
        }
    }
}
