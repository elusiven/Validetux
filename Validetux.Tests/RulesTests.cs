using Validetux.Tests.Setup.FakeModels;
using Validetux.Tests.Setup.FakeValidators;
using Xunit;

namespace Validetux.Tests
{
    public class RulesTests
    {
        [Fact]
        public void Given_Empty_FirstName_Is_Required_Rule_Then_Validation_Fails()
        {
            var person = new PersonModel
            {
                Age = 15,
                FirstName = "",
                LastName = "teset"
            };

            var validator = new PersonModelValidator();

            var result = validator.Validate(person);

            Assert.NotNull(result);
            Assert.True(result.Errors.ContainsKey(nameof(person.FirstName)));
            Assert.NotNull(result.Errors[nameof(person.FirstName)]);
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Given_UnderAge_MinLength_Rule_Then_Validation_Fails()
        {
            var person = new PersonModel
            {
                Age = 15,
                FirstName = "",
                LastName = ""
            };

            var validator = new PersonModelValidator();

            var result = validator.Validate(person);

            Assert.NotNull(result);
            Assert.True(result.Errors.ContainsKey(nameof(person.Age)));
            Assert.NotNull(result.Errors[nameof(person.Age)]);
            Assert.False(result.IsValid);
        }

        [Fact]
        public void Given_AnArray_Length_Rules_Then_Validation_Fails()
        {
            var person = new PersonModel()
            {
                Age = 20,
                FirstName = "S",
                LastName = "VeryLongSurnameOfThisPerson",
                Nicknames = new[] { "", "", "" }
            };

            var personValidator = new PersonModelValidator();

            var result = personValidator.Validate(person);

            Assert.NotNull(result);
            Assert.True(result.Errors.ContainsKey(nameof(person.Nicknames)));
            Assert.NotNull(result.Errors[nameof(person.Nicknames)]);
            Assert.False(result.IsValid);
        }
    }
}