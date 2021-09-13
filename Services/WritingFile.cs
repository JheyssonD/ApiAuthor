using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ApiAuthor.Services
{
    public class WritingFile : IHostedService
    {
        public readonly IWebHostEnvironment Env;
        public readonly string FileName = "File1.txt";
        public Timer Timer;

        public WritingFile(IWebHostEnvironment env)
        {
            Env = env;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            Write("Proceso inciado");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Timer.Dispose();
            Write("Proceso finalizado");
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            Write("Running process: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
        }

        private void Write(string message)
        {
            var path = $@"{Env.ContentRootPath}\wwwroot\{FileName}";
            using (StreamWriter writer = new StreamWriter(path, append: true))
            {
                writer.WriteLine(message);
            }
        }
    }
}
