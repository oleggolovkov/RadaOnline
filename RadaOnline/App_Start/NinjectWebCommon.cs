[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(RadaOnline.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(RadaOnline.App_Start.NinjectWebCommon), "Stop")]

namespace RadaOnline.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    using RadaOnline.Common.Logging;
    using RadaOnline.Common.Logging.Interfaces;
    using RadaOnline.Queries.Councilman;
    using RadaOnline.Queries.Councilman.Interfaces;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }
        
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }
        
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {
            RegisterSingletoneServices(kernel);
            RegisterTransientServices(kernel);
        }

        private static void RegisterSingletoneServices(IKernel kernel)
        {
            kernel.Bind<ILogger>().To<Logger>().InSingletonScope();
        }

        private static void RegisterTransientServices(IKernel kernel)
        {
            kernel.Bind<IConcilmanGetListQuery>().To<ConcilmanGetListQuery>();
        }
    }
}
