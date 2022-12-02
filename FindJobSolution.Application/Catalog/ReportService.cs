using FindJobSolution.Data.EF;
using FindJobSolution.Data.Entities;
using FindJobSolution.ViewModels.Catalog.Report;
using FindJobSolution.ViewModels.Common;
using Microsoft.EntityFrameworkCore;

namespace FindJobSolution.Application.Catalog
{
    public interface IReportService
    {
        Task<bool> Create(ReportCreateRequest request);

        Task<PagedResult<ReportVM>> GetAllPaging(GetReportPagingRequest request);

        Task<bool> Delete(int id);
    }

    public class ReportService : IReportService
    {
        private readonly FindJobDBContext _context;

        public ReportService(FindJobDBContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(ReportCreateRequest request)
        {
            var report = new Report()
            {
                Name = request.Name,
                Content = request.Content,
                Date = DateTime.Now
            };

            _context.Reports.Add(report);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var report = await _context.Reports.FindAsync(id);
            if (report == null) { return false; }

            var test = _context.Reports.Remove(report);
            if (test == null) { return false; }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<PagedResult<ReportVM>> GetAllPaging(GetReportPagingRequest request)
        {
            //lấy job ra
            var query = from j in _context.Reports select new { j };

            //Kiểm tra có nhập vào không
            if (!string.IsNullOrEmpty(request.keyword))
                query = query.Where(x => x.j.Content.Contains(request.keyword));

            //phân trang

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(p => new ReportVM()
                {
                    id = p.j.Id,
                    Name = p.j.Name,
                    Content = p.j.Content,
                    Date = p.j.Date
                }).ToListAsync();

            // in ra
            var pagedResult = new PagedResult<ReportVM>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };

            return pagedResult;
        }
    }
}