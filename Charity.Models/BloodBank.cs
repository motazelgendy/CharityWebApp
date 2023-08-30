using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity.Models
{
    public class BloodBank
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        [ValidateNever]
        public AppUser AppUser { get; set; }

        [Display(Name = "الاسم")]
        public string Name { get; set; }
        [Display(Name = "العنوان")]
        public string? Address { get; set; }
        public double? Latitude { get; set; }

        public double? Longitude { get; set; }


    }
}
