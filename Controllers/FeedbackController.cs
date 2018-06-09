using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataSystem.Models;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using DataTables.AspNet.Core;
using DataTables.AspNet.AspNetCore;
using DataSystem.Models.ViewModels;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace DataSystem.Controllers
{
    [Authorize(Roles = "dataentry,administrator")]
    public class FeedbackController : Controller
    {
        private readonly WebNutContext _context;

        public FeedbackController(WebNutContext context)
        {
            _context = context; 

        }

        [Authorize(Roles = "dataentry")]
        public async Task<IActionResult> Index(string nmrid)
        {
            if(nmrid ==null){
                return NotFound("id not passed");
            }
            var item=await _context.Nmr.Where(m => m.Nmrid.Equals(nmrid)).SingleOrDefaultAsync();
            if(item ==null){
                return NotFound();
            }
            var model= new Feedback();
            model.Nmrid=item.Nmrid;
            return View(item);
        }


    }
}
