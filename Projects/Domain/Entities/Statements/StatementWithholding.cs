﻿using Ardalis.GuardClauses;
using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Shared;

namespace NUCA.Projects.Domain.Entities.Statements
{
    public class StatementWithholding : Entity<long>
    {
        public string Name { get; private set; }
        public double Value { get; private set; }
        public WithholdingType Type { get; private set; }

        protected StatementWithholding() { }
        public StatementWithholding(string name, double value, WithholdingType type)
        {
            Name = Guard.Against.NullOrEmpty(name.Trim());
            Value = value;
            Type = type;
        }

        public void Update(string name, double value, WithholdingType type)
        {
            Name = Guard.Against.NullOrEmpty(name.Trim());
            Value = value;
            Type = type;
        }
    }
}
