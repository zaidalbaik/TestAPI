using MediatR;
using CQRS_lib.Models;
namespace CQRS_lib.CQRS.Commands
{
    public record InsertEmployeeCommand(NewEmployeeDTO EmployeeDto): IRequest<NewEmployeeDTO>;
}
