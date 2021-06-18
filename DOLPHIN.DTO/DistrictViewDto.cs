using System;
using System.Collections.Generic;
using System.Text;

namespace DOLPHIN.DTO
{
    public class DistrictViewDto
    {
        public int DistrictID { get; set; }
        public int ProvinceID { get; set; }
        public string DistrictName { get; set; }
        public string Code { get; set; }
        public int Type { get; set; }
        public int SupportType { get; set; }

    }
}
