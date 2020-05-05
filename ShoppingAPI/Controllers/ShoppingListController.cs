using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingAPI.Data;
using ShoppingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingAPI.Controllers
{
    public class ShoppingListController : ControllerBase
    {
        private readonly ShoppingDataContext DataContext;
        private readonly IMapper Mapper;
        private readonly MapperConfiguration MapperConfig;

        public ShoppingListController(ShoppingDataContext dataContext, IMapper mapper, MapperConfiguration mapperConfig)
        {
            DataContext = dataContext;
            Mapper = mapper;
            MapperConfig = mapperConfig;
        }

        [HttpGet("shoppinglist")]
        public async Task<ActionResult> GetFullShoopingList()
        {
            var response = new GetShoppingListResponse();
            response.Data = await DataContext.ShoppingItems
                .ProjectTo<ShoppingListItemResponse>(MapperConfig).ToListAsync();
            return Ok(response);
        }
    }
}
