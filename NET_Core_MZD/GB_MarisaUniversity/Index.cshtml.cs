using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GB_MarisaUniversity.Models;

namespace GB_MarisaUniversity
{
    public class IndexModel : PageModel
    {
        private readonly GB_MarisaUniversity.Models.SchoolContext _context;

        public IndexModel(GB_MarisaUniversity.Models.SchoolContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; }

        public async Task OnGetAsync()
        {
            Student = await _context.Student.ToListAsync();
        }
    }
}
