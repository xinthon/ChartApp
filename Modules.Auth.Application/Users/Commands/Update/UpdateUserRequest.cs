using System.Text.Json.Serialization;

namespace Modules.Auth.Application.Users.Commands.Update
{
    public class UpdateUserRequest
    {
        [JsonPropertyName("user_name")]
        public required string Username { get; set; }

        [JsonPropertyName("email")]
        public required string Email { get; set; }
    }
}
