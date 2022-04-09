using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Meal : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Ingredients { get; set; }
        public string PossibleAllergens { get; set; }

        public Guid ProviderId { get; set; }
        public Provider Provider { get; set; }

    }
}
