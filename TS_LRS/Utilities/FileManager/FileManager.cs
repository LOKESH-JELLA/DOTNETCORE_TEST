using TS_LRS.Utilities.FileManager.Interfaces;

namespace TS_LRS.Utilities.FileManager
{
    public class FileManager : IFileManager
    {
        public async Task<bool> UploadFile(IFormFile file, string filename, string filePath)
        {
            bool isCopied = false;
            try
            {
                if (file != null)
                {
                    string fileName = filename; // file.FileName;
                    string extension = Path.GetExtension(fileName);
                    if (extension.ToLower() == ".pdf")
                    {
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                            isCopied = true;
                        }
                    }
                    else
                    {
                        throw new Exception("File must be either .pdf");
                    }
                }
                return isCopied;
            }
            catch (Exception ex)
            {
                string errmsg = ex.Message.ToString();
                throw ex;
            }
        }
    }
}
