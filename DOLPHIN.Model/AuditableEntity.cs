using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace DOLPHIN.Model
{
    public class AuditableEntity : BaseEntity
    {
        
        public DateTime? UpdatedDate { get; set; }

        public Guid UpdatedById { get; set; }

        [ForeignKey("UpdatedById")]
        [JsonIgnore]
        public virtual Users UpdatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public Guid CreatedById { get; set; }

        [ForeignKey("CreatedById")]
        [JsonIgnore]
        public virtual Users CreatedBy { get; set; }

    }
}
