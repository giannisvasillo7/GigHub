using AutoMapper;
using GigHubBC9.Core.Dtos;
using GigHubBC9.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHubBC9.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<Gig, GigDto>();
            CreateMap<Notification, NotificationDto>();         
        }
    }
}