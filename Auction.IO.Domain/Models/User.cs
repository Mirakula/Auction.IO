using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.IO.Domain.Models
{
    public class User : DomainObject
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime DateJoined { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}
