using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileProject.Infra
{
    public interface IFileService
    {
        Task<IEnumerable<File>> GetUsersFiles(int id);
        Task<bool> AddFile(File file);
        Task<File> GetFile(int FileID, int UserID);
    }
}
