
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class OrderDTO : BaseDTO
    {
        [Required]
        [StringLength(70, MinimumLength = 6, ErrorMessage = "{0} length must be between {2} and {1} symbols.")]
        public string Address { get; set; }
        [Required]
        public DateTime DateOfLastModified { get; set; }
        [Required]
        public string OrderStatus { get; set; }

        public virtual ICollection<MealDTO> Meals { get; set; }
    }
}
