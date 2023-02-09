﻿using MediatR;
using System;

namespace ProjectTracking.Core.Projects.Commands.DeletProject
{
    public class DeleteProjectCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
