using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ironcapital.Models
{
    public class TokenClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Token Id")]
        public int TokenId { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Price")]
        public float Price { get; set; }

        [Required]
        [Display(Name = "Owner")]
        [StringLength(50)]
        public string Owner { get; set; }

        [Display(Name = "Year Created")]
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        //REF
        public ICollection<BuyNowClass> BuyNowClasses { get; set; }
    }
}
