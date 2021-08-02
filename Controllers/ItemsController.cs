using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.Models;

namespace ProjectAPI.Controllers
{
   //[Route("api/[controller]")]
   [ApiController]
    public class ItemsController : APIControllerBase<Item>
    {
        public ItemsController(ProjectDbContext context): base(context) {
            // nesto
        }
    }
}
