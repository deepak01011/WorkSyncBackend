using System;

using WorkSync.Domain.Validations;

namespace WorkSync.Domain.Commands;

public class RemoveCustomerCommand : CustomerCommand
{
    public RemoveCustomerCommand(Guid id)
    {
        Id = id;
        AggregateId = id;
    }

    public override bool IsValid()
    {
        ValidationResult = new RemoveCustomerCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}
