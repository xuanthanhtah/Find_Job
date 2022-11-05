using FindJobSolution.AdminApp.API;
using FindJobSolution.ViewModels.Catalog.Jobs;
using FindJobSolution.ViewModels.Catalog.Skills;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindJobSolution.AdminApp.Controllers
{
    [Authorize]
    public class SkillController : Controller
    {
        private readonly ISkillAPI _SkillAPI;
        private readonly IConfiguration _configuration;

        public SkillController(ISkillAPI SkillAPI, IConfiguration configuration)
        {
            _SkillAPI = SkillAPI;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index(string keyWord, int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetSkillPagingRequest()
            {
                keyword = keyWord,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _SkillAPI.GetAllPaging(request);
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SkillCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _SkillAPI.Create(request);
            if (result)
            {
                TempData["result"] = "Create user successfully";
                return RedirectToAction("Index");
            }
            return View(request);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(new SkillDeleteRequest()
            {
                Id = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(SkillDeleteRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _SkillAPI.Delete(request.Id);
            if (result)
            {
                return RedirectToAction("index");
            }
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _SkillAPI.GetById(id);
            if (result != null)
            {
                var user = result;
                var updateRequest = new SkillUpdateRequest()
                {
                    Id = id,
                    Name = user.Name,
                };
                return View(updateRequest);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SkillUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _SkillAPI.Edit(request);
            if (result)
            {
                TempData["result"] = "Cập nhật người dùng thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.ToString());
            return View(request);
        }
    }
}