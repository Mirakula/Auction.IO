using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.IO.Domain.Models
{
    public class Account : DomainObject
    {
        public double Balance { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
