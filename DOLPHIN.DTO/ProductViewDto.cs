using DOLPHIN.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DOLPHIN.DTO
{
    public class ProductViewDto : AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
        public string ProductName { get; set; }
        public string Price { get; set; }
        public IFormFile Images { get; set; }
        public string Desciption { get; set; }
        public int Status { get; set; }
    }
}
