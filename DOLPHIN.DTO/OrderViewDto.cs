using System;
using System.Collections.Generic;
using System.Text;

namespace DOLPHIN.DTO
{
    public class OrderViewDto
    {
        public string OrderCode { get; set; }
        public string ClientOrderCode { get; set; }
        public string SortCode { get; set; }
        public string TotalFee { get; set; }
        public DateTime ExpectedDeliveryTime { get; set; }
    }
}
