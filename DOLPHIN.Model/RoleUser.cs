using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace DOLPHIN.Model
{
    public class RoleUser
    {
        [ForeignKey("UserId")]
        [JsonIgnore]
        public virtual Users Users { get; set; }

        [Key]
        [Column(Order = 0)]
        public Guid UserId { get; set; }

        [ForeignKey("RoleId")]
        [JsonIgnore]
        public virtual Roles Roles { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid RoleId { get; set; }
    }
}
