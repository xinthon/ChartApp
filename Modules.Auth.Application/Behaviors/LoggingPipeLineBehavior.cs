using ErrorOr;
using MediatR;

using Microsoft.Extensions.Logging;

namespace Modules.Auth.Application.Behaviors
{
    public class LoggingPipeLineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingPipeLineBehavior<TRequest, TResponse>> _logger;
        public LoggingPipeLineBehavior(ILogger<LoggingPipeLineBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Starting request {@RequestName}, {@DateTimeUtc}",
                typeof(TRequest).Name, 
                DateTime.UtcNow);

            var result = await next();

            _logger.LogInformation(
                "Completed request {@RequestName}, {@DateTimeUtc}",
                typeof(TRequest).Name,
                DateTime.UtcNow);

            return result;
        }
    }
}
