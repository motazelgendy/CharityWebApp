using System.ComponentModel.DataAnnotations;

namespace Charity.Models
{
    public class ProgramType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "اسم البرنامج")]
        public string Name { get; set; }

    }
}
