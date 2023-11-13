using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Projects.Domain.Common;
using NUCA.Projects.Domain.Entities.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUCA.Projects.Application.Departments.Queries.GetDepartments
{
    public class GetDepartmentsQuery : IGetDepartmentsQuery
    {

        private readonly IDepartmentRepository _repository;

        public GetDepartmentsQuery(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public Task<List<GetDepartmentModel>> Execute()
        {
            return _repository.Select(department => new GetDepartmentModel
            {
                   Id = department.Id,
                   Name = department.Name,
               });
        }
    }
}
