namespace Modules.Auth.Domain.Users
{
    public class UserId
    {
        public Guid Value { get; }

        public UserId(Guid value)
        {
            Value = value;
        }
    }
}
