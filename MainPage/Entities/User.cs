using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPage.Entities
{

    public class User 
    {
        public User(string fullName, string email,  string password, string role)
        {
            FullName = fullName;
            Email = email;
            CreatedAt = DateTime.Now;
            Active = true;
            Password = password;
            Role = role;

        }

        //public Guid Id { get; set; }

         public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
     
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; set; }
        public string Password { get; private set; }
        public string Role { get; private set; }


    }


}