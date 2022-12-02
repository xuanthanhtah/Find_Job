using FindJobSolution.Data.EF;
using FindJobSolution.Data.Entities;
using FindJobSolution.Utilities.Exceptions;
using FindJobSolution.ViewModels.Catalog.Skills;
using FindJobSolution.ViewModels.Common;
using Microsoft.EntityFrameworkCore;

namespace FindJobSolution.Application.Catalog
{
    public interface ISkillService
    {
        Task<bool> Create(SkillCreateRequest request);

        Task<bool> Update(SkillUpdateRequest request);

        Task<int> Detele(int SkillId);

        Task<PagedResult<SkillViewModel>> GetAllPaging(GetSkillPagingRequest request);

        Task<List<SkillViewModel>> GetAll();

        Task<SkillViewModel> GetbyId(int SkillId);
    }

    public class SkillService : ISkillService
    {
        private readonly FindJobDBContext _context;

        public SkillService(FindJobDBContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(SkillCreateRequest request)
        {
            var Skill = new Skill()
            {
                Name = request.Name,
            };
            _context.Skills.Add(Skill);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> Detele(int SkillId)

        {
            var skill = await _context.Skills.FindAsync(SkillId);
            if (skill == null) { throw new FindJobException($"cannot find a skill: {SkillId}"); }

            _context.Skills.Remove(skill);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<SkillViewModel>> GetAll()
        {
            var query = from j in _context.Skills select new { j };

            return await query
               .Select(p => new SkillViewModel()
               {
                   Id = p.j.SkillId,
                   Name = p.j.Name,
               }).ToListAsync();
        }

        public async Task<PagedResult<SkillViewModel>> GetAllPaging(GetSkillPagingRequest request)
        {
            //lấy skill ra
            var query = from j in _context.Skills select new { j };

            //Kiểm tra có nhập vào không
            if (!string.IsNullOrEmpty(request.keyword))
                query = query.Where(x => x.j.Name.Contains(request.keyword));

            //phân trang

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(p => new SkillViewModel()
                {
                    Id = p.j.SkillId,
                    Name = p.j.Name,
                }).ToListAsync();

            // in ra
            var pagedResult = new PagedResult<SkillViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };

            return pagedResult;
        }

        public async Task<SkillViewModel> GetbyId(int SkillId)
        {
            var skill = await _context.Skills.FindAsync(SkillId);
            if (skill == null) { throw new FindJobException($"cannot find a skill: {SkillId}"); }
            var skillItem = new SkillViewModel()
            {
                Id = skill.SkillId,
                Name = skill.Name,
            };
            return skillItem;
        }

        public async Task<bool> Update(SkillUpdateRequest request)
        {
            var skill = await _context.Skills.FindAsync(request.Id);

            if (skill == null) { throw new FindJobException($"cannot find a skill: {request.Id}"); }

            skill.Name = request.Name;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}