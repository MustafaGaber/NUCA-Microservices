using NUCA.Projects.Application.Boqs.Models;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Application.Projects.Queries.Models;
using NUCA.Projects.Data.Projects;
using NUCA.Projects.Domain.Entities.Boqs;
using NUCA.Projects.Domain.Entities.Projects;
using NUCA.Projects.Shared.Constants;
using NUCA.Projects.Shared.Extensions;
using System.Security.Claims;

namespace NUCA.Projects.Application.Boqs.Commands.ApproveBoq
{
    public class ApproveBoqCommand : IApproveBoqCommand
    {
        private IBoqRepository _boqRepository;

        public ApproveBoqCommand(IBoqRepository boqRepository)
        {
            _boqRepository = boqRepository;
        }

        public async Task<BoqModel> Execute(long boqId, ClaimsPrincipal user)
        {
            if (user.Id() == null) throw new UnauthorizedAccessException();
            if (!user.HasPermission(Permissions.Revision)) throw new UnauthorizedAccessException();
            Boq? boq = await _boqRepository.Get(boqId) ?? throw new InvalidOperationException();
            boq.Approve(user.Id()!);
            await _boqRepository.Update(boq);
            return new BoqModel(boq);
        }
    }
}
