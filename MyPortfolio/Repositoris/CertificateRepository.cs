using Microsoft.EntityFrameworkCore;
using MyPortfolio.Interfaces;
using MyPortfolio.Models;

namespace MyPortfolio.Repositoris
{
    public class CertificateRepository : ICertificateRepository
    {
        private readonly PortfolioDb _context;
        private readonly IWebHostEnvironment _env;

        public CertificateRepository(PortfolioDb context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IEnumerable<Certificate>> GetAllAsync()
        {
            return await _context.Certificates.ToListAsync();
        }

        public async Task<Certificate> GetByIdAsync(int id)
        {
            return await _context.Certificates.FindAsync(id);
        }

        public async Task AddAsync(Certificate certificate)
        {
            _context.Certificates.Add(certificate);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Certificate certificate)
        {
            _context.Certificates.Update(certificate);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cert = await _context.Certificates.FindAsync(id);
            if (cert != null)
            {
                _context.Certificates.Remove(cert);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<string?> UploadCertAsync(IFormFile? uploadedFile)
        {
            if (uploadedFile == null || uploadedFile.Length == 0)
                return null;
            var fileName = Path.GetFileName(uploadedFile.FileName);
            var path = Path.Combine(_env.WebRootPath, "images", fileName);

            // Удалить, если файл уже существует
            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await uploadedFile.CopyToAsync(stream);
            }

            return "/images/" + fileName;
        }
    }
}
