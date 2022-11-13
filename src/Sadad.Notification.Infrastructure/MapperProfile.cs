using AutoMapper;
using Sadad.Notification.Application.Commands;
using Sadad.Notification.Domain.Model;

namespace Sadad.Notification.Infrastructure
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<SendMessageCommand, Message>().ReverseMap();
        }
    }
}
