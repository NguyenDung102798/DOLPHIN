using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace DOLPHIN.Model
{
    public class OrderDetails : BaseEntity
    {
        [ForeignKey("OrderId")]
        [JsonIgnore]
        public Guid OrderId { get; set; }

        [ForeignKey("ProductId")]
        [JsonIgnore]
        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public string UnitPrice { get; set; }
    }
}
