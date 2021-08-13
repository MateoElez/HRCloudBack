using Castle.MicroKernel.SubSystems.Conversion;
using ProjectAPI.Models.BaseFolder;
using ProjectAPI.Models.ItemFolder;
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
        public Item() { }

        public Item(ItemDto itemDto)
        {
            Id = itemDto.Id;
        }
        [ForeignKey("ItemName")]
        [Required]
        [Column(TypeName = "nvarchar(150)")]
        public string ItemName { get; set; }

        [Required]
        [Column(TypeName = "integer")]
        public int ItemPrice { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(150)")]
        public string ItemImageUrl { get; set; }
    }
}

