using AutoMapper;

using WorkSync.Application.ViewModels;
using WorkSync.Domain.Models;

namespace WorkSync.Application.AutoMapper;

public class DomainToViewModelMappingProfile : Profile
{
    public DomainToViewModelMappingProfile()
    {
        CreateMap<Customer, CustomerViewModel>();
    }
}
