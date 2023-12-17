﻿using Ardalis.GuardClauses;
using System;

namespace NUCA.Identity.Domain
{
    public class Enrollment
    {
        public string UserId { get; private set; }
        public int DepartmentId { get; private set; }
        public Department Department { get; private set; }
        public EmployeeRole Role { get; private set; }
        protected Enrollment() { }
        public Enrollment(string userId, Department department, EmployeeRole role)
        {
            UserId = Guard.Against.NullOrWhiteSpace(userId);
            Department = Guard.Against.Null(department);
            DepartmentId = Guard.Against.NegativeOrZero(Department.Id);
            Role = role;
        }
    }
}
