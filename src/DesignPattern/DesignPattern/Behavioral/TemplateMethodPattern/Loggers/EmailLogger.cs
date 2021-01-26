using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Behavioral.TemplateMethodPattern.Loggers
{
    public class EmailLogger : AbstractLogger
    {
        protected override void OpenDataStoreOperation()
        {
            Console.WriteLine("Connecting to mail server and logging in");
        }

        protected override void LogMessage(string messageToLog)
        {
            Console.WriteLine("Sending Email with Log Message : " + messageToLog);
        }

        protected override void CloseDataStoreOpreation()
        {
            Console.WriteLine("Dispose Connection");
        }
    }
}
