using AutoMapper;
using Ishopping.Domain.ApplicationClass;
using Ishopping.Domain.Entities;

namespace Ishopping.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {           
            //Componente para BasicComponent
            Mapper.CreateMap<ComponentActivity, BasicActivity>();
            Mapper.CreateMap<ComponentPortofolio, SimplePortfolio>();
            Mapper.CreateMap<ComponentPost, SimplePost>();
        }
    }
}
