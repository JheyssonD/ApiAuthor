using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAuthor.Services
{
    public interface IService
    {
        void ExecuteTask();
        Guid GetScoped();
        Guid GetSingleton();
        Guid GetTrasient();
    }

    public class ServiceA : IService
    {
        private readonly ILogger<ServiceA> Logger;
        public readonly ServiceTrasient ServiceTrasient;
        public readonly ServiceScoped ServiceScoped;
        public readonly ServiceSingleton ServiceSingleton;

        public ServiceA(ILogger<ServiceA> logger, ServiceTrasient serviceTrasient, ServiceScoped serviceScoped, ServiceSingleton serviceSingleton)
        {
            Logger = logger;
            ServiceTrasient = serviceTrasient;
            ServiceScoped = serviceScoped;
            ServiceSingleton = serviceSingleton;
        }

        public void ExecuteTask()
        {
            throw new NotImplementedException();
        }

        public Guid GetTrasient() { return ServiceTrasient.Guid; }
        public Guid GetScoped() { return ServiceScoped.Guid; }
        public Guid GetSingleton() { return ServiceSingleton.Guid; }

    }

    public class ServiceB : IService
    {
        private readonly ILogger<ServiceB> Logger;
        public readonly ServiceTrasient ServiceTrasient;
        public readonly ServiceScoped ServiceScoped;
        public readonly ServiceSingleton ServiceSingleton;
        public ServiceB(ILogger<ServiceB> logger, ServiceTrasient serviceTrasient, ServiceScoped serviceScoped, ServiceSingleton serviceSingleton)
        {
            Logger = logger;
            ServiceTrasient = serviceTrasient;
            ServiceScoped = serviceScoped;
            ServiceSingleton = serviceSingleton;
        }

        public void ExecuteTask()
        {
            throw new NotImplementedException();
        }

        public Guid GetTrasient() { return ServiceTrasient.Guid; }
        public Guid GetScoped() { return ServiceScoped.Guid; }
        public Guid GetSingleton() { return ServiceSingleton.Guid; }
    }

    public class ServiceTrasient
    {
        public readonly Guid Guid = Guid.NewGuid();
    }
    public class ServiceScoped
    {
        public readonly Guid Guid = Guid.NewGuid();
    }
    public class ServiceSingleton
    {
        public readonly Guid Guid = Guid.NewGuid();
    }
}
