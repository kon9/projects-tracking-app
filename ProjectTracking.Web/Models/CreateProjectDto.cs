﻿using AutoMapper;
using ProjectTracking.Core.Common.Mappings;
using ProjectTracking.Core.Projects.Commands.CreateProject;
using System;

namespace ProjectTracking.Web.Models
{
    public class CreateProjectDto : IMapWith<CreateProjectDto>
    {
        public string ProjectName { get; set; }
        public string CustomerCompanyName { get; set; }
        public string PerformerCompanyName { get; set; }
        public int ProjectPriority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } = null;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProjectDto, CreateProjectCommand>()
                .ForMember(projectCommand => projectCommand.ProjectName,
                    opt =>
                        opt.MapFrom(projectDto => projectDto.ProjectName))
                .ForMember(projectCommand => projectCommand.CustomerCompanyName,
                    opt =>
                        opt.MapFrom(projectDto => projectDto.CustomerCompanyName))
                .ForMember(projectCommand => projectCommand.PerformerCompanyName,
                    opt =>
                        opt.MapFrom(projectDto => projectDto.PerformerCompanyName))
                .ForMember(projectCommand => projectCommand.ProjectPriority,
                    opt =>
                        opt.MapFrom(projectDto => projectDto.ProjectPriority))
                .ForMember(projectCommand => projectCommand.StartDate,
                    opt =>
                        opt.MapFrom(projectDto => projectDto.StartDate))
                .ForMember(projectCommand => projectCommand.EndDate,
                    opt =>
                        opt.MapFrom(projectDto => projectDto.EndDate));
        }
    }
}
