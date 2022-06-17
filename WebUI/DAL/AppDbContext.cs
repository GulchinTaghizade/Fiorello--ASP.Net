using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Summary> Summary { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Video> Video { get; set; }
        public DbSet<VideoSummary> VideoSummaries { get; set; }
        public DbSet<VideoSummaryList> VideoSummaryList { get; set; }
        public DbSet<ExpertsSummary> ExpertsSummary { get; set; }
        public DbSet<Experts> Experts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCard> BlogCards { get; set; }
        public DbSet<Settings>  Settings { get; set; }

    }
}
