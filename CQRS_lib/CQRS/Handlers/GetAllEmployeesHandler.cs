using CQRS_lib.CQRS.Queries;
using CQRS_lib.Data;
using CQRS_lib.Models;
using MediatR;

namespace CQRS_lib.CQRS.Handlers
{
    public class GetAllEmployeesHandler : IRequestHandler<GetAllEmployeesQuery, List<Employee>>
    {
        private readonly APIDbContext _context;
        public GetAllEmployeesHandler(APIDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_context.Employees.ToList());
        }
    }
}
