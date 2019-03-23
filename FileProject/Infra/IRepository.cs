using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileProject.Infra
{
    public interface IRepository
    {
        User GetUserFromDB(User user);
        Task<User> Register(User user);
        Task<IEnumerable<File>> GetFiles(int id);
        Task<bool> AddFile(File file);
        Task<File> GetFile(int FileID, int UserID);
    }
}
