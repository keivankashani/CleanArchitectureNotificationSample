using Sadad.Notification.Domain.Enums;
using Sadad.Notification.Domain.Model;

namespace Domain.UnitTests
{
    public class MessageTest
    {
        SmsType smsType = SmsType.Normal;
        string nationalCode = "0076188760";
        string messageBody = "This is a test message.";
        DateTime sendDateTime = DateTime.Now;
        public bool IsSent { get; private set; }
        [Fact]
        public void SetAsSent_return_true()
        {
            var message = new Message
            {
                SmsType = smsType,
                NationalCode = nationalCode,
                MessageBody = messageBody,
                SendDateTime = sendDateTime,
            };

            message.SetAsSent();
            Assert.True(message.IsSent);
        }
    }
}