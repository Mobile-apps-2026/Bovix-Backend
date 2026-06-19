using CloudinaryDotNet.Actions;
using dotenv.net;
using Bovix_Platform.Shared.Application.OutboundServices;
using CloudinarySdk = CloudinaryDotNet;


namespace Bovix_Platform.Shared.Infrastructure.Media.Cloudinary
{
    public class CloudinaryService : IMediaStorageService
    {
        private CloudinarySdk.Cloudinary? _cloudinary;

        private CloudinarySdk.Cloudinary Cloudinary
        {
            get
            {
                if (_cloudinary != null) return _cloudinary;
                var url = Environment.GetEnvironmentVariable("CLOUDINARY_URL")
                    ?? throw new InvalidOperationException("CLOUDINARY_URL is not configured.");
                _cloudinary = new CloudinarySdk.Cloudinary(url);
                _cloudinary.Api.Secure = true;
                return _cloudinary;
            }
        }

        public CloudinaryService()
        {
            DotEnv.Load(options: new DotEnvOptions(probeForEnv: true));
        }

        public void UpdateFileAsync(string url, Stream fileData)
        {
            var uri = new Uri(url);
            var segments = uri.AbsolutePath.Split('/');
            var fileWithExt = segments.Last();
            var publicId = Path.GetFileNameWithoutExtension(fileWithExt);

            var uploadParams = new ImageUploadParams()
            {
                File = new CloudinarySdk.FileDescription("temp", fileData),
                PublicId = publicId,
                Overwrite = true,
                Format = "webp"
            };
            Cloudinary.Upload(uploadParams);
        }

        public string UploadFileAsync(string fileName, Stream fileData)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new CloudinarySdk.FileDescription(fileName, fileData),
                Format = "webp"
            };
            var uploadResult = Cloudinary.Upload(uploadParams);

            return uploadResult.SecureUrl.ToString();
        }
    }
}