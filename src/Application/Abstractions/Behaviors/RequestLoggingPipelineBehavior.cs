using Common;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace Application.Abstractions.Behaviors;

internal sealed class RequestLoggingPipelineBehavior<TRequest, TResponse> 
    : IPipelineBehavior<TRequest, TResponse> 
    where TRequest : class 
    where TResponse : Result
{
    private readonly ILogger<RequestLoggingPipelineBehavior<TRequest, TResponse>> _logger;

    internal RequestLoggingPipelineBehavior(ILogger<RequestLoggingPipelineBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        string requestName = typeof(TRequest).Name;
        _logger.LogInformation($"Handling request {requestName}");
        
        var result = await next(cancellationToken);

        if (result.IsSuccess)
        {
            _logger.LogInformation($"Successfully handled request {requestName}");
        }
        else
        {
            _logger.LogError($"Failed to handle request {requestName}");
        }

        return result;
    }
}
