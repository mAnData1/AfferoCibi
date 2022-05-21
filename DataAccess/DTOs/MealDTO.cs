using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class MealDTO : BaseDTO
    {

        public byte[]? MealImage { get; set; }

        [Required]
        [StringLength(15,MinimumLength = 2,ErrorMessage = "{0} length must be between {2} and {1} symbols.")]
        public string Name { get; set; }

        [Required]
        [Range(0.0, 25000,  ErrorMessage = "{0} must be between {2} and {1} bng.")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 20, ErrorMessage = "{0} length must be between {2} and {1} symbols.")]
        public string Ingredients { get; set; }


        public virtual ICollection<OrderDTO>? Orders { get; set; }
    }
}
