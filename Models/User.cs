using Microsoft.AspNetCore.Identity;
using ProjectAPI.Models.UserFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Models
{
    public class User : TEntity
    {
        public User() { }

        public User(UserDto userDto)
        {
            Id = userDto.Id;
        }
        [ForeignKey("UserName")]
        [Required]
        [Column(TypeName= "nvarchar(150)")]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
    }
}
