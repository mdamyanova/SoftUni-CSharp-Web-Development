namespace FluffyDuffyMunchkinCats
{
    using System.Linq;
    using Data;
    using Data.Models;
    using Infrastructure;
    using Services;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CatsDbContext>(options =>
                options.UseSqlServer("Server=.;Database=CatsDb;Integrated Security=True;"));
            services.AddSingleton<ICatService, CatService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            app.Use((context, next) =>
            {
                context.RequestServices.GetRequiredService<CatsDbContext>().Database.Migrate();
                return next();
            });

            app.UseStaticFiles();

            app.Use((context, next) =>
            {
                context.Response.Headers.Add("Content-Type", "text/html");
                return next();
            });

            app.MapWhen(
                ctx => ctx.Request.Path.Value == "/"
                       && ctx.Request.Method == HttpMethod.Get,
                home =>
                {
                    home.Run(async (context) =>
                    {
                        await context.Response.WriteAsync($"<h1>{env.ApplicationName}</h1>");

                        var db = context.RequestServices.GetService<CatsDbContext>();

                        var catsData = db.Cats.Select(c => new {c.Id, c.Name}).ToList();

                        await context.Response.WriteAsync("<ul>");

                        foreach (var catData in catsData)
                        {
                            await context.Response.WriteAsync(
                                $@"<li><a href=""/cat/{catData.Id}"">{catData.Name}</a></li>");
                        }

                        await context.Response.WriteAsync("</ul>");
                        await context.Response.WriteAsync(
                            @"<form action=""/cat/add""><input type=""submit"" value=""Add Cat""/></form>");
                    });
                });

            app.MapWhen(
                req => req.Request.Path.Value == "/cat/add",
                catAdd =>
                {           
                    catAdd.Run(async (context) =>
                    {
                        if (context.Request.Method == HttpMethod.Get)
                        {
                            context.Response.Redirect("/cats-add-form.html");
                        }
                        else if (context.Request.Method == HttpMethod.Post)
                        {
                            var db = context.RequestServices.GetService<CatsDbContext>();

                            var formData = context.Request.Form;

                            var age = 0;
                            int.TryParse(formData["Age"], out age);

                            var cat = new Cat
                            {
                                Name = formData["Name"],
                                Age = age,
                                Breed = formData["Breed"],
                                ImageUrl = formData["ImageUrl"]
                            };

                            db.Add(cat);

                            try
                            {
                               await db.SaveChangesAsync();

                               context.Response.Redirect("/");
                            }
                            catch
                            {
                                await context.Response.WriteAsync("<h2>Invalid cat data!</h2>");
                                await context.Response.WriteAsync(
                                    @"a href=""/cat/add"">Back to the Form</a>");
                            }
                        }
                    });
                });
            
            app.Map("/cat/add", catsApp =>
                catsApp.Run(async (context) =>
                    await context.Response.WriteAsync("catsaddpagehere")
                ));

            app.Run(async (context) =>
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("404 Page Was Not Found");
            });
        }
    }
}