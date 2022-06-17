using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.ViewModels
{
    public class HomeViewModel
    {
        public List<Slide> Slides { get; set; }
        public Summary Summary { get; set; }
        public List<Category> Category { get; set; }
        public List<Product> Product { get; set; }
        public Video Video { get; set; }
        public VideoSummary VideoSummary { get; set; }
        public List<VideoSummaryList> VideoSummaryList { get; set; }
        public ExpertsSummary ExpertsSummary { get; set; }
        public List<Experts> Experts { get; set; }
        public Blog Blog { get; set; }
        public List<BlogCard> BlogCard { get; set; }


    }
}
