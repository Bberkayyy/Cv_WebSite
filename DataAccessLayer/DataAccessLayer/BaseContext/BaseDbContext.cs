using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.BaseContext;

public class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions<BaseDbContext> opt) : base(opt)
    {

    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database = Cv_Db; integrated security = true");

    //}
    public DbSet<About> Abouts { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Experiance> Experiances { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Portfolio> Portfolios { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<SocialMedia> SocialMedias { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }
}
