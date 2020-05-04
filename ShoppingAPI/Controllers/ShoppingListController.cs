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

        public ShoppingListController(ShoppingDataContext dataContext)
        {
            DataContext = dataContext;
        }

        [HttpGet("shoppinglist")]
        public async Task<ActionResult> GetFullShoopingList()
        {
            var response = new GetShoppingListResponse();
            response.Data = await DataContext.ShoppingItems
                .Select(item => new ShoppingListItemResponse
                {
                    Id = item.Id,
                    Description = item.Description,
                    Purchased = item.Purchased,
                    PurchasedFrom = item.PurchasedFrom
                }).ToListAsync();
            return Ok(response);
        }
    }
}
