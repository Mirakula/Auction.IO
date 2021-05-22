using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.IO.Domain.Models
{
    public class Item : DomainObject
    {
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public double Price { get; set; }
        public string LastBidder { get; set; }
        public double LastBidPrice { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsSold { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
