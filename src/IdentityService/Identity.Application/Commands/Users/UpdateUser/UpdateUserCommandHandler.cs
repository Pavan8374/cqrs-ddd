using Identity.Domain.Common;
using Identity.Domain.Entities;
using Identity.Domain.Interfaces;
using Identity.Domain.Interfaces.Common;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Application.Commands.Users.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result<Guid>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingUser = await _userRepository.GetByIdAsync(request.Id);
                if (existingUser == null)
                    return Result.Failure<Guid>("User does not exist");

                // Check if the email is already taken by another user
                var existingUserWithEmail = await _userRepository.GetByEmailAsync(request.Email);
                if (existingUserWithEmail != null && existingUserWithEmail.Id != request.Id)
                    return Result.Failure<Guid>("A user with this email already exists");

                // Update user details
                existingUser.UpdateDetails(request.FirstName, request.LastName, request.Email);

                // Save changes
                _userRepository.Update(existingUser);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Result.Success(existingUser.Id);
            }
            catch (DomainException ex)
            {
                return Result.Failure<Guid>(ex.Message);
            }
            catch (Exception ex)
            {
                return Result.Failure<Guid>("An unexpected error occurred: " + ex.Message);
            }
        }
    }
}
