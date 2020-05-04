using Microsoft.AspNetCore.Mvc;
using ShoppingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingAPI.Controllers
{
    public class ShoppingListController : ControllerBase
    {
        [HttpGet("shoppinglist")]
        public async Task<ActionResult> GetFullShoopingList()
        {
            var response = new GetShoppingListResponse();
            return Ok(response);
        }
    }
}
