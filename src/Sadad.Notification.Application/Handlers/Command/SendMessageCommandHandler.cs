using AutoMapper;
using MediatR;
using Sadad.Notification.Application.Commands;
using Sadad.Notification.Domain.Enums;
using Sadad.Notification.Domain.Event;
using Sadad.Notification.Domain.Model;

namespace Sadad.Notification.Application.Handlers.Command
{
    public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand, Unit>
    {
        private readonly IUnitOfWork _uow;
        readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public SendMessageCommandHandler(IUnitOfWork uow, IMapper mapper, IMediator mediator)
        {
            _uow = uow;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(SendMessageCommand command, CancellationToken cancellationToken)
        {
            var message = _mapper.Map<Message>(command);

            _uow.Messages.Add(message);
            _uow.Commit();

            await _mediator.Publish(new MessageCreatedEvent
            {
                SmsType = SmsType.Normal
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
