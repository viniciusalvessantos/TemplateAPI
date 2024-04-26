﻿using Hosted.Usuarios.Application.Responses.LoginResponses;
using Hosted.Usuarios.Domain.Entities;
using Hosted.Usuarios.Domain.Exceptions;
using Hosted.Usuarios.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Hosted.Usuarios.Application.Queries.Login {
    public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginResponse> {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtService _jwtService;
        public LoginQueryHandler(UserManager<ApplicationUser> userManager, IJwtService jwtService) {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        public async Task<LoginResponse> Handle(LoginQuery request, CancellationToken cancellationToken) {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password)) {
                throw new LoginException();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role,"User"),
                new Claim("UserId",user.Id)
            };

            return new LoginResponse(_jwtService.GenerateJwt(claims));
        }
    }
}
