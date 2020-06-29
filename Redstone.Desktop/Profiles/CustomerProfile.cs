using AutoMapper;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Redstone.Desktop.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Models.Customer, Domain.Models.Customer>();
            CreateMap<Domain.Models.Customer, Models.Customer>();
        }
    }
}
