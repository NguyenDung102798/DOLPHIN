using System;
using System.Collections.Generic;
using System.Text;

namespace DOLPHIN.DTO
{
    public class OrderInfoDto
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public List<LogsOrderDto> logsOrderDtos { get; set; }

    }
}
