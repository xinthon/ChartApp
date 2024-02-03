using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Auth.Domain.Users.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(UserId userId) : base($"The member with identity '{userId.Value}' was not found.")
        {

        }

        public UserNotFoundException() : base("The member was not found.")
        {

        }
    }
}
