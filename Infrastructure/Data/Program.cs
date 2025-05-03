using System;
using BusinessAPI.Domain;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data
{
  class Program
  {
    static void Main(string[] args)
      => CreateHostBuilder(args).Build().Run();

    public static IHostBuilder CreateHostBuilder(string[] args)
        => Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
              services.AddDbContextPool<AppDBContext>(options =>
                options.UseNpgsql(
                  hostContext.Configuration.GetConnectionString("Postgres"),
                  b => b.MigrationsAssembly(typeof(Program).Assembly.FullName)
                  )
              );
            });
  }
}