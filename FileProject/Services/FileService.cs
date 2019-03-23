using Common;
using FileProject.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileProject.Services
{
    public class FileService : IFileService
    {
        private readonly IRepository repository;
        public FileService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<IEnumerable<File>> GetUsersFiles(int id)
        {
            var files = await repository.GetFiles(id);
            List<File> newList = new List<File>();
            foreach (var item in files)
            {
                File newFile = new File()
                {
                    DateUploaded = item.DateUploaded,
                    Description = item.Description,
                    FileID = item.FileID,
                    FileEnding = item.FileEnding,
                    FileName = item.FileName,
                    Path = item.Path
                };
                newList.Add(newFile);

            }
            return newList; // New List Without Content
        }

        public async Task<bool> AddFile(File file)
        {
            await repository.AddFile(file);
            return true;
        }

        public async Task<File> GetFile(int FileID, int UserID)
        {
            var file = await repository.GetFile(FileID, UserID);
            return file;
        }
    }
}
