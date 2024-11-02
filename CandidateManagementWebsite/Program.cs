namespace CandidateManagementWebsite;
using Candidate_Repository;
using Candidate_Service;
using CandidateManagementWebsite.Data;
using Microsoft.EntityFrameworkCore;


public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddScoped<ICandidateProfileRepo, CandidateProfileRepo>();
        builder.Services.AddScoped<ICandidateProfileService, CandidatePRofileService>();
       

        builder.Services.AddScoped<IJobPosTingService, JobPosTingService>();
        builder.Services.AddScoped<IJobPosTingRepo, JobPosTingRepo>();

        builder.Services.AddScoped<IHRAccountService, HRAccountService>();
        builder.Services.AddScoped<IHRAccountRepo, HRAcccountRepo>();

        builder.Services.AddDbContext<CandidateManagementWebsiteContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnect") ?? throw new InvalidOperationException("Connection string 'DBConnect' not found.")));

        builder.Services.AddSession();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, xsee https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.UseSession();
        app.Run();
    }
}

