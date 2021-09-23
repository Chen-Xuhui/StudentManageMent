using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StudentManageMent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManageMent
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddXmlSerializerFormatters();
            //使用AddSingleton对接口指向实现
            services.AddSingleton<IStudentRepository, MockStudentRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region 加载默认配置文件和静态文件中间件，方法一：
            //修改默认的文件配置名
            //DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            //defaultFilesOptions.DefaultFileNames.Clear();
            //defaultFilesOptions.DefaultFileNames.Add("52ABP.html");

            ////添加默认文件中间件(UseDefaultFiles:默认只处理index.html、index.htm、default.html、default.htm；下面通过DefaultFilesOptions对象实例更改为52ABP.html)
            //app.UseDefaultFiles(defaultFilesOptions);
            #endregion

            //添加静态文件中间件
            app.UseStaticFiles();

            //添加MVC
            //app.UseMvcWithDefaultRoute();

            app.UseMvc(routes =>
           {
               routes.MapRoute(
                   name: "default",
                   template: "{controller=Home}/{action=Index}/{id?}");
           });

            #region 方法二：
            //FileServerOptions fileServerOptions = new FileServerOptions();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("52ABP.html");

            //app.UseFileServer(fileServerOptions);
            #endregion

            app.Run(async (context) =>
            {
                //拿到托管模式相应的进程名
                //var processName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
                //var processName = _configuration["MyKey"];
                await context.Response.WriteAsync("MW3:处理请求，并生成响应！");
            });
        }
    }
}
