using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Models
{
    public class User : INameId
    {
        public int Id { get; set; }

        private string _name;
        public string Username
        {
            get { return _name; }
            set { _name = value; }
        }

        string INameId.Name
        {
            get => Username;
            set => Username = value;
        }

       // [Column(TypeName= "nvarchar(150)")]
        //public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
