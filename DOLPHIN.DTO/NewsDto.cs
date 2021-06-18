using DOLPHIN.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DOLPHIN.DTO
{
    public class NewsDto : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        public string Titile { get; set; }

        public IFormFile Images { get; set; }

        public string Description { get; set; }

        public string Refer { get; set; }
    }
}
