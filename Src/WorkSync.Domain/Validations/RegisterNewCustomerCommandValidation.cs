using WorkSync.Domain.Commands;

namespace WorkSync.Domain.Validations;

public class RegisterNewCustomerCommandValidation : CustomerValidation<RegisterNewCustomerCommand>
{
    public RegisterNewCustomerCommandValidation()
    {
        ValidateName();
        ValidateBirthDate();
        ValidateEmail();
    }
}
