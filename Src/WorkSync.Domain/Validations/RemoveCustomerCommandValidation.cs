using WorkSync.Domain.Commands;

namespace WorkSync.Domain.Validations;

public class RemoveCustomerCommandValidation : CustomerValidation<RemoveCustomerCommand>
{
    public RemoveCustomerCommandValidation()
    {
        ValidateId();
    }
}
