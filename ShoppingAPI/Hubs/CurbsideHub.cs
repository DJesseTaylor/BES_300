using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using ShoppingAPI.Mappers;
using ShoppingAPI.Models;
using ShoppingAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingAPI.Hubs
{
    public class CurbsideHub: Hub
    {
        private readonly IMapCurbsideOrders CurbsideMapper;
        private readonly ILogger<CurbsideHub> Logger;
        private readonly CurbsideChannel TheChannel;
        private readonly IMapper Mapper;

        public CurbsideHub(IMapCurbsideOrders curbsideMapper, ILogger<CurbsideHub> logger, CurbsideChannel theChannel, IMapper mapper)
        {
            CurbsideMapper = curbsideMapper;
            Logger = logger;
            TheChannel = theChannel;
            Mapper = mapper;
        }

        public async Task PlaceOrder(CreateCurbsideOrder orderToBePlaced)
        {
            var response = await CurbsideMapper.PlaceOrder(orderToBePlaced);
            await TheChannel.AddCurbsideOrder(new CurbsideChannelRequest { OrderId = response.Id, ClientId=Context.ConnectionId });
            await Clients.Caller.SendAsync("OrderPlaced", Mapper.Map<CurbsideOrder>(response));
        }
    }
}
