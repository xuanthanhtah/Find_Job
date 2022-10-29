using FindJobSolution.Data.EF;
using FindJobSolution.Utilities.Exceptions;
using FindJobSolution.ViewModels.Catalog.Cvs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindJobSolution.Data.Entities;

namespace FindJobSolution.Application.Catalog.Cvs
{
    public interface ICvService
    {
        Task<int> Create(CvCreateRequest request);
        Task<int> Update(CvUpdateRequest request);
        Task<int> Delete(int CvId);
        Task<List<CvViewModel>> GetAll();
        Task<CvViewModel> GetById(int CvId);
    }

    public class CvService : ICvService
    {
        private readonly FindJobDBContext _context;
        public CvService(FindJobDBContext context)
        {
            _context = context;
        }
        public async Task<int> Create(CvCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int CvId)
        {
            throw new NotImplementedException();
        }

        public Task<List<CvViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CvViewModel> GetById(int CvId)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(CvUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
