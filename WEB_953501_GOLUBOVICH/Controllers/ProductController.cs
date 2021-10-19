using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_953501_GOLUBOVICH.Data;
using WEB_953501_GOLUBOVICH.Entities;
using WEB_953501_GOLUBOVICH.Extensions;
using WEB_953501_GOLUBOVICH.Models;

namespace WEB_953501_GOLUBOVICH.Controllers
{
    public class ProductController : Controller
    {
        private ILogger _logger;
        ApplicationDbContext _context;
        int _pageSize;
        public ProductController(ApplicationDbContext context, ILogger<ProductController> logger)
        {
            _pageSize = 3;
            _context = context;
            _logger = logger;
        }

        [Route("Catalog")]
        [Route("Catalog/Page_{PageNo}")]
        public IActionResult Index(int? group, int pageNo=1)
        {
            //var groupMame = group.HasValue?_context.DishGroups.Find(group.Value)?.GroupName:"all groups";
            //_logger.LogInformation($"info: group={group}, page={pageNo}");
            var dishesFiltered = _context.Dishes.Where(d => !group.HasValue || d.DishGroupId == group.Value);
            // Поместить список групп во ViewData
            ViewData["Groups"] = _context.DishGroups;
            // Получить id текущей группы и поместить в TempData
            ViewData["CurrentGroup"] = group ?? 0;

            var model = ListViewModel<Dish>.GetModel(dishesFiltered, pageNo, _pageSize);
            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);
            else
                return View(model);
        }
    }
}
