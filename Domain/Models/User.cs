using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Salt { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Order> OrderHistory { get; set; }
        public User() { }
        public User(Guid id,string email, string salt, string passwordHash, string fullName, string address)
        {
            SetId(id);
            Email = email;
            Salt = salt;
            PasswordHash = passwordHash;
            FullName = fullName;
            Address = address;
        }
    }
}
