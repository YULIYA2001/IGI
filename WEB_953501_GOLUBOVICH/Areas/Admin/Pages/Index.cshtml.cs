using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEB_953501_GOLUBOVICH.Data;
using WEB_953501_GOLUBOVICH.Entities;

namespace WEB_953501_GOLUBOVICH.Areas.Admin.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly WEB_953501_GOLUBOVICH.Data.ApplicationDbContext _context;

        public IndexModel(WEB_953501_GOLUBOVICH.Data.ApplicationDbContext context)
        {
            
            _context = context;
        }

        public IList<Dish> Dish { get;set; }

        public async Task OnGetAsync()
        {
            Dish = await _context.Dishes
                .Include(d => d.Group).ToListAsync();
        }
    }
}
