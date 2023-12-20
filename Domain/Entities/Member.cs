using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Member : Entity<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
