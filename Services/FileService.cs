
namespace CUTDataScienceClub.Services
{
    public class FileService : IFileService
    {
        IWebHostEnvironment environment;

        public FileService(IWebHostEnvironment env)
        {
            environment = env;
        }

        public bool DeleteImage(string ImageFileName)
        {
            try
            {
                var wwwPath = environment.WebRootPath;
                var path = Path.Combine(wwwPath, "ProfilePictureUploads\\", ImageFileName);
                if (File.Exists(path))
                {
                    File.Delete(path);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Tuple<int, string> SaveImage(IFormFile imageFile)
        {
            try
            {
                var wwwPath = environment.WebRootPath;
                var path = Path.Combine(wwwPath, "ProfilePictureUploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);

                }

                var ext = Path.GetExtension(imageFile.FileName);
                var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };

                if (!allowedExtensions.Contains(ext))
                {
                    string msg = string.Format("only {0} extensions are allowed", string.Join(',', allowedExtensions));
                    return new Tuple<int, string>(0, msg);
                }

                string uniqueString = Guid.NewGuid().ToString();
                var newFileName = uniqueString + ext;
                var fileWithPath = Path.Combine(path, newFileName);
                var stream = new FileStream(fileWithPath, FileMode.Create);
                imageFile.CopyTo(stream);
                stream.Close();
                return new Tuple<int, string>(1, newFileName);
            }
            catch (Exception)
            {
                return new Tuple<int, string>(0, "Error has occured");
            }
        }
    }
}