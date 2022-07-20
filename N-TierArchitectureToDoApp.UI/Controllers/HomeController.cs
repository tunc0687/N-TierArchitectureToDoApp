using Microsoft.AspNetCore.Mvc;
using N_TierArchitectureToDoApp.Service.WorksServices;
using N_TierArchitectureToDoApp.Service.WorksServices.Dtos.RequestDtos;

namespace N_TierArchitectureToDoApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorksService _worksService;

        public HomeController(IWorksService worksService)
        {
            _worksService = worksService;
        }

        public async Task<IActionResult> Index()
        {
            var workList = await _worksService.GetAll();
            return View(workList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new WorksAddRequest());
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorksAddRequest request)
        {
            if (ModelState.IsValid)
            {
                await _worksService.Add(request);
                return RedirectToAction("Index");
            }
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var work = await _worksService.GetById(id);
            return View(new WorksUpdateRequest
            {
                Id = id,
                Description = work.Description,
                IsCompleted = work.IsCompleted,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(WorksUpdateRequest request)
        {
            if (ModelState.IsValid)
            {
                await _worksService.Update(request);
                return RedirectToAction("Index");
            }
            return View(request);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _worksService.DeleteById(id);
            return RedirectToAction("Index");
        }
    }
}
