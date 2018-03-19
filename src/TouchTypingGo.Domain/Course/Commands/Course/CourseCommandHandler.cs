﻿using System;
using TouchTypingGo.Domain.Core.Bus;
using TouchTypingGo.Domain.Core.Events;
using TouchTypingGo.Domain.Core.Notifications;
using TouchTypingGo.Domain.Course.Commands.CommandHandlers;
using TouchTypingGo.Domain.Course.Events;
using TouchTypingGo.Domain.Course.Repository;

namespace TouchTypingGo.Domain.Course.Commands.Course
{
    public class CourseCommandHandler : CommandHandler,
        IHandler<CourseAddCommand>,
        IHandler<CourseUpdateCommand>,
        IHandler<CourseDeleteCommand>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IBus _bus;
        public CourseCommandHandler(
            ICourseRepository courseRepository,
            ITeacherRepository teacherRepository,
            IUnitOfWork uow,
            IBus bus, IDomainNotificationHandler<DomainDotification> notification) : base(uow, bus, notification)
        {
            _courseRepository = courseRepository;
            _teacherRepository = teacherRepository;
            _bus = bus;
        }
        public void Handle(CourseAddCommand message)
        {
            var course = Domain.Course.Course.CourseFactory.NewCourseFactory(message.Code, message.Name, message.LimitDate, message.TeacherId);
           // if (!CouseValid(course)) return;
            //var teacher = _teacherRepository.GetById(message.TeacherId);
            //// Validações de negócio
            course.SetTeacher(_teacherRepository.GetById(message.TeacherId));
            _courseRepository.Add(course);

            if (!Commit()) return;
            _bus.RaiseEvent(new CourseAddEvent(course.Name, course.LimitDate));
        }

        public void Handle(CourseUpdateCommand message)
        {
            if (ExistingCourse(message.Id, message.MessageType)) return;

            var course = Domain.Course.Course.CourseFactory.NewCourseFactory(message.Code, message.Name, message.LimitDate, message.TeacherId);

            if (!CouseValid(course)) return;

            _courseRepository.Update(course);
            if (Commit())
            {
                _bus.RaiseEvent(new CourseUpdateEvent(course.Code, course.Name, course.LimitDate));
            }
        }

        public void Handle(CourseDeleteCommand message)
        {
            if (ExistingCourse(message.Id, message.MessageType)) return;

            _courseRepository.Delete(message.Id);
            if (!Commit()) return;
            _bus.RaiseEvent(new CourseDeleteEvent(message.Id));
        }

        private bool CouseValid(Domain.Course.Course course)
        {
            if (course.IsValid()) return true;
            ValidationsErrorNotification(course.ValidationResult);
            return false;
        }

        private bool ExistingCourse(Guid id, string messageType)
        {
            var course = _courseRepository.GetById(id);
            if (course != null) return true;
            _bus.RaiseEvent(new DomainDotification(messageType, "Evento não encontrado"));
            return false;
        }
    }
}
