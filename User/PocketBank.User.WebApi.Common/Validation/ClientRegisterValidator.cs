using FluentValidation;
using PocketBank.User.WebApi.Common.Models.Request;
using PocketBank.User.WebApi.Common.Validation.Regexes;

namespace PocketBank.User.WebApi.Common.Validation
{
    public class ClientRegisterValidator : AbstractValidator<ClientRegisterRequest>
    {
        public ClientRegisterValidator() 
        {
            RuleFor(c => c.FirstName).Name();
            RuleFor(c => c.LastName).Name();
            RuleFor(c => c.MiddleName).Middlename();
            RuleFor(c => c.PassportNumber).Passport();
            RuleFor(c => c.Email).EmailAddress();
            RuleFor(c => c.Password).Password();
        }
    }
}
