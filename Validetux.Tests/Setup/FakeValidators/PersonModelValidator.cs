using Validetux.Tests.Setup.FakeModels;

namespace Validetux.Tests.Setup.FakeValidators
{
    internal class PersonModelValidator : AbstractValidator<PersonModel>
    {
        internal PersonModelValidator()
        {
            AddRuleFor(p => p.FirstName)
                .IsRequired();

            AddRuleFor(p => p.Age)
                .HasMinLength(18);

            AddRuleFor(p => p.Nicknames)
                .IsRequired()
                .HasMinLength(4);
        }
    }
}