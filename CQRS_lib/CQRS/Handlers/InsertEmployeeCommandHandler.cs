using CQRS_lib.CQRS.Commands;
using MediatR;
using CQRS_lib.Data;
using CQRS_lib.Models;

namespace CQRS_lib.CQRS.Handlers
{
    public class InsertEmployeeCommandHandler : IRequestHandler<InsertEmployeeCommand, Employee>
    {
        private readonly APIDbContext _context;
        public InsertEmployeeCommandHandler(APIDbContext context)
        {
            _context = context;
        }
        public async Task<Employee> Handle(InsertEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _context.AddAsync(request.Employee);
            _context.SaveChanges();
            return await Task.FromResult(request.Employee);
        }
    }
}
