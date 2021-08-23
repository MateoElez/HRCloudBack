using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.Models;
using ProjectAPI.Models.ItemFolder;

namespace ProjectAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : APIControllerBase<Item, ItemDto>
    {
        public ItemsController(ProjectDbContext context, IMapper mapper) : base(context, mapper) {
            // nesto
        }


    }
}
