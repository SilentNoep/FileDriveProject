using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using FileProject.Infra;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var principal = HttpContext.User;
                var userID = int.Parse(principal.Claims.First().Value);

                var listOfFiles = await _fileService.GetUsersFiles(userID);
                if (listOfFiles != null)
                    return new ObjectResult(listOfFiles);
                else
                    return NotFound();
            }
            catch (Exception e)
            {
                string lol = e.Message.ToString();
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] File file)
        {
            try
            {
                bool DidLogIn = await _fileService.AddFile(file);
                if (DidLogIn)
                    return new ObjectResult(true);
                else
                    return NotFound();
            }
            catch (Exception e)
            {
                string lol = e.InnerException.ToString();
                return BadRequest();
            }
        }

        [HttpGet("{FileID}")]
        public async Task<IActionResult> Get(int FileID)
        {
            try
            {
                var principal = HttpContext.User;
                var userID = int.Parse(principal.Claims.First().Value);
                var File = await _fileService.GetFile(FileID, userID);
                if (File != null)
                    return new ObjectResult(File);
                else
                    return NotFound();
            }
            catch (Exception e)
            {
                string lol = e.InnerException.ToString();
                return BadRequest();
            }
        }
    }
}