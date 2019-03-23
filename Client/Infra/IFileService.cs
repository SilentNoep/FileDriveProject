using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Client.Infra
{
    public interface IFileService
    {
        Task<IEnumerable<File>> GetFileList(string userToken);
        Task<bool> UploadFile(File file);
        Task<File> DownloadFile(int FileID, string userToken);


        Task<File> Browse();
        Task<bool> SaveFile(File file);
    }
}
