using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redstone.Desktop.Profiles
{
    class StageProfile : Profile
    {
        public StageProfile()
        {
            CreateMap<Models.Stage, Domain.Models.Stage>();
            CreateMap<Domain.Models.Stage, Models.Stage>();
        }
    }
}
