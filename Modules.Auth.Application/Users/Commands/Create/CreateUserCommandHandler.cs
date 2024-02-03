using ErrorOr;
using MediatR;
using Modules.Auth.Application.Abstractions;
using Modules.Auth.Application.Abstractions.Repositories;
using Modules.Auth.Domain.Users;
using Modules.Auth.Domain.ValueObjects;

namespace Modules.Auth.Application.Users.Commands.Create
{
    public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ErrorOr<UserId>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordProvider _passwordProvider;

        public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IPasswordProvider passwordProvider)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _passwordProvider = passwordProvider;
        }

        public async Task<ErrorOr<UserId>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            _passwordProvider.GeneratePassword(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = User.Create(
                     Name.Create(request.Username),
                     Email.Create(request.Email),
                     Password.Create(passwordHash, passwordSalt));

            var userId = await _userRepository.CreateAsync(user, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return userId;
        }
    }
}
