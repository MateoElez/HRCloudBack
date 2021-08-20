using ProjectAPI.Models.BaseFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Models.UserFolder
{
    public class UserDto : BaseDto
    {
        public UserDto() { }

        public UserDto(User user)
        {
            Id = user.Id;
            Password = user.Password;
            FirstName = user.FirstName;
            Username = user.Username;
            LastName = user.LastName;
            //Cart = user.Cart;
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public Item Cart { get; set; }
        //public Item[] Orders { get; set; }
        
    }
}
