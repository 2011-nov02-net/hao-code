using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HelloAspNetCore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //app.Use(async (context, next) =>
                //{
                //    try
                //    {
                //        await next();
                //    }
                //    catch (Exception e)
                //    {
                //        await context.Response.WriteAsync(e.ToString());
                //    }
                //});
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {

                    string content = "Content has been relocated!";

                    await context.Response.WriteAsync(content);
                });
                //               route parameter
                //                         |
                endpoints.MapGet("/asdf/{word}", async context =>
                {
                    // e.g. /asdf/microsoft?name=nick
                    // works by itself
                    var word = context.Request.RouteValues["word"];
                    // does not work by itself
                    // ?"name"=xxx, change "name" to anything, but match it in the url
                    var name = context.Request.Query["name"];

                    
                    await context.Response.WriteAsync($"Hello {name}! ({word})");
                });
            });

            app.Use(async (context, next) =>
            {
                // request processing logic before the next middleware runs
                if (context.Request.Path == "/htmlpage.html")
                {
                    string requestpath = context.Request.Path.ToString().Substring(1);
                    // remove / and becomes a relative path
                    // await context.Response.WriteAsync(requestpath);
                    // relative path works
                    // /htmlpage.html -> c:\
                    string content = File.ReadAllText("htmlpage.html");

                    await context.Response.WriteAsync(content);
                }
                else
                {
                    // later middlewares run
                    await next();
                    // request processing logic that runs AFTER any later middlewares
                    Console.WriteLine("this prints after the other delegate runs");
                }
            });

            app.Run(async context =>
            {
                // this object has all the details of the request
                HttpRequest request = context.Request;

                // we can modify this object to set up the response.
                HttpResponse response = context.Response;

                response.ContentType = "text/html";
                await response.WriteAsync(@"<!DOCTYPE html>
<html>
  <head>
  </head>
  <body>
    Falls all the way to a terminal
  </body>
</html>
");
            });
        }
    }
}
