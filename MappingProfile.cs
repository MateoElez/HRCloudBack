using AutoMapper;
using ProjectAPI.Models;
using ProjectAPI.Models.BaseFolder;
using ProjectAPI.Models.CartFolder;
using ProjectAPI.Models.ItemFolder;
using ProjectAPI.Models.UserFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<TEntity, BaseDto>()
                 .Include<Item, ItemDto>()
                .Include<User, UserDto>()
                .Include<Cart, CartDto>(); ;
            CreateMap<BaseDto, TEntity>()
                 .Include<ItemDto, Item>()
                .Include<UserDto, User>()
                .Include<CartDto, Cart>(); ;
        }

    }
}
