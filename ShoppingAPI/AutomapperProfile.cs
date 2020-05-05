using AutoMapper;
using ShoppingAPI.Data;
using ShoppingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingAPI
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile()
        {
            CreateMap<ShoppingItem, ShoppingListItemResponse>();
            CreateMap<CreateCurbsideOrder, OrderForCurbside>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => String.Join(',',src.Items)));
            //CreateMap<OrderForCurbside, CurbsideOrder>()
            //    .ForMember(dest => dest.Item, opt => opt.Ignore());
            CreateMap<OrderForCurbside, CurbsideOrder>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items.Split(',', StringSplitOptions.None).ToList()));
        }
    }
}
