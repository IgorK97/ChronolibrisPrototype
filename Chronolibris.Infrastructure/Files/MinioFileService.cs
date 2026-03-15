//using Chronolibris.Domain.Interfaces.Services;
//using Chronolibris.Infrastructure.DataAccess.Files;
//using Microsoft.Extensions.Options;
//using Minio;
//using Minio.DataModel.Args;

//public class MinioFileService : IFileService
//{
//    private readonly IMinioClient _minioClient;
//    private readonly MinioOptions _options;

//    public MinioFileService(IMinioClient minioClient, IOptions<MinioOptions> options)
//    {
//        _minioClient = minioClient;
//        _options = options.Value;
//    }

//    public async Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType, CancellationToken token)
//    {
//        var objectName = $"{Guid.NewGuid()}_{fileName}";

//        var putObjectArgs = new PutObjectArgs()
//            .WithBucket(_options.BucketName)
//            .WithObject(objectName)
//            .WithStreamData(fileStream)
//            .WithObjectSize(fileStream.Length)
//            .WithContentType(contentType);

//        await _minioClient.PutObjectAsync(putObjectArgs, token);
//        return objectName;
//    }

//    public async Task DeleteFileAsync(string fileName, CancellationToken token)
//    {
//        var removeObjectArgs = new RemoveObjectArgs()
//            .WithBucket(_options.BucketName)
//            .WithObject(fileName);

//        await _minioClient.RemoveObjectAsync(removeObjectArgs, token);
//    }
//}