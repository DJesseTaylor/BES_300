using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoppingAPI.Data;
using ShoppingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingAPI.Mappers
{
    public class EFCurbsideMapper : IMapCurbsideOrders
    {
        private readonly ShoppingDataContext DataContext;
        private readonly IMapper Mapper;
        private readonly MapperConfiguration MapperConfig;

        public EFCurbsideMapper(ShoppingDataContext dataContext, IMapper mapper, MapperConfiguration mapperConfig)
        {
            DataContext = dataContext;
            Mapper = mapper;
            MapperConfig = mapperConfig;
        }

        async Task<CurbsideOrder> IMapCurbsideOrders.GetOrderById(int id)
        {
            var order = await DataContext.CurbsideOrders.SingleOrDefaultAsync(order => order.Id == id);
            if(order == null)
            {
                return null;
            }
            else
            {
                return Mapper.Map<CurbsideOrder>(order);
            }
        }

        async Task<CurbsideOrder> IMapCurbsideOrders.PlaceOrder(CreateCurbsideOrder orderToPlace)
        {
            var order = Mapper.Map<OrderForCurbside>(orderToPlace);
            DataContext.CurbsideOrders.Add(order);
            await DataContext.SaveChangesAsync();
            var response = Mapper.Map<CurbsideOrder>(order);
            return response;
        }
    }
}
