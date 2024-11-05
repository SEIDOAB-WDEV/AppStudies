using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

#region Setup the Dependency service
builder.Services.AddSingleton<IQuoteService, csQuoteService>();
builder.Services.AddScoped<IMusicService, csMusicServiceWapi>();
builder.Services.AddHttpClient(name: "MusicWebApi", configureClient: options =>
{
//    options.BaseAddress = new Uri("https://seido-webservice-307d89e1f16a.azurewebsites.net/api/");
    options.BaseAddress = new Uri(Configuration.csAppConfig.ConfigurationRoot["WebApiBaseUri"]);
    options.DefaultRequestHeaders.Accept.Add(
        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(
            mediaType: "application/json",
            quality: 1.0));
});
#endregion

var app = builder.Build();

//using Hsts and https to secure the site
if (!app.Environment.IsDevelopment())
{
    //https://en.wikipedia.org/wiki/HTTP_Strict_Transport_Security
    //https://learn.microsoft.com/en-us/aspnet/core/security/enforcing-ssl
    app.UseHsts();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

//Enable static and default files
app.UseDefaultFiles();
app.UseStaticFiles();

//Map Razorpages into Pages folder
app.MapRazorPages();

//Show Mapping works even if it is razor pages, like for WebApi
app.MapGet("/hello", () =>
{
    //read the environment variable ASPNETCORE_ENVIRONMENT
    //Change in launchSettings.json, (not VS2022 Debug/Release)
    var _env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
    var _envMyOwn = Environment.GetEnvironmentVariable("MyOwn");

    return $"Hello World!\nASPNETCORE_ENVIRONMENT: {_env}\nMyOwn: {_envMyOwn}";
});

app.Run();
