using System.Collections.Generic;
using System.Linq;
using DataSystem.Models;
using DataSystem.Models.ViewModels.chart;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using Microsoft.AspNetCore.Identity;
using DataTables.AspNet.AspNetCore;
using System;
using DataSystem.Data;
using System.Threading.Tasks;

namespace DataSystem.Controllers
{
    [Authorize]
    public class ChecksController:Controller
    {
        private readonly WebNutContext _db;
        private readonly ApplicationDbContext _app;
        public ChecksController(WebNutContext db, ApplicationDbContext App)
        {
           _db=db;
           _app=App;
        }

        public  IActionResult Index()
        {
            return View();
        }

        public IActionResult plist()
        {
            return View();
        }

        public IActionResult hlistm()
        {
            return View();
        }

        public IActionResult hlistmsection()
        {
            return View();
        }
        public IActionResult plistdata()
        {
            var data =_db.provincemonthly.FromSql("SELECT * FROM provincemonthly");

            return Ok(new {data=data});
        }
        public int tenant(string user_name)
        {
           var item =  _app.Users.Include(m => m.TenantId).SingleOrDefault(m => m.UserName == user_name);
            return item.TenantId;
        }
          public IActionResult reportstat()
          {
            // ProvId ="20-1396";
            string UserName;
            UserName=User.Identity.Name;
            var data = _db.monthlysubmission.FromSql("Select * from monthlysubmission").ToList();

            if(!data.Any())
                    {
                        return NotFound();
                    }

            if(User.IsInRole("administrator")|| UserName==null)
            {
                data=data.ToList();
                //data = _db.monthlysubmission.FromSql("Select * from monthlysubmission WHERE UserName= {0} and Tenant= {1}",UserName,tenant(UserName)).ToList();                   
            } 
             else if(User.IsInRole("administrator")&&tenant(UserName)!=1)
            {
                data = _db.monthlysubmission.FromSql("Select * from monthlysubmission WHERE UserName= {0} and Tenant= {1}",UserName,tenant(UserName)).ToList();                   
            }
            else if (User.IsInRole("dataentry"))
            {
                data = _db.monthlysubmission.FromSql("Select * from monthlysubmission WHERE UserName= {0}",UserName).ToList();                   
            }

             return Ok(new {data=data});
          }

 public IActionResult hmonthtrend(string ProvId)
          {
            string UserName;
            UserName=User.Identity.Name;
            var data = _db.monthlysubmission.FromSql("Select * from monthlysubmission WHERE ProvId = {0}",ProvId).ToList();

            if(!data.Any())
                    {
                        return NotFound();
                    }

             return Ok(new {data=data});
          }

          public IActionResult completeness(string MyId)
          {
            string UserName;
            UserName=User.Identity.Name;

            var data = _db.checkcompleteness.FromSql("Select * from NMR_checkcompleteness WHERE MyId = {0}",MyId).ToList();

            if(!data.Any())
                    {
                        return NotFound();
                    }
             return Ok(new {data=data});
          }
    }
}