using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tasks.Data.Base;
using Tasks.Data.Repositories;
using Tasks.Data.Repositories.Interfaces;
using Tasks.Data.Services;
using Tasks.Data.Services.Interfaces;


namespace Tasks.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddCors(o => o.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));


            var connection = @"Server=tcp:ckoplin.database.windows.net,1433;Initial Catalog=ckoplindatabase;Persist Security Info=False;User ID=ckoplin;Password=H4ckdb123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            services.AddDbContext<TasksContext>(options =>
            options.UseSqlServer(connection));

            services.AddMvc();

            services.AddScoped<DbContext, TasksContext>();

            //repository's
            services.AddScoped(typeof(ITasksRepository<>), typeof(TasksRepository<>));
            services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));

            //services
            services.AddScoped<ITaskService, TaskService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowAll");
            app.UseMvc();
        }
    }
}
