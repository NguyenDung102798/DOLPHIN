using System;
using System.Collections.Generic;
using System.Text;

namespace DOLPHIN.DTO
{
    public class TrackingOrderViewDto
    {
        public string Status { get; set; }
        public string ToName { get; set; }
        public string ToAddress { get; set; }
        public string ToPhone { get; set; }

        //public List<LogsOrderDto> LogsOrderDto { get; set; }
    }
}
