using ProjectAPI.Models.BaseFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Models.UserFolder
{
    public class UserDto : BaseDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Orders { get; set; }
        public string Cart { get; set; }
        public string Random { get; set; }
    }
}
