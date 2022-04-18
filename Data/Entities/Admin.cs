using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Admin : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public Admin(string userName, string password)
        {
            Id = Guid.NewGuid();
            UserName = userName;
            Password = password;
        }
    }

}
