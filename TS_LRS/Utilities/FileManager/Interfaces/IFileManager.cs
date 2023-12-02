namespace TS_LRS.Utilities.FileManager.Interfaces
{
    public interface IFileManager
    {
        public Task<bool> UploadFile(IFormFile file, string filename, string filePath);
    }
}
