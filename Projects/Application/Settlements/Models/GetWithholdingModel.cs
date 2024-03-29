﻿using NUCA.Projects.Domain.Entities.Shared;

namespace NUCA.Projects.Application.Settlements.Models
{
    public class GetWithholdingModel
    {
        public long Id { get; init; }
        public string Name { get; init; }
        public double Value { get; init; }
        public WithholdingType Type { get; init; }
        public bool FromStatement { get; init; }
    }
}
