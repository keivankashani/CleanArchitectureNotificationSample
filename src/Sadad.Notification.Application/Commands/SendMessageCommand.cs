using FluentValidation;
using MediatR;
using Sadad.Notification.Domain.Enums;

namespace Sadad.Notification.Application.Commands
{
    public class SendMessageCommand : IRequest<Unit>
    {
        public SendMessageCommand(SmsType smsType, string nationalCode, string messageBody, DateTime? sendDateTime)
        {
            SmsType = smsType;
            NationalCode = nationalCode;
            MessageBody = messageBody;
            SendDateTime = sendDateTime;
        }
        public SmsType SmsType { get; }
        public string NationalCode { get; }
        public string MessageBody { get; }
        public DateTime? SendDateTime { get; }
        public class SendMessageCommandValidator : AbstractValidator<SendMessageCommand>
        {
            public SendMessageCommandValidator()
            {
                RuleFor(v => v.MessageBody).MinimumLength(3).MaximumLength(250).NotEmpty();
                RuleFor(v => v.SmsType).NotEmpty();
                RuleFor(v => v.NationalCode).Length(10).NotEmpty();
            }
        }
    }
}
