using ProjectAPI.Models.BaseFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Models.ItemFolder
{
    public class ItemDto : BaseDto
    {
        public ItemDto(Item item)
        {
            Id = item.Id;
        }
        public string ItemName { get; set; }
        public int ItemPrice { get; set; }
        public string ItemImageUrl { get; set; }
    }
}
