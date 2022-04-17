using System;
using System.Collections.Generic;

namespace Edura.WebUI.Entity
{
    public class Order
    {
        public Order()
        {
            OrderLines = new List<OrderLine>();
        }

        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public UnumOrderState OrderState { get; set; }

        public string UserName { get; set; }
        public string AdresTanimi { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public string Semt { get; set; }
        public string Telefon { get; set; }

        public virtual List<OrderLine> OrderLines { get; set; }
    }
}