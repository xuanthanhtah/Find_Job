using FindJobSolution.Data.EF;
using FindJobSolution.ViewModels.System;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.Application.Catalog
{
    public interface IAdminService
    {
        Task<ReportDataVM> GetReportData();
    }

    public class AdminService : IAdminService
    {
        private readonly FindJobDBContext _context;

        public AdminService(FindJobDBContext context)
        {
            _context = context;
        }

        public async Task<ReportDataVM> GetReportData()
        {
            var reportData = new ReportDataVM();
            reportData.TotalJobSeeker = await _context.JobSeekers.CountAsync();
            reportData.TotalRecuiter = await _context.Recruiters.CountAsync();
            reportData.TotalJobApply = await _context.ApplyJobs.CountAsync();
            reportData.TotalJobInformation = await _context.JobInformations.CountAsync();
            reportData.TotalCv = await _context.Cvs.CountAsync();
            reportData.TotalJob = await _context.Jobs.CountAsync();
            reportData.TotalSkill = await _context.Skills.CountAsync();
            reportData.TotalReport = await _context.Reports.CountAsync();

            var topJobSalary = await _context.JobInformations
                .OrderByDescending(x => x.MaxSalary)
                .FirstOrDefaultAsync();

            if (topJobSalary != null)
            {
                reportData.JobTitle = topJobSalary.JobTitle;
                reportData.JobLevel = topJobSalary.JobLevel;
                reportData.JobType = topJobSalary.JobType;
                reportData.MaxSalary = topJobSalary.MaxSalary;
            }
            else
            {
                reportData.JobTitle = "";
                reportData.JobLevel = "";
                reportData.JobType = "";
                reportData.MaxSalary = 0;
            }

            var topJobApply = await _context.ApplyJobs
                .GroupBy(x => x.JobInformationId)
                .OrderByDescending(x => x.Count())
                .Select(x => x.Key)
                .FirstOrDefaultAsync();

            var CounttopJobApply = await _context.ApplyJobs
                .GroupBy(x => x.JobInformationId)
                .OrderByDescending(x => x.Count())
                .Select(x => x.Count())
                .FirstOrDefaultAsync();

            if (topJobApply != null)
            {
                var job = await _context.JobInformations.FindAsync(topJobApply);
                reportData.JobTitleApply = job.JobTitle;
                reportData.JobLevelApply = job.JobLevel;
                reportData.JobTypeApply = job.JobType;
                reportData.MaxSalaryApply = job.MaxSalary;
                reportData.countJobApplyMax = CounttopJobApply;
            }
            else
            {
                reportData.JobTitleApply = "";
                reportData.JobLevelApply = "";
                reportData.JobTypeApply = "";
                reportData.MaxSalaryApply = 0;
                reportData.countJobApplyMax = 0;
            }

            return reportData;
        }
    }
}