using Identity.Application.DTOs;
using Identity.Domain.Common;
using MediatR;

namespace Identity.Application.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<Result<UserDto>>
    {
        public Guid Id { get; }

        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
