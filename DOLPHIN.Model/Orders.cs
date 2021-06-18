using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DOLPHIN.Model
{
    public class Orders : AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public int Amount { get; set; }

        public string CustomerName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public int OrderStatusCode { get; set; }

        public string GHNRef { get; set; }

        public string OrderCode { get; set; }
        public DateTime ExpectedDeliveryTime { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
