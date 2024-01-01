using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer;

public static class BusinessExtensions
{
    public static IServiceCollection AddServiceExtensions(this IServiceCollection services)
    {
        services.AddScoped<IAboutService, AboutService>();
        services.AddScoped<IContactService, ContactService>();
        services.AddScoped<IExperianceService, ExperianceService>();
        services.AddScoped<IFeatureService, FeatureService>();
        services.AddScoped<IMessageService, MessageService>();
        services.AddScoped<IPortfolioService, PortfolioService>();
        services.AddScoped<IServiceService, ServiceService>();
        services.AddScoped<ISkillService, SkillService>();
        services.AddScoped<ISocialMediaService, SocialMediaService>();
        services.AddScoped<ITestimonialService, TestimonialService>();
        return services;
    }
}
