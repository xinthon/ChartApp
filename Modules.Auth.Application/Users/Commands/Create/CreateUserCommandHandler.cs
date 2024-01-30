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

        public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<UserId>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userId = await _userRepository.CreateAsync(
                 User.Create( 
                     Name.Create(request.Username),
                     Email.Create(request.Email),
                     request.Password), cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return userId;
        }
    }
}
