using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.DAL;
using WebUI.Models;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context { get; }
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeViewModel home = new HomeViewModel
            {
                Slides = _context.Slides.ToList(),
                Summary=_context.Summary.FirstOrDefault(),
                Category=_context.Category.Where(c=>!c.IsDeleted).ToList(),
                Product=_context.Product.Where(c=>!c.IsDeleted)
                .Include(p=>p.Images).Include(c=>c.Category).ToList(),
                Video = _context.Video.FirstOrDefault(),
                VideoSummary=_context.VideoSummaries.FirstOrDefault(),
                VideoSummaryList=_context.VideoSummaryList.ToList(),
                ExpertsSummary=_context.ExpertsSummary.FirstOrDefault(),
                Experts=_context.Experts.ToList(),
                Blog=_context.Blogs.FirstOrDefault(),
                BlogCard=_context.BlogCards.ToList()
            };

            return View(home);
        }
    }
}

