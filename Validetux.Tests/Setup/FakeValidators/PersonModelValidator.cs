using Validetux.Tests.Setup.FakeModels;

namespace Validetux.Tests.Setup.FakeValidators
{
    public class PersonModelValidator : AbstractValidator<PersonModel>
    {
        public PersonModelValidator()
        {
            RuleFor(p => p.FirstName)
                .IsRequired();
        }
    }
}
