﻿using Identity.Application.Common;
using Identity.Application.DTOs;
using Identity.Domain.Common;
using Identity.Domain.Entities;
using Identity.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<AuthResponseDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<Result<AuthResponseDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Check if user already exists
                var existingUser = await _userRepository.GetByEmailAsync(request.Email);
                if (existingUser != null)
                    return Result.Failure<AuthResponseDto>("User with this email already exists");

                // Create new user
                var user = User.Create(
                    request.FirstName,
                    request.LastName,
                    request.Email,
                    request.Password
                );

                // Save to repository
                await _userRepository.AddAsync(user);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                var authClaims = JWTService.GetTokenClaims(user.Email.Value, user.Id.ToString(), $"{user.FirstName} {user.LastName}");

                var token = JWTService.GetJWTToken(
                    authClaims,
                    _configuration["JWT:Secret"],
                    _configuration["JWT:ValidIssuer"],
                    _configuration["JWT:ValidAudience"],
                    _configuration["JWT:JWTExpiryDays"]
                );

                var response = new AuthResponseDto()
                {
                    Id = user.Id,
                    Email = user.Email.Value,
                    FullName = $"{user.FirstName} {user.LastName}",
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiry = token.ValidTo
                };
                return Result.Success(response);
            }
            catch (DomainException ex)
            {
                return Result.Failure<AuthResponseDto>(ex.Message);
            }
        }

        
    }
}
