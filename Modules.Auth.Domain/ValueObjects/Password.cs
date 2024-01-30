namespace Modules.Auth.Domain.ValueObjects;

public class Password
{
    public static Password Empty { get; } = new Password(new byte[32], new byte[32]);

    public byte[] PasswordHash { get; private set; }

    public byte[] PasswordSalt { get; private set; }

    private Password(byte[] passwordHash, byte[] passwordSalt)
    {
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }

    public static Password Create(byte[] passwordHash, byte[] passwordSalt) => new Password(passwordHash, passwordSalt);
}
