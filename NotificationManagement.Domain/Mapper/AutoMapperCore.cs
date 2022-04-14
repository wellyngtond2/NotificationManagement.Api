using NotificationManagement.Domain.Application.Requests.Notification;
using NotificationManagement.Domain.Application.Requests.NotificationTemplate;
using NotificationManagement.Domain.Application.Responses.Base;
using NotificationManagement.Domain.Application.Responses.Notification;
using NotificationManagement.Domain.Application.Responses.NotificationTemplate;
using NotificationManagement.Domain.Application.Responses.Person;
using NotificationManagement.Domain.Domain.Models;
using NotificationManagement.Domain.Dtos;
using NotificationManagement.Domain.Shared.Enums;

namespace NotificationManagement.Domain.Mapper
{
    public class AutoMapperCore : AutoMapper.Profile
    {
        public AutoMapperCore()
        {
            NotificationMapper();
            NotificationTemplateMapper();
            PersonMapper();
        }

        private void PersonMapper()
        {
            CreateMap<Person, PersonResponse>();
            CreateMap<Person, IdentityResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(ori => ori.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(ori => ori.Name));

        }

        private void NotificationMapper()
        {
            CreateMap<NotificationRequest, Notification>()
                .ForMember(dest => dest.NotificationTemplateId, opt => opt.MapFrom(ori => ori.TemplateId));


            CreateMap<Notification, NotificationResponse>();

            CreateMap<NotificationTotalsDto, NotificationsTotalsResponse>();

        }
        private void NotificationTemplateMapper()
        {
            CreateMap<NotificationTemplateRequest, NotificationTemplate>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(ori => (int)ori.NotificationTemplateType));

            CreateMap<NotificationTemplate, NotificationTemplateResponse>()
                .ForMember(dest => dest.NotificationTemplateType, opt => opt.MapFrom(ori => (NotificationTemplateTypeEnum)ori.Type));

            CreateMap<NotificationTemplate, IdentityResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(ori => ori.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(ori => ori.Title));

        }
    }
}
