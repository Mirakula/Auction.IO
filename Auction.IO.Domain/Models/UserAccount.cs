using System;
using System.Collections.Generic;

namespace Auction.IO.Domain.Models
{
    public class UserAccount : DomainObject
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime DateJoined { get; set; }
        // EntityFramework Core
        public Role Role { get; set; }
        public int RoleId { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
