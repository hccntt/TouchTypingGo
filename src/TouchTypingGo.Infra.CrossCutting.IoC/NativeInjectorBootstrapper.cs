﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TouchTypingGo.Application.AutoMapper;
using TouchTypingGo.Application.Interfaces;
using TouchTypingGo.Application.Services;
using TouchTypingGo.Application.Services.Helper;
using TouchTypingGo.Domain.Core.Bus;
using TouchTypingGo.Domain.Core.Events;
using TouchTypingGo.Domain.Core.Interfaces;
using TouchTypingGo.Domain.Core.Notifications;
using TouchTypingGo.Domain.Course.Commands.Course;
using TouchTypingGo.Domain.Course.Commands.Keyboard;
using TouchTypingGo.Domain.Course.Commands.LessonPresentation;
using TouchTypingGo.Domain.Course.Commands.LessonResult;
using TouchTypingGo.Domain.Course.Commands.Student;
using TouchTypingGo.Domain.Course.Commands.Teacher;
using TouchTypingGo.Domain.Course.Events.Course;
using TouchTypingGo.Domain.Course.Events.Keyboard;
using TouchTypingGo.Domain.Course.Events.LessonPresentation;
using TouchTypingGo.Domain.Course.Events.LessonResult;
using TouchTypingGo.Domain.Course.Events.Student;
using TouchTypingGo.Domain.Course.Events.Teacher;
using TouchTypingGo.Domain.Course.Repository;
using TouchTypingGo.Domain.Institution.Commands.Address;
using TouchTypingGo.Domain.Institution.Commands.Institution;
using TouchTypingGo.Domain.Institution.Events.Address;
using TouchTypingGo.Domain.Institution.Events.Institution;
using TouchTypingGo.Domain.Institution.Repository;
using TouchTypingGo.Infra.CrossCutting.Bus;
using TouchTypingGo.Infra.CrossCutting.Filters;
using TouchTypingGo.Infra.CrossCutting.Identity.Models;
using TouchTypingGo.Infra.CrossCutting.Identity.Services;
using TouchTypingGo.Infra.Data.Context;
using TouchTypingGo.Infra.Data.Extentions;
using TouchTypingGo.Infra.Data.Repository;
using TouchTypingGo.Infra.Data.UoW;

namespace TouchTypingGo.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {

            AutoMapperConfig.Configure();

            //Application
            //services.AddSingleton(Mapper.Configuration);
            //services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));



            //AppService
            services.AddScoped<ICourseAppService, CourseAppService>();
            services.AddScoped<ITeacherAppService, TeacherAppService>();
            services.AddScoped<ILessonPresentationAppService, LessonPresentationAppService>();
            services.AddScoped<ILessonResultAppService, LessonResultAppService>();
            services.AddScoped<IStudentAppService, StudentAppService>();
            services.AddScoped<IKeyboardAppService, KeyboardAppService>();
            services.AddScoped<ILessonListAppService, LessonListAppService>();
            services.AddScoped<IInstitutionAppService, InstitutionAppService>();
            services.AddScoped<IAddressAppService, AddressAppService>();

            services.AddScoped<IHelperService, HelperService>();

            //Domain - Commands
            //Course
            services.AddScoped<IHandler<CourseAddCommand>, CourseCommandHandler>();
            services.AddScoped<IHandler<CourseUpdateCommand>, CourseCommandHandler>();
            services.AddScoped<IHandler<CourseDeleteCommand>, CourseCommandHandler>();

            //Teacher
            services.AddScoped<IHandler<TeacherAddCommand>, TeacherCommandHandler>();
            services.AddScoped<IHandler<TeacherDeleteCommand>, TeacherCommandHandler>();

            //LessonPresentation
            services.AddScoped<IHandler<LessonPresentationAddCommand>, LessonPresentationCommandHandler>();
            services.AddScoped<IHandler<LessonPresentationDeleteCommand>, LessonPresentationCommandHandler>();

            //LessonResult
            services.AddScoped<IHandler<AddLessonResultCommand>, LessonResultCommandHandler>();
            services.AddScoped<IHandler<DeleteLessonResultCommand>, LessonResultCommandHandler>();

            //Student
            services.AddScoped<IHandler<AddStudentCommand>, StudentCommandHandler>();
            services.AddScoped<IHandler<DeleteStudentCommand>, StudentCommandHandler>();

            //Keyboard
            services.AddScoped<IHandler<AddKeyboardCommand>, KeyboardCommandHandler>();
            services.AddScoped<IHandler<DeleteKeyboardCommand>, KeyboardCommandHandler>();

            //Institution
            services.AddScoped<IHandler<AddInstitutionCommand>, InstitutionCommandHandler>();

            //Address
            services.AddScoped<IHandler<AddAddressCommand>, AddressCommandHandler>();

            //Domain - Events
            services.AddScoped<IDomainNotificationHandler<DomainDotification>, DomainNotificationHandler>();

            //Events Courses
            services.AddScoped<IHandler<CourseAddEvent>, CourseEventHandler>();
            services.AddScoped<IHandler<CourseUpdateEvent>, CourseEventHandler>();
            services.AddScoped<IHandler<CourseDeleteEvent>, CourseEventHandler>();

            //Events Teacher
            services.AddScoped<IHandler<TeacherAddEvent>, TeacherEventHandler>();
            services.AddScoped<IHandler<TeacherDeleteEvent>, TeacherEventHandler>();

            //lesson Presentation
            services.AddScoped<IHandler<LessonPresentationAddEvent>, LessonPresentationEventHandler>();
            services.AddScoped<IHandler<LessonPresentationDeleteEvent>, LessonPresentationEventHandler>();

            //Lesson Result
            services.AddScoped<IHandler<LessonResultAddEvent>, LessonResultEventHandler>();
            services.AddScoped<IHandler<LessonResultDeleteEvent>, LessonResultEventHandler>();

            //Student
            services.AddScoped<IHandler<AddStudentEvent>, StudentEventHandler>();
            services.AddScoped<IHandler<DeleteStudentEvent>, StudentEventHandler>();

            //Keyboard
            services.AddScoped<IHandler<AddKeyboardEvent>, KeyboardEventHandler>();
            services.AddScoped<IHandler<DeleteKeyboardEvent>, KeyboardEventHandler>();

            //Institution
            services.AddScoped<IHandler<AddInstitutionEvent>, InstitutionEventHandler>();

            //Address
            services.AddScoped<IHandler<AddAddressEvent>, AddressEventHandler>();

            //Infra - Data
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<ILessonPresentationRepository, LessonPresentationRepository>();
            services.AddScoped<ILessonResultRepository, LessonResultRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IKeyboardRepository, KeyboardRepository>();
            services.AddScoped<IInstitutionRepository, InstitutionRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<TouchTypingGoContext>();

            //Infra - Bus
            services.AddScoped<IBus, InMemoryBus>();

            //Identity
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, User>();

            //Infra - Filters
            services.AddScoped<ILogger<GlobalExceptionHandlingFilter>, Logger<GlobalExceptionHandlingFilter>>();
            services.AddScoped<GlobalExceptionHandlingFilter>();

            services.AddScoped<ILogger<GlobalActionLogger>, Logger<GlobalActionLogger>>();
            services.AddScoped<GlobalActionLogger>();

            //Cqrs
            services.AddCqrs();
        }
    }
}
