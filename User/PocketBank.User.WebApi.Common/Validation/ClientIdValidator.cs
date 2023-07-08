using FluentValidation;
using PocketBank.User.WebApi.Common.Models.Request;

namespace PocketBank.User.WebApi.Common.Validation
{
    public class ClientIdValidator : AbstractValidator<ClientIdRequest>
    {
        public ClientIdValidator() 
        {
            RuleFor(c => c.Id).NotNull();
        }
    }
}
