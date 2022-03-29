using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ironcapital.Models
{
    public class BuyNowClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Order Id")]
        public int OrderId { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Contact Number")]
        [StringLength(10)]
        public string Phone { get; set; }

        //FK
        [Display(Name = "Token Id")]
        [ForeignKey("TokenClass")]
        public int TokenId { get; set; }
        public TokenClass TokenClass { get; set; }


        [Required]
        [Display(Name = "Wallet Addreas")]
        public string WalletAddress { get; set; }

        [Required]
        [Display(Name = "Twitter ID")]
        public string TwitterID { get; set; }

        //[Required]
        [Display(Name = "Message")]
        public string Message { get; set; }

        //[Required]
        [Display(Name = "Recommended By")]
        public string RecBy { get; set; }
    }
}
