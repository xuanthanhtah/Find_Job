﻿using FindJobSolution.AdminApp.API;
using FindJobSolution.ViewModels.Catalog.Skills;
using FindJobSolution.ViewModels.System.User;
using FindJobSolution.ViewModels.System.UsersJobSeeker;
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
    }
}