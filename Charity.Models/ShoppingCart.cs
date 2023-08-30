using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Charity.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int ProgramItemId { get; set; }
        [ForeignKey("ProgramItemId")]

        [ValidateNever]
        public ProgramItem ProgramItem { get; set; }

        [Range(1, 100, ErrorMessage = "من فضلك اختر عدد من 1 : 100")]
        [Required]
        public int Count { get; set; }
        public string AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        [ValidateNever]
        public AppUser AppUser { get; set; }
    }
}
