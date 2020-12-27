using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validetux.Tests.Setup.FakeModels;
using Validetux.Tests.Setup.FakeValidators;
using Xunit;

namespace Validetux.Tests
{
    public class RulesTests
    {

        [Fact]
        public void Given_Is_Required_Rule_Then_Validation_Fails()
        {
            var person = new PersonModel
            {
                Age = 15,
                FirstName = "",
                LastName = "Kujawski"
            };

            var validator = new PersonModelValidator();

            var result = validator.Validate(person);

            Assert.NotNull(result);
            Assert.Single(result.Errors);
            Assert.False(result.IsValid);
        }
    }
}
