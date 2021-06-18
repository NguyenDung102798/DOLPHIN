using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace DOLPHIN.Model
{
    public class Comments
    {
        [ForeignKey("UserId")]
        [JsonIgnore]
        public virtual Users Users { get; set; }

        [Key]
        [Column(Order = 0)]
        public Guid UserId { get; set; }

        [ForeignKey("ProductId")]
        [JsonIgnore]
        public virtual Products Products { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid ProductId { get; set; }

        public string Description { get; set; }

        public DateTime? CreatedTime { get; set; }
    }
}
