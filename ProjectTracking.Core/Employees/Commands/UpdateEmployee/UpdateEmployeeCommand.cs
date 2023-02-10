﻿using MediatR;
using System;

namespace ProjectTracking.Core.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

    }
}
