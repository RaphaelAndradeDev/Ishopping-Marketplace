using AutoMapper;
using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;

namespace Ishopping.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            //Componente para BasicComponent
            Mapper.CreateMap<BasicActivity, ComponentActivity>();
            Mapper.CreateMap<SimplePortfolio, ComponentPortofolio>();
            Mapper.CreateMap<SimplePost, ComponentPost>();
        }
    }
}
