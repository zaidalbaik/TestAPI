using CQRS_lib.CQRS.Queries;
using CQRS_lib.Data;
using CQRS_lib.Models;
using MediatR;

namespace CQRS_lib.CQRS.Handlers
{
    public class GetAllEmployeesHandler : IRequestHandler<GetAllEmployeesQuery, List<EmployeeDTO>>
    {
        private readonly APIDbContext _context;
        public GetAllEmployeesHandler(APIDbContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeDTO>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var emps = from employee in _context.Employees
                       join department in _context.Departments
                       on employee.DepartmentId equals department.DepartmentId
                       select new EmployeeDTO
                       {
                           Id = employee.Id,
                           FirstName = employee.FirstName,
                           LastName = employee.LastName,
                           Salary = employee.Salary, 
                           Email = employee.Email,
                           HireDate = employee.HireDate,
                           PhoneNumber = employee.PhoneNumber, 
                           Department = new DepartmentDTO()
                           {
                               Id = department.DepartmentId,
                               Name = department.DepartmentName
                           }
                       };

            return await Task.FromResult(emps.ToList());
        }
    }
}
