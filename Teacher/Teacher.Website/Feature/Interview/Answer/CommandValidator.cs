using FluentValidation;

namespace Teacher.Website.Feature.Interview.Answer
{
    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.QuestionId).GreaterThan(0);
            RuleFor(x => x.UserId).GreaterThan(0);
        }
    }
}