using EasyOrder.Business.Models.ValueObjects;
using System;

namespace EasyOrder.Business.Models
{
    public class User : Entity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Email Email { get; set; }
        public bool Active { get; set; }

        //Used by EF
        public User() { }

        public User(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = new Email(email);
            Active = true;
        }

        public void ChangeEmail(string email)
        {
            Email = new Email(email);
        }
    }
}
