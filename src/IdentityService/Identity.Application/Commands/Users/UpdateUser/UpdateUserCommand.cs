using Identity.Domain.Common;
using MediatR;

namespace Identity.Application.Commands.Users.UpdateUser
{
    public class UpdateUserCommand : IRequest<Result<Guid>>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
