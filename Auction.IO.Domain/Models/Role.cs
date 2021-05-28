using System.Collections.Generic;

namespace Auction.IO.Domain.Models
{
    public class Role
    {
        public int UserRole { get; set; }
        public string SystemRole { get; set; }
        public UserAccount UserAccount { get; set; }
    }
}
