using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Behavioral.TemplateMethodPattern.Loggers
{
    public class DatabaseLogger : AbstractLogger
    {
        protected override void OpenDataStoreOperation()
        {
            Console.WriteLine("Connecting to Database.");
        }

        protected override void LogMessage(string messageToLog)
        {
            Console.WriteLine("Inserting Log Message to DB table : " + messageToLog);
        }

        protected override void CloseDataStoreOpreation()
        {
            Console.WriteLine("Closing DB connection.");
        }
    }
}
