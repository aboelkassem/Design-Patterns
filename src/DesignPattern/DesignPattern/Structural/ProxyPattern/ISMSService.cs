using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Structural.ProxyPattern
{
    /// <summary>
    /// the Subject interface
    /// you can make it abstract class if there is a configuration 
    /// or additional code implemented
    /// </summary>
    public interface ISMSService
    {
        public string SendSMS(string custId, string mobile, string sms);
    }
}
