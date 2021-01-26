using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Behavioral.TemplateMethodPattern.Loggers
{
    public class FileLogger : AbstractLogger
    {
        protected override void OpenDataStoreOperation()
        {
            Console.WriteLine("Opening File.");
        }

        protected override void LogMessage(string messageToLog)
        {
            Console.WriteLine("Appending Log message to file : " + messageToLog);
        }

        protected override void CloseDataStoreOpreation()
        {
            Console.WriteLine("Close File.");
        }
    }
}
