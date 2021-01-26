using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Behavioral.TemplateMethodPattern
{
    public abstract class AbstractLogger
    {
        public void Log(object message)
        {
            string messageToLog = SerializeMessage(message);
            OpenDataStoreOperation();
            LogMessage(messageToLog);
            CloseDataStoreOpreation();
        }

        protected string SerializeMessage(object message)
        {
            Console.WriteLine("Serializing message");
            return message.ToString();
        }

        protected abstract void OpenDataStoreOperation();

        protected abstract void LogMessage(string messageToLog);

        protected abstract void CloseDataStoreOpreation();
    }
}
