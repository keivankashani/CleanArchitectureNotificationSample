using Sadad.Notification.Domain.Enums;

namespace Sadad.Notification.Domain.Model
{
    public class Message
    {
        public Guid Id { get; set; }
        public SmsType SmsType { get; set; }
        public string NationalCode { get; set; }
        public string MessageBody { get; set; }
        public DateTime? SendDateTime { get; set; }
        public bool IsSent { get; private set; }
        public void SetAsSent()
        {
            IsSent = true;
        }

    }
}
