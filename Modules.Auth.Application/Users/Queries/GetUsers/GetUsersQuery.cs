using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Auth.Application.Users.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<ErrorOr<IEnumerable<UserResponse>>>
    {
    }
}
