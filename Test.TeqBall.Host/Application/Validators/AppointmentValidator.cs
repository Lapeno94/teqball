using FluentValidation;
using System.Linq;
using Test.TeqBall.Interfaces.Api.Requests;

namespace Test.TeqBall.Host.Application.Validators
{
    public class AppointmentValidator : AbstractValidator<CreateAppointmentRequest>
    {
        public AppointmentValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Missing event name.");
            RuleFor(x => x.Owner).NotEmpty().EmailAddress().WithMessage("Missing or invalid e-mail.");
            RuleFor(x => x.StartDateTime).NotNull().WithMessage($"{nameof(CreateAppointmentRequest.StartDateTime)} is missing.");
            RuleFor(x => x.Length).GreaterThan(0).NotEmpty().WithMessage($"{nameof(CreateAppointmentRequest.Length)} is missing or zero.");
            RuleFor(x => x.Invitee).Must(x => x.Count() > 0).WithMessage($"{nameof(CreateAppointmentRequest.Invitee)} is empty.");
        }
    }
}
