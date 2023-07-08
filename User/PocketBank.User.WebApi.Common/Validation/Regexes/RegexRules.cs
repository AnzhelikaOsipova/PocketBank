using FluentValidation.Validators;
using FluentValidation;

namespace PocketBank.User.WebApi.Common.Validation.Regexes
{
    public static class RegexRules
    {
        public static IRuleBuilderOptions<T, string> Passport<T>(this IRuleBuilder<T, string> ruleBuilder) =>
            ruleBuilder
                .SetValidator(new RegularExpressionValidator<T>(RegexConstants.ClientRegexes.Passport))
                .WithMessage(@"Passport number must not contain any special characters.")
                .MinimumLength(3)
                .WithMessage(@"Passport number must have at least 3 characters")
                .MaximumLength(20)
                .WithMessage(@"Passport number must be less then 20 characters");

        public static IRuleBuilderOptions<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder) =>
            ruleBuilder
                .SetValidator(new RegularExpressionValidator<T>(RegexConstants.ClientRegexes.Password))
                .WithMessage("Password must contain symbols from at least three of following the groups:" +
                "special characters (!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~)," +
                "capital letters, small letters, digits")
                .MinimumLength(3)
                .WithMessage(@"Password must have at least 3 characters")
                .MaximumLength(50)
                .WithMessage(@"Password must be less then 50 characters");

        public static IRuleBuilderOptions<T, string> Name<T>(this IRuleBuilder<T, string> ruleBuilder) =>
            ruleBuilder
                .SetValidator(new RegularExpressionValidator<T>(RegexConstants.ClientRegexes.Name))
                .WithMessage("Name must have only rus, eng alphabet, ' and - characters or whitespaces, " +
                "start with a capital letter and end with a letter")
                .MinimumLength(1)
                .WithMessage(@"Name must have at least 1 character")
                .MaximumLength(50)
                .WithMessage(@"Name must be less then 50 characters");

        public static IRuleBuilderOptions<T, string> Middlename<T>(this IRuleBuilder<T, string> ruleBuilder) =>
            ruleBuilder
                .SetValidator(new RegularExpressionValidator<T>(RegexConstants.ClientRegexes.Middlename))
                .WithMessage("Middlename must have only rus, eng alphabet, ' and - characters or whitespaces, " +
                "start with a capital letter and end with a letter")
                .MaximumLength(50)
                .WithMessage(@"Middlename must be less then 50 characters");
    }
}
