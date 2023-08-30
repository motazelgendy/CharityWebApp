using System.ComponentModel.DataAnnotations;

namespace Charity.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "الاسم")]
        public string Name { get; set; }
        [Display(Name = "رقم الاوردر")]
        [Range(1, 100, ErrorMessage = "رقم الاوردر يجيب ان يكون من 1 الى 100")]
        public int DisplayOrder { get; set; }
    }
}
