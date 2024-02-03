using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Modules.Auth.Application.Users.Queries;
using Modules.Auth.Application.Users.Queries.GetUsers;
using Modules.Auth.Domain.Users;
using Microsoft.AspNetCore.Builder;
using Modules.Auth.Application.Users.Queries.GetUserById;
using Modules.Auth.Application.Users.Commands.Delete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Modules.Auth.Domain.Users.Exceptions;
using Modules.Auth.Application.Users.Commands.Create;
using Modules.Auth.Application.Users.Commands.Update;
using ErrorOr;

namespace WebApp.Endpoints
{
    public static class UserEndpoints
    {
        public static void MapUserEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/users").WithTags(nameof(User));

            group.MapGet("/", async (ISender sender) =>
            {
                var responses = await sender.Send(new GetUsersQuery());
                return responses.Value;
            }).WithName("GetAllUsers");

            group.MapGet("/{userId}", async Task<Results<Ok<UserResponse>, NotFound>> (Guid userId, ISender sender) =>
            {
                var command = new GetUserByIdQuery(userId);
                try
                {
                    var response = await sender.Send(command);
                    return response.Value is UserResponse model
                        ? TypedResults.Ok(model)
                        : TypedResults.NotFound();
                }
                catch (UserNotFoundException)
                {
                    return TypedResults.NotFound();
                }
            }).WithName("GetUserById");


            group.MapPut("/{id}", async Task<Results<Ok, NotFound, ValidationProblem>> (
                    Guid id,
                    UpdateUserRequest request,
                    ISender sender,
                    [FromServices] IValidator<UpdateUserCommand> validator) =>
            {
                var command = new UpdateUserCommand(id, request.Username, request.Email);
                var result = await validator.ValidateAsync(command);

                if (!result.IsValid)
                {
                    var errors = result.Errors
                        .GroupBy(x => x.PropertyName)
                        .ToDictionary(x => x.Key, x => x.Select(x => x.ErrorMessage).ToArray());

                    return TypedResults.ValidationProblem(errors);
                }

                try
                {
                    var affected = await sender.Send(command);
                    return affected.Value != null ? TypedResults.Ok() : TypedResults.NotFound();
                }
                catch (UserNotFoundException)
                {
                    return TypedResults.NotFound();
                }
            })
            .WithName("UpdateUser");

            group.MapPost("/",
            async Task<Results<Created<Guid>, ValidationProblem>> (
                [FromBody] CreateUserRequest request,
                ISender sender,
                [FromServices] IValidator<CreateUserCommand> validator) =>
            {
                var command = new CreateUserCommand(request.Username, request.Email, request.Password);
                var validationResult = await validator.ValidateAsync(command);

                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors
                        .GroupBy(x => x.PropertyName)
                        .ToDictionary(x => x.Key, x => x.Select(x => x.ErrorMessage).ToArray());

                    return TypedResults.ValidationProblem(errors);
                }
                var member = await sender.Send(command);

                return TypedResults.Created($"/api/users/{member.Value.Value}", member.Value.Value);
            }).WithName("CreateUser");


            group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (Guid id, ISender sender) =>
            {
                try
                {
                    var affected = await sender.Send(new DeleteUserCommand(id));
                    return affected.Value != null ? TypedResults.Ok() : TypedResults.NotFound();
                }
                catch (UserNotFoundException)
                {
                    return TypedResults.NotFound();
                }
            })
            .WithName("DeleteUser");
            
        }
    }
}
