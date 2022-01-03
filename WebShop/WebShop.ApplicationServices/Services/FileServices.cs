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
using WebShop.Core.Dtos.CarDto;
using WebShop.Core.ServiceInterface;
using WebShop.Data;

namespace WebShop.ApplicationServices.Services
{
    public class FileServices : IFileServices
    {
        private readonly WebShopDbContext _context;
        private readonly IWebHostEnvironment _env;

        public FileServices
            (
                WebShopDbContext context,
                IWebHostEnvironment env
            )
        {
            _context = context;
            _env = env;
        }

        public async Task<ExistingFilePathForCar> RemoveImage(ExistingFilePathForCarDto dto)
        {
            var imageId = await _context.ExistingFilePathForCar
                .FirstOrDefaultAsync(x => x.FilePath == dto.FilePath);

            string photoPath = _env.WebRootPath + "\\multipleFileUpload\\" + dto.FilePath;

            File.Delete(photoPath);

            _context.ExistingFilePathForCar.Remove(imageId);
            await _context.SaveChangesAsync();

            return imageId;
        }

        public async Task<ExistingFilePathForCar> RemoveImages(ExistingFilePathForCarDto[] dto)
        {
            foreach (var dtos in dto)
            {
                var fileId = await _context.ExistingFilePathForCar
                    .FirstOrDefaultAsync(x => x.FilePath == dtos.FilePath);

                string photoPath = _env.WebRootPath + "\\multipleFileUpload\\" + dtos.FilePath;

                File.Delete(photoPath);

                _context.ExistingFilePathForCar.Remove(fileId);
                await _context.SaveChangesAsync();
            }
            return null;
        }

        public string ProcessUploadedFile(CarDto dto, Car car)
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

                        ExistingFilePathForCar paths = new ExistingFilePathForCar
                        {
                            Id = Guid.NewGuid(),
                            FilePath = uniqueFileName,
                            CarId = car.Id
                        };

                        _context.ExistingFilePathForCar.Add(paths);
                    }
                }
            }

            return uniqueFileName;
        }
    }
}
