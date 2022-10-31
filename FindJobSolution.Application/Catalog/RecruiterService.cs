using FindJobSolution.Application.Catalog;
using FindJobSolution.Application.Common;
using FindJobSolution.Data.EF;
using FindJobSolution.Data.Entities;
using FindJobSolution.Utilities.Exceptions;
using FindJobSolution.ViewModels.Catalog.Recruiters;
using FindJobSolution.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace FindJobSolution.Application.Catalog
{
    public interface IRecruiterService
    {
        Task<int> Update(RecruiterUpdateRequest request);

        Task<int> Delete(int Recuiterid);

        Task<RecruiterVM> GetById(int Recuiterid);

        Task<PagedResult<RecruiterVM>> GetAllPaging(GetRecuiterPagingRequest request);

        Task<List<RecruiterVM>> GetAll();
    }
}

public class RecruiterService : IRecruiterService
{
    private readonly FindJobDBContext _context;
    private readonly IStorageService _storageService;

    public RecruiterService(FindJobDBContext context, IStorageService storageService)
    {
        _context = context;
        _storageService = storageService;
    }

    public async Task<int> Delete(int Recuiterid)
    {
        //nếu có recruiters thì xóa
        var recruiters = await _context.Recruiters.FindAsync(Recuiterid);
        if (recruiters == null) { throw new FindJobException($"cannot find a Recruiter: {Recuiterid}"); }

        //xóa ảnh
        var thumbnailCv = _context.RecruiterImages.Where(i => i.RecruiterId == Recuiterid);
        foreach (var image in thumbnailCv)
        {
            await _storageService.DeleteFileAsync(image.FilePath);
        }

        //xóa recruiters
        _context.Recruiters.Remove(recruiters);
        //tìm user của recruiters đó, xong xóa
        var userId = await _context.Users.FindAsync(recruiters.UserId);
        if (userId != null)
        {
            _context.Users.Remove(userId);
        }

        return await _context.SaveChangesAsync();
    }

    public async Task<List<RecruiterVM>> GetAll()
    {
        var query = from j in _context.Recruiters
                    join i in _context.RecruiterImages on j.RecruiterId equals i.RecruiterId
                    select new { j, i };

        return await query
           .Select(p => new RecruiterVM()
           {
               CompanyName = p.j.CompanyName,
               Address = p.j.Address,
               CompanyIntroduction = p.j.CompanyIntroduction,
               ViewCount = p.j.ViewCount,
               ThumbnailCv = p.i.FilePath,
           }).ToListAsync();
    }

    public async Task<PagedResult<RecruiterVM>> GetAllPaging(GetRecuiterPagingRequest request)
    {
        var query = from j in _context.Recruiters
                    join i in _context.RecruiterImages on j.RecruiterId equals i.RecruiterId
                    select new
                    {
                        CompanyName = j.CompanyName,
                        Address = j.Address,
                        CompanyIntroduction = j.CompanyIntroduction,
                        ViewCount = j.ViewCount,
                        ThumbnailCv = i.FilePath,
                    };

        if (!string.IsNullOrEmpty(request.keyword))
            query = query.Where(x => x.CompanyName.Contains(request.keyword));

        //phân trang

        int totalRow = await query.CountAsync();

        var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(p => new RecruiterVM()
            {
                CompanyName = p.CompanyName,
                Address = p.Address,
                CompanyIntroduction = p.CompanyIntroduction,
                ViewCount = p.ViewCount,
                ThumbnailCv = p.ThumbnailCv,
            }).ToListAsync();

        // in ra
        var pagedResult = new PagedResult<RecruiterVM>()
        {
            TotalRecord = totalRow,
            Items = data
        };

        return pagedResult;
    }

    public async Task<RecruiterVM> GetById(int Recuiterid)
    {
        var query = from j in _context.Recruiters
                    join i in _context.RecruiterImages on j.RecruiterId equals i.RecruiterId
                    where i.IsDefault == true
                    select new { j, i };

        var recruiters = await _context.Recruiters.FindAsync(Recuiterid);
        if (recruiters == null) { throw new FindJobException($"cannot find a recruiters: {recruiters}"); }
        var jobItem = new RecruiterVM()
        {
            CompanyName = recruiters.CompanyName,
            Address = recruiters.Address,
            CompanyIntroduction = recruiters.CompanyIntroduction,
            ViewCount = recruiters.ViewCount,
            ThumbnailCv = query.Select(i => i.i.FilePath).FirstOrDefault(),
        };
        return jobItem;
    }

    public async Task<int> Update(RecruiterUpdateRequest request)
    {
        var recruiters = await _context.Recruiters.FindAsync(request.RecruiterId);
        if (recruiters == null) throw new FindJobException($"Cannot find a recruiters with id: {request.RecruiterId}");

        recruiters.CompanyName = request.CompanyName;
        recruiters.Address = request.Address;
        recruiters.CompanyIntroduction = request.CompanyIntroduction;

        if (request.ThumbnailRecuiter != null)
        {
            var thumbnailCv = await _context.RecruiterImages.FirstOrDefaultAsync(i => i.IsDefault == true && i.RecruiterId == request.RecruiterId);
            if (thumbnailCv != null)
            {
                thumbnailCv.Caption = request.nameImage;
                thumbnailCv.FileSize = request.ThumbnailRecuiter.Length;
                thumbnailCv.FilePath = await this.SaveFile(request.ThumbnailRecuiter);
                _context.RecruiterImages.Update(thumbnailCv);
            }
            else
            {
                recruiters.RecruiterImages = new List<RecruiterImages>()
                    {
                        new RecruiterImages()
                        {
                            Caption = request.nameImage,
                            DateCreated = DateTime.Now,
                            FileSize = request.ThumbnailRecuiter.Length,
                            FilePath = await this.SaveFile(request.ThumbnailRecuiter),
                            IsDefault = true,
                            SortOrder = 1,
                        }
                    };
                _context.RecruiterImages.AddRange(recruiters.RecruiterImages);
            }
        }
        return await _context.SaveChangesAsync();
    }

    private async Task<string> SaveFile(IFormFile file)
    {
        var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
        await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
        return fileName;
    }
}