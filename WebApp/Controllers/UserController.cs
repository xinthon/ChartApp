using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modules.Auth.Application.Users.Queries;
using Modules.Auth.Application.Users.Queries.GetUsers;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet(Name = "GetUsers")]
        public async Task<IEnumerable<UserResponse>> Get(ISender sender)
        {
            try
            {
                var errorOr = await sender.Send(new GetUsersQuery());
                return errorOr.Value;
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<UserResponse>();
            }
        }
    }
}
