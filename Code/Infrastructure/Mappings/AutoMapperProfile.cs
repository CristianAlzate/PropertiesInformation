using AutoMapper;
using Core.DTO.Owner;
using Core.DTO.Property;
using Core.DTO.PropertyImage;
using Core.DTO.PropertyTrace;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Property, PropertyDTO>()
                .ForMember(x => x.Owner , m => m.MapFrom(u => u.IdOwnerNavigation))
                .ReverseMap();
            CreateMap<Owner, OwnerDTO>()
                .ReverseMap();
            CreateMap<Owner, CreateOwnerDTO>()
                .ReverseMap();
            CreateMap<PropertyImage, PropertyImageDTO>()
                .ReverseMap();
            CreateMap<PropertyTrace, PropertyTraceDTO>()
                .ReverseMap();
            CreateMap<PropertyTrace, CreatePropertyTraceDTO>()
                .ReverseMap();
            CreateMap<PropertyImage, CreatePropertyImageDTO>()
                .ReverseMap();
            CreateMap<UpdatePropertyImageDTO, CreatePropertyImageDTO>()
                .ReverseMap();
            CreateMap<UpdatePropertyImageDTO, PropertyImage>()
                .ReverseMap();
            CreateMap<UpdatePropertyDTO, Property>()
                .ReverseMap();
            CreateMap<CreatePropertyDTO,Property>()
                .ForMember(x => x.IdOwner , m => m.MapFrom(U => U.Owner.IdOwner))
                .ForMember(x => x.IdOwnerNavigation, m => m.MapFrom(U => U.Owner))
                .ReverseMap();
        }
    }
}
