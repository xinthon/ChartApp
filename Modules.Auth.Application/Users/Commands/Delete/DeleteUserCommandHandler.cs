using ErrorOr;
using MediatR;
using Modules.Auth.Application.Abstractions;
using Modules.Auth.Application.Abstractions.Repositories;
using Modules.Auth.Domain.Users;

namespace Modules.Auth.Application.Users.Commands.Delete
{
    public sealed class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ErrorOr<UserId>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<UserId>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var userId = await _userRepository.DeleteAsync(request.UserId, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return userId;
        }
    }
}
