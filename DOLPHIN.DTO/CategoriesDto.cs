using System;
using System.ComponentModel.DataAnnotations;

namespace DOLPHIN.DTO
{
    public class CategoriesDto
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
