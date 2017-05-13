using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ProjectWork.Web.Models;
using ProjectWork.Entities;

namespace ProjectWork.Web.Mapping
{
    public class AutoMapperConfiguration
    {
        public static void configure()
        {
            //Mapper.Initialize(x => x.AddProfile<ViewModelToEntitiesMappingProfile>());
            Mapper.Initialize(x=> { x.CreateMap<ContactInfoModel, ContactInfo>(); });
            Mapper.Initialize(x => { x.CreateMap<StateViewModel, State>(); });
        }

    }
}