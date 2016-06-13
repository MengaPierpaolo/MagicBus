using Microsoft.AspNetCore.Hosting;

namespace TDiary.Api
{
    public class Program
    {
        public static void Main(string[] args)
       {
              var host = new WebHostBuilder()
               .UseKestrel()
               .UseStartup<Startup>()
               .Build();

           host.Run();
       }
    }
}
