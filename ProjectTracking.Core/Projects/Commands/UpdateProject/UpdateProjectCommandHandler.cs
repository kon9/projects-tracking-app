﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectTracking.Core.Common.Exeptions;
using ProjectTracking.Core.Interfaces;
using ProjectTracking.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectTracking.Core.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand>
    {
        private readonly IProjectsDbContext _dbContext;
        public UpdateProjectCommandHandler(IProjectsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _dbContext.Projects.FirstOrDefaultAsync(project => project.Id == request.Id);
            if (project == null)
            {
                throw new NotFoundException(nameof(Project), request.Id);
            }

            project.ProjectName = request.ProjectName;
            project.CustomerCompanyName = request.CustomerCompanyName;
            project.PerformerCompanyName = request.PerformerCompanyName;
            project.ProjectPriority = request.ProjectPriority;
            project.ProjectManagerId = request.ProjectManagerId;
            project.StartDate = request.StartDate;
            project.EndDate = request.EndDate;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
