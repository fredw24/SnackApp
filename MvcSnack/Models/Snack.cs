using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcSnack.Models
{
    public class Snack
    {
        public int Id { get; set; }
        
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Debut")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
       
        [Required]
        [StringLength(30)]
        public string Types { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        
        [StringLength(30)]
        [Required]
        public string Company { get; set; }
    }
}
