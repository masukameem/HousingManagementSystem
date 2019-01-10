using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HousingManagement.Models
{
    public class Users
    {
        [Key]
        public Int64 Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Boolean Status { get; set; }
    }


    public class UsersList
    {
        public List<Users> UsersAll { get; set; } 
    }
}

