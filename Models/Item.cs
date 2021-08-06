using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Models
{
    public class Item : TEntity
    {

        /*[Key]
        public int ItemId { get; set; }*/

        [Column(TypeName = "nvarchar(150)")]
        public string ItemName { get; set; }

        [Column(TypeName = "integer")]
        public int ItemPrice { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string ItemImageUrl { get; set; }
    }
}

