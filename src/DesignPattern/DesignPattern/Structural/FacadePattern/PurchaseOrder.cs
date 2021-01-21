using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Structural.FacadePattern
{
    // This is the Facade Class to handle all shopping processes with easy interface
    public class PurchaseOrder
    {
        public bool CreateOrder(ShoppingBasket basket, string custInfo)
        {
            // Check stock
            bool isAvailable = true;
            Inventory inventory = new Inventory();

            foreach (var item in basket.GetItems())
            {
                if (!inventory.CheckItemQuantity(item.ItemId, item.Quantity))
                {
                    isAvailable = false;
                }
            }

            if (isAvailable)
            {
                // Create Inventory Order
                InventoryOrder inventoryOrder = new InventoryOrder();
                inventoryOrder.CreateOrder(basket, "123");

                // Create Invoice
                PurchaseInvoice invoice = new PurchaseInvoice();
                var inv = invoice.CreateInvoice(basket, "address:123,id=6546,email=xyz");

                // Payment
                PaymentProcessor payment = new PaymentProcessor();
                payment.HandlePayment(inv.netTotal, "acc=123456879");

                // Send SMS
                SmsNotofications sms = new SmsNotofications();
                sms.SendSms("132", "Invoice Created");

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
