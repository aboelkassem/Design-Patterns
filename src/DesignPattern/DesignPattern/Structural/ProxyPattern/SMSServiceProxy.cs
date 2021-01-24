using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Structural.ProxyPattern
{
    /// <summary>
    /// The proxy class to handle checking, counting, addressing and any needed operations
    /// for every customer using SMS service
    /// </summary>
    public class SMSServiceProxy : ISMSService
    {
        // if calls for each customer > 100 don't send request to SMS service class

        private ISMSService _smsService;
        // Database
        private Dictionary<string, int> _smsCount = new Dictionary<string, int>();

        public string SendSMS(string custId, string mobile, string sms)
        {
            if (_smsService == null)
                _smsService = new ConcereteSMSService();
            
            // first call for this customer
            if (!_smsCount.ContainsKey(custId))
            {
                _smsCount.Add(custId, 1);
                return _smsService.SendSMS(custId, mobile, sms);
            }
            else
            {
                var customer = _smsCount.Where(x => x.Key == custId).FirstOrDefault();
                if (customer.Value >= 100)
                {
                    return "You have reached the maximum send messages for this subscription";
                }
                else
                {
                    _smsCount[custId] = customer.Value + 1;
                    return _smsService.SendSMS(custId, mobile, sms);
                }
            }
        }
    }
}
