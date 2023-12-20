using Application.Features.Members.Commands.CreateMember;
using Application.Features.Task.Commands.CreateTask;
using Application.Features.Task.Commands.UpdateTask;
using Application.Features.Task.Queries.GetAllTask;
using Application.Features.Task.Queries.GetTaskById;
using Application.Features.TaskCategories.Commands.CreateTaskCategory;
using Application.Features.TaskCategories.Commands.UpdateTaskCategory;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile() {
            CreateMap<WorkTask, GetAllMemberViewModel>().ReverseMap();
            CreateMap<CreateTaskCommand, WorkTask>();
            CreateMap<UpdateTaskCommand, WorkTask>();
            CreateMap<GetAllTaskQuery, GetAllMemberParameter>();
            CreateMap<WorkTask, GetTaskViewModel>().ReverseMap();
            CreateMap<CreateTaskCategoryCommand, TaskCategory>();
            CreateMap<UpdateTaskCategoryCommand, TaskCategory>();
            CreateMap<CreateMemberCommand, Member>();
        }

    }
}
