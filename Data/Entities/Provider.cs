using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Provider : BaseEntity
    {
        public string Name { get; set; }
        public List<Meal> Meals { get; set; }

    }
}
