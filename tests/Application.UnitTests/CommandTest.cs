using MediatR;
using Moq;
using Sadad.Notification.Application.Commands;
using Sadad.Notification.Domain.Enums;

namespace Application.UnitTests
{
    public class CommandTest
    {
        SmsType smsType = SmsType.Normal;
        string nationalCode = "0076188760";
        string messageBody = "This is a test message.";
        DateTime sendDateTime = DateTime.Now;

        [Fact]
        public void SendMessageCommand_return_NotNull()
        {
            var sendMessageCommand = new SendMessageCommand(smsType, nationalCode, messageBody, sendDateTime);
            var mockMediatr = new Mock<IMediator>();
            var mediatorObj = mockMediatr.Object;
            var messageDTO = mediatorObj.Send(sendMessageCommand);
            Assert.NotNull(messageDTO);
        }
    }
}