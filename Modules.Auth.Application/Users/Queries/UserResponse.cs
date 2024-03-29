﻿using Modules.Auth.Domain.Users;

namespace Modules.Auth.Application.Users.Queries;

public class UserResponse
{
    private IReadOnlyList<string> _roles;
    public UserResponse(Guid userId, string username, string email)
    {
        _roles = new List<string>();

        UserId = userId;
        Username = username;
        Email = email;
    }

    public Guid UserId { get; }
    public string Username { get; }
    public string Email { get; }

    public List<string> Roles => _roles.ToList();


    public static UserResponse FromUser(User user)
    {
        var userResponse = new UserResponse(
            user.Id.Value, 
            user.Username.Value, 
            user.Email.Value);

        var roles = user
            .UserRoles
            .Select(ur => ur.Role!.Name.Value);

        userResponse
            .Roles
            .AddRange(roles);

        return userResponse;
    }
}
