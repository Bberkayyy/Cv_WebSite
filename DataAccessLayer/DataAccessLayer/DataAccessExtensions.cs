using DataAccessLayer.Abstract;
using DataAccessLayer.BaseContext;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer;

public static class DataAccessExtensions
{
    public static IServiceCollection AddDataAccessExtensions(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("SqlConnection")));

        services.AddIdentity<VisitorUser, VisitorRole>().AddEntityFrameworkStores<BaseDbContext>();

        services.AddScoped<IAboutDal, AboutDal>();
        services.AddScoped<IContactDal, ContactDal>();
        services.AddScoped<IExperianceDal, ExperianceDal>();
        services.AddScoped<IFeatureDal, FeatureDal>();
        services.AddScoped<IMessageDal, MessageDal>();
        services.AddScoped<IPortfolioDal, PortfolioDal>();
        services.AddScoped<IServiceDal, ServiceDal>();
        services.AddScoped<ISkillDal, SkillDal>();
        services.AddScoped<ISocialMediaDal, SocialMediaDal>();
        services.AddScoped<ITestimonialDal, TestimonialDal>();
        services.AddScoped<IUserDal, UserDal>();
        services.AddScoped<IUserMessageDal, UserMessageDal>();
        services.AddScoped<IToDoListDal, ToDoListDal>();
        services.AddScoped<IAnnouncementDal, AnoouncementDal>();
        services.AddScoped<IVisitorMessageDal, VisitorMessageDal>();
        return services;
    }
}
