using Domain.Enums;

namespace Domain.Dtos
{
    public class MessageDto
    {
        public SmsType SmsType { get; private set; }
        public string NationalCode { get; private set; }
        public string MessageBody { get; private set; }
        public DateTime? SendDateTime { get; private set; }
    }
}
