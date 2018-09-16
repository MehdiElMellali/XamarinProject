using System;
using System.Collections.Generic;
using System.Text;

namespace StreamVideo.Models
{
    public class Order
    {

        public int OrderId { get; set; }
        public string MovieName { get; set; }
        public string CustomerName { get; set; }
        public string BookingDate { get; set; }
        public string Qty { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string TotalPayment { get; set; }


    }
}
