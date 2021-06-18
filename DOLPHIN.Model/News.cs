using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DOLPHIN.Model
{
    public class News : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        public string Titile { get; set; }

        public string Images { get; set; }

        public string Description { get; set; }

        public string Refer { get; set; }
    }
}
