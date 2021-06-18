using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace DOLPHIN.Model
{
    public class ProductOption
    {
        [ForeignKey("ProductId")]
        [JsonIgnore]
        public virtual Products Products { get; set; }

        [Key]
        [Column(Order = 0)]
        public Guid ProductId { get; set; }


        [ForeignKey("OptionId")]
        [JsonIgnore]
        public virtual Options Options { get; set; }

        [Key]
        [Column(Order = 1)]
        public int OptionId { get; set; }
    }
}
