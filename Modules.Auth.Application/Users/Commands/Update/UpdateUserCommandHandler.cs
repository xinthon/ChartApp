using ErrorOr;
using MediatR;
using Modules.Auth.Application.Abstractions;
using Modules.Auth.Application.Abstractions.Repositories;
using Modules.Auth.Domain.Users;
using Modules.Auth.Domain.ValueObjects;

namespace Modules.Auth.Application.Users.Commands.Update
{
    public sealed class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ErrorOr<UserId>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<UserId>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {

            var userId = await _userRepository.UpdateAsync(
                User.Update(
                    new UserId(request.UserId), 
                    Name.Create(request.Username), 
                    Email.Create(request.Email)),

                cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return userId;
        }
    }
}
