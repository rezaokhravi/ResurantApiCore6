using AutoMapper;
using Core6.Models.Dtos;
using Core6.Models.Entites;
using ResurantApiCore6.Models.Dtos;

namespace ResurantApiCore6.Models.AutoMapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            this.CreateMap<Foods, FoodListDtos>()
             .ForMember(dest => dest.RES_TITLE, opt => opt.MapFrom(src => src.Resturant.TITLE)).ReverseMap();
            this.CreateMap<Resturants, ResturantListDtos>().ReverseMap();
            this.CreateMap<FoodsUpdateModel,Foods >().ReverseMap();
            this.CreateMap<FoodsInsertModel,Foods >().ReverseMap();
        }
    }
}