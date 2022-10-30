using FindJobSolution.Application.Catalog;
using FindJobSolution.Application.Common;
using FindJobSolution.Data.EF;
using FindJobSolution.ViewModels.Catalog.Recruiters;
using FindJobSolution.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

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

    public Task<int> Delete(int Recuiterid)
    {
        throw new NotImplementedException();
    }

    public Task<List<RecruiterVM>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<PagedResult<RecruiterVM>> GetAllPaging(GetRecuiterPagingRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<RecruiterVM> GetById(int Recuiterid)
    {
        throw new NotImplementedException();
    }

    public Task<int> Update(RecruiterUpdateRequest request)
    {
        throw new NotImplementedException();
    }

    private async Task<string> SaveFile(IFormFile file)
    {
        var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
        await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
        return fileName;
    }
}