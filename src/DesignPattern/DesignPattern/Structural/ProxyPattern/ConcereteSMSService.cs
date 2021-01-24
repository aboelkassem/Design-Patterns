using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Structural.ProxyPattern
{
    /// <summary>
    /// Real Subject class
    /// </summary>
    public class ConcereteSMSService : ISMSService
    {
        public string SendSMS(string custId, string mobile, string sms)
        {
            return $"CustomerId {custId},the message {sms}, had sent to {mobile} successfully";
        }
    }
}
