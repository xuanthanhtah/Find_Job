using FindJobSolution.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;

namespace FindJobSolution.WebApp.Controllers.Componets
{
    public class PagerViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PagedResultBase request)
        {
            return Task.FromResult((IViewComponentResult)View("Defaut", request));
        }
    }
}