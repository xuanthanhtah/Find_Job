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
        Task<int> Create(SkillCreateRequest request);
        Task<int> Update(SkillUpdateRequest request);
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

        public async Task<int> Create(SkillCreateRequest request)
        {
            var skill = new Skill()
            {
                Name = request.Name,
                Experience = request.Experience,
            };

            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();
            return skill.SkillId;
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
                   Name = p.j.Name,
                   Experience = p.j.Experience,
               }).ToListAsync();

        }

        public async Task<PagedResult<SkillViewModel>> GetAllPaging(GetSkillPagingRequest request)
        {
            //lấy skill ra
            var query = from j in _context.Skills select new { j };

            //Kiểm tra có nhập vào không
            if (!string.IsNullOrEmpty(request.keyword))
                query = query.Where(x => x.j.Name.Contains(request.keyword));


            if (request.skillIds.Count > 0)
            {
                query = query.Where(x => request.skillIds.Contains(x.j.SkillId));
            }

            //phân trang

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(p => new SkillViewModel()
                {
                    Name = p.j.Name,
                    Experience = p.j.Experience
                }).ToListAsync();

            // in ra 
            var pagedResult = new PagedResult<SkillViewModel>()
            {
                TotalRecord = totalRow,
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
                Name = skill.Name,
                Experience = skill.Experience,
            };
            return skillItem;
        }

        public async Task<int> Update(SkillUpdateRequest request)
        {
            var skill = await _context.Skills.FindAsync(request.SkillId);

            if (skill == null) { throw new FindJobException($"cannot find a skill: {request.SkillId}"); }

            skill.Name = request.Name;
            skill.Experience = request.Experience;

            return await _context.SaveChangesAsync();
        }
    }
}
