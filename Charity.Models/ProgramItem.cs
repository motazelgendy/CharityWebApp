using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Charity.Models
{
    public class ProgramItem
    {
        [Key]
        public int Id { get; set; }
        [Required,Display(Name="الاسم")]

        public string Name { get; set; }
        [Display(Name="الوصف")]
        public string Description { get; set; }
        [Display(Name = "الصورة")]
        public string Image { get; set; }
        [Range(1, 50000, ErrorMessage = "السعر يجيب ان يتراوح من 1 الى 50000 جنيها مصريا")]
        [Display(Name = "قيمة التبرع")]
        public double Price { get; set; }
        [Display(Name = "نوع البرنامج")]
        public int ProgramTypeId { get; set; }
        [ForeignKey("ProgramTypeId")]
        public ProgramType ProgramType { get; set; }
        [Display(Name = "الفئة")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
