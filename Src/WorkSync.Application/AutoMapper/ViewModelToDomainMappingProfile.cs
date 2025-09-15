using AutoMapper;

using WorkSync.Application.ViewModels;
using WorkSync.Domain.Commands;

namespace WorkSync.Application.AutoMapper;

public class ViewModelToDomainMappingProfile : Profile
{
    public ViewModelToDomainMappingProfile()
    {
        CreateMap<CustomerViewModel, RegisterNewCustomerCommand>()
            .ConstructUsing(c => new RegisterNewCustomerCommand(c.Name, c.Email, c.BirthDate));
        CreateMap<CustomerViewModel, UpdateCustomerCommand>()
            .ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.Name, c.Email, c.BirthDate));
    }
}
