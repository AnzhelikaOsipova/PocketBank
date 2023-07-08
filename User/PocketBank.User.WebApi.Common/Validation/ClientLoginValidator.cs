using FluentValidation;
using PocketBank.User.WebApi.Common.Models.Request;

namespace PocketBank.User.WebApi.Common.Validation
{
    public class ClientLoginValidator : AbstractValidator<ClientLoginRequest>
    {
        public ClientLoginValidator() 
        {
            RuleFor(c => c.Email).EmailAddress();
            RuleFor(c => c.Password).MaximumLength(50);
        }
    }
}
