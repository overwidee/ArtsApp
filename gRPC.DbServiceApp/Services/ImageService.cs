using Grpc.Core;

namespace gRPC.DbServiceApp.Services;

public class ImageService(ILogger<ImageService> logger) : Image.ImageBase
{
    private readonly ILogger<ImageService> _logger = logger;

    public override Task<ResponseResult> SaveImage(SaveImageRequest request, ServerCallContext context)
    {
        return Task.FromResult(new ResponseResult { Message = $"Сохранено - {request.Name}" });
    }
}