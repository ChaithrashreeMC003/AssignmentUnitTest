using Application.Dtos.OptionDtos;
using Application.Dtos.OuestionDtos;
using Application.Dtos.ProductsDtos;
using Application.Dtos.SurveyDtos;
using Application.Dtos.UserDtos;
using Application.Dtos.UserSurveyDtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();

            CreateMap<UserCreateDto, User>()
                .ForMember(d => d.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));
            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserResponseDto>()
            .ForMember(d => d.RoleName, opt => opt.MapFrom(s => s.Role != null ? s.Role.Name : string.Empty));

            // nested mapping

            CreateMap<Survey, SurveyDto>();

            // Survey → SurveyDetailDto (GetById)
            CreateMap<Survey, SurveyDetailDto>();

            // Question → Question1Dto
            CreateMap<Question, Question1Dto>().ForMember(dest => dest.QuestionText, opt => opt.MapFrom(src => src.QuestionText)); ;

            // CreateSurveyDto → Survey
            CreateMap<CreateSurveyDto, Survey>()
                .ForMember(dest => dest.SurveyId, opt => opt.Ignore()) // set in service
                .ForMember(dest => dest.UserId, opt => opt.Ignore())   // set from logged-in user
                .ForMember(dest => dest.Questions, opt => opt.Ignore()) // questions not created here
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.Product, opt => opt.Ignore());

            // UpdateSurveyDto → Survey
            CreateMap<UpdateSurveyDto, Survey>()
                .ForMember(dest => dest.SurveyId, opt => opt.Ignore())
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.Questions, opt => opt.Ignore())
                .ForMember(dest => dest.Product, opt => opt.Ignore());

            CreateMap<Question, QuestionDto>().ReverseMap();
            CreateMap<Question, QuestionDetailDto>().ReverseMap();
            CreateMap<Option, Option1Dto>().ReverseMap();
            CreateMap<Question, CreateQuestionDto>().ReverseMap();
            CreateMap<Question, UpdateQuestionDto>().ReverseMap();

            CreateMap<Option, OptionDto>().ReverseMap(); // Option ↔ OptionDto1
            CreateMap<OptionCreateDto, Option>();        // OptionCreateDto → Option
            CreateMap<OptionUpdateDto, Option>();


            CreateMap<UserSurvey, UserSurveyDto>();

            // DTO → Entity (for creation only)
            CreateMap<UserSurveyCreateDto, UserSurvey>()
                .ForMember(dest => dest.UserSurveyId, opt => opt.Ignore()) // we generate new Guid in service
                .ForMember(dest => dest.User, opt => opt.Ignore())          // navigation handled separately
                .ForMember(dest => dest.Survey, opt => opt.Ignore())        // navigation handled separately
                .ForMember(dest => dest.Responses, opt => opt.Ignore());
        }
    }
}
