using AutoMapper;
using Robotics.Core.DTOs;
using Robotics.Core.Entities;

namespace Robotics.WebAPI.AutoMapper
{
    public class MapperConfigurator
    {
        /// <summary>
        /// Configures the mapper.
        /// </summary>
        /// <returns>The mapper configuration Object</returns>
        public static IMapper configureAutomapper()
        {
            var configuration = new MapperConfiguration(x =>
            {
                x.CreateMap<Books, BookDTO>()
                    .ForMember(dto => dto.AuthorName, opt => opt.MapFrom(entity => entity.Authors.Name))
                    .ForMember(dto => dto.Author, opt => opt.Ignore())
                    .ForMember(dto => dto.PublisherName, opt => opt.MapFrom(entity => entity.Publisher.Name))
                    .ForMember(dto => dto.Publisher, opt => opt.Ignore())
                    .ForMember(dto => dto.Quantity, opt => opt.MapFrom(entity => entity.Stock.Quantity))
                    .ReverseMap();
                x.CreateMap<Authors, AuthorDTO>().ReverseMap();
                x.CreateMap<Publisher, PublisherDTO>().ReverseMap();
                x.CreateMap<Stock, StockDTO>().ReverseMap();
            });

            return configuration.CreateMapper();
        }
    }
}