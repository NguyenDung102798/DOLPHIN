using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOLPHIN.Model
{
    public class Products : AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets.
        /// </summary>
        [ForeignKey("CategoryId")]
        public virtual Categories Categories { get; set; }
        public Guid CategoryId { get; set; }
        public string ProductName { get; set; }
        public string Price { get; set; }
        public string Images { get; set; }
        public string Desciption { get; set; }
        public int Status { get; set; }

        public virtual ICollection<ProductOption> ProductOptions { get; set; }
    }
}
