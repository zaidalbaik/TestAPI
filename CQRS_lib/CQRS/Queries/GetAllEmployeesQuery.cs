using MediatR;
using CQRS_lib.Models;
namespace CQRS_lib.CQRS.Queries
{
    public record GetAllEmployeesQuery : IRequest<List<EmployeeDTO>>;
}
