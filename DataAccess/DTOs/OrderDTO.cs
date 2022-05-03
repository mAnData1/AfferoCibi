using Data.Entities.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class OrderDTO : BaseModel
    {
        [Required]
        [StringLength(70, MinimumLength = 6, ErrorMessage = "{0} length must be between {2} and {1} symbols.")]
        public string Address { get; set; }
        [Required]
        public DateTime DateOfLastModified { get; set; }
        [Required]
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Processing;

        public virtual List<MealDTO> Meals { get; set; }
    }
}
