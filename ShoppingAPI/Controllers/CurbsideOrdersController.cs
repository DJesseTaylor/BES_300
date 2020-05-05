using Microsoft.AspNetCore.Mvc;
using ShoppingAPI.Mappers;
using ShoppingAPI.Models;
using ShoppingAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingAPI.Controllers
{
    public class CurbsideOrdersController: ControllerBase
    {
        private readonly IMapCurbsideOrders CurbsideMapper;
        private readonly CurbsideChannel TheChannel;

        public CurbsideOrdersController(IMapCurbsideOrders curbsideMapper, CurbsideChannel theChannel)
        {
            CurbsideMapper = curbsideMapper;
            TheChannel = theChannel;
        }

        [HttpPost("curbsideorders")]
        public async Task<ActionResult> PlaceOrder([FromBody] CreateCurbsideOrder orderToPlace)
        {
            CurbsideOrder response = await CurbsideMapper.PlaceOrder(orderToPlace);
            await TheChannel.AddCurbsideOrder(new CurbsideChannelRequest { OrderId = response.Id });
            return Ok(response);
        }

        [HttpGet("curbsideorders/{id:int}")]
        public async Task<ActionResult<CurbsideOrder>> GetById(int id)
        {
            CurbsideOrder response = await CurbsideMapper.GetOrderById(id);
            if(response == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }

    }
}
