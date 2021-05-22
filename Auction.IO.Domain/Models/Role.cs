using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.IO.Domain.Models
{
    public class Role : DomainObject
    {
        public int UserRole { get; set; }
        public string SystemRole { get; set; }
    }
}
