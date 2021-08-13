using AutoMapper;
using ProjectAPI.Models;
using ProjectAPI.Models.BaseFolder;
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
            CreateMap<TEntity, BaseDto>();
            CreateMap<BaseDto, TEntity>();
        }

    }
}
