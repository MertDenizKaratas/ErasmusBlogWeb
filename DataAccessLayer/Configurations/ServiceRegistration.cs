using DataAccessLayer.Abstract;
using DataAccessLayer.Abstract.Authentication;
using DataAccessLayer.Implementation;
using DataAccessLayer.Implementation.Authentication;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services,IConfiguration conf)
        {
            
            services.AddDbContext<DatabaseContext>(options => options.UseLazyLoadingProxies().UseSqlServer(conf.GetConnectionString("conn")));
            //Identity
            services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<DatabaseContext>();
            //Services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IWriterService, WriterService>();
            services.AddScoped<IHeaderService, HeaderService>();
            services.AddScoped<IContentHeader, ContentService>();
            services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
            services.AddScoped<IMessageService, MessageService>();
        }
    }
}
