using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redstone.Desktop.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Models.Address, Domain.Models.Address>();
            CreateMap<Domain.Models.Address, Models.Address>();
        }
    }
}
