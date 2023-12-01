using CQRS_lib.CQRS.Commands;
using MediatR;
using CQRS_lib.Data;
using CQRS_lib.Models;
using CQRS_lib.Data.Models;

namespace CQRS_lib.CQRS.Handlers
{
    public class InsertEmployeeCommandHandler : IRequestHandler<InsertEmployeeCommand, NewEmployeeDTO>
    {
        private readonly APIDbContext _context;
        public InsertEmployeeCommandHandler(APIDbContext context)
        {
            _context = context;
        }
        public async Task<NewEmployeeDTO> Handle(InsertEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee()
            {
                Id = request.EmployeeDto.Id,
                FirstName = request.EmployeeDto.FirstName,
                LastName = request.EmployeeDto.LastName,
                Salary = request.EmployeeDto.Salary,
                DepartmentId = request.EmployeeDto.DepartmentId,
                HireDate = request.EmployeeDto.HireDate,
                PhoneNumber = request.EmployeeDto.PhoneNumber,
                Email= request.EmployeeDto.Email,
            };
            await _context.AddAsync(employee);
            _context.SaveChanges();
            return await Task.FromResult(request.EmployeeDto);
        }
    }
}
