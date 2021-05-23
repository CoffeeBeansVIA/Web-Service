using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ArrayList note = new ArrayList();
            note.Add(5);
            note.Add(9);

            double total = 0;
            for (int i = 0; i < note.Count; i++)
            {
                try
                {
                    total= total + Convert.ToDouble(note[i]);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e);
                }
            }

            Console.WriteLine(total/note.Count);
            
            
            CreateHostBuilder(args).Build().Run();
            

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}