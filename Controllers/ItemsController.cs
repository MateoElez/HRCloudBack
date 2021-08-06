﻿using System;
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
   //[Route("api/[controller]")]
   [ApiController]
    public class ItemsController : APIControllerBase<Item>
    {
        public ItemsController(ProjectDbContext context, IMapper mapper) : base(context, mapper) {
            // nesto
        }
    }
}
