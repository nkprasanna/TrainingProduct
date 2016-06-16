using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PTCData
{
    public class TrainingProducts
    {
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Product Name must be filled in.")]
        [Display(Description = "Product Name")]
        [StringLength(150, MinimumLength = 4, ErrorMessage = "Product name must be greater than {2} characters.")]
        public string ProductName { get; set; }
        [Range(typeof(DateTime), "1/1/2000", "12/31/2020", ErrorMessage = "Introduction date must be between {1} and {2}")]
        [Display(Description = "Introduction Date")]
        public DateTime IntroductionDate { get; set; }
        [Required(ErrorMessage = "Url must be required")]
        [Display(Description = "Url")]
        [StringLength(2000, ErrorMessage = "Enter valid Url")]
        public string Url { get; set; }
        [Range(1, 9999, ErrorMessage = "{0} Must be between {1} and {2}")]
        public decimal Price { get; set; }

    }
}
