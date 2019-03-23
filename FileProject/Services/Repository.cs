using Common;
using FileProject.Data;
using FileProject.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FileProject.Services
{
    public class Repository : IRepository
    {
        private readonly UserContext _dbContext;

        public Repository(UserContext userContext)
        {
            _dbContext = userContext;
        }
        public User GetUserFromDB(User user)
        {
            var USER = _dbContext.Users.FirstOrDefault(u => u.Email == user.Email);
            return USER;
        }
        public async Task<User> Register(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            var newUserInDB = GetUserFromDB(user);
            return newUserInDB;
        }
        public async Task<IEnumerable<File>> GetFiles(int id)
        {
            var files = _dbContext.Files.Where(u => u.UserID == id).ToList();
            return files;
        }
        public async Task<bool> AddFile(File file)
        {
            _dbContext.Files.Add(file);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<File> GetFile(int FileID, int UserID)
        {
            var file = _dbContext.Files.FirstOrDefault(u => u.FileID == FileID && UserID == u.UserID);
            return file;
        }
    }
}
