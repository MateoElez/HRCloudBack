using ProjectAPI.Models.BaseFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Models.UserFolder
{
    public class UserDto : BaseDto
    {

        public UserDto(User user)
        {
            Id = user.Id;
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Item[] Cart { get; set; }
        //public Item[] Orders { get; set; }
        
    }
}
