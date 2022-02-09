using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.Domain;
using WebShop.Core.Dtos;
using WebShop.Core.ServiceInterface;
using WebShop.Data;

namespace WebShop.ApplicationServices.Services
{
 /*   public class FileServiceForSpaceship : IFileServiceForSpaceship
    {
        private readonly WebShopDbContext _context;
        private readonly IWebHostEnvironment _env;

        public FileServiceForSpaceship
            (
            WebShopDbContext context,
            IWebHostEnvironment env
            )
        {
            _context = context;
            _env = env;
        }
        public async Task<ExistingFilePathForSpaceship> RemoveImage(ExistingFilePathForSpaceshipDto dto)
        {
            var imageId = await _context.ExistingFilePathsForSpaceship
                .FirstOrDefaultAsync(x => x.FilePath == dto.FilePath);

            string photoPath = _env.WebRootPath + "\\multipleFileUpload\\" + dto.FilePath;

            File.Delete(photoPath);

            _context.ExistingFilePathsForSpaceship.Remove(imageId);
            await _context.SaveChangesAsync();

            return imageId;
        }

        public async Task<ExistingFilePathForSpaceship> RemoveImages(ExistingFilePathForSpaceshipDto[] dto)
        {
            foreach (var dtos in dto)
            {
                var fileId = await _context.ExistingFilePathsForSpaceship
                .FirstOrDefaultAsync(x => x.FilePath == dtos.FilePath);
                string photoPath = _env.WebRootPath + "\\multipleFileUpload" + dtos.FilePath;
                File.Delete(photoPath);

                _context.ExistingFilePathsForSpaceship.Remove(fileId);
                await _context.SaveChangesAsync();
                return fileId;
            }
            return null;
        }

        public string ProcessUploadedFile(SpaceshipDto dto, Spaceship spaceship)
        {
            string uniqueFileName = null;

            if (dto.Files != null && dto.Files.Count > 0)
            {

                if (!Directory.Exists(_env.WebRootPath + "\\multipleFileUpload\\"))
                {
                    Directory.CreateDirectory(_env.WebRootPath + "\\multipleFileUpload\\");
                }

                foreach (var photo in dto.Files)
                {
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "multipleFileUpload");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(fileStream);

                        ExistingFilePathForSpaceship paths = new ExistingFilePathForSpaceship
                        {
                            Id = Guid.NewGuid(),
                            FilePath = uniqueFileName,
                            SpaceshipId = spaceship.Id
                        };

                        _context.ExistingFilePathsForSpaceship.Add(paths);
                    }
                }

            }
            return uniqueFileName;
        }
    }*/
} 
