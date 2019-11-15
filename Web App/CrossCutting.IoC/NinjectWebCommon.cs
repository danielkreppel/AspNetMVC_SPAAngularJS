using Application.AutoMapper;
using AutoMapper;
using Data.Concrete;
using Data.Contract;
using Domain;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using Service.Concrete;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CrossCutting.IoC
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                var mapperconfig = AutoMapperConfig.RegisterMappings();

                kernel.Bind<IMapper>().ToMethod(ctx => new Mapper(mapperconfig, type => ctx.Kernel.Get(type)));

                //Repositórios
                kernel.Bind<IPlanoVooRepository, PlanoVooRepository>();
                kernel.Bind<IGenericRepository<Aeronave>, AeronavesRepository>();
                kernel.Bind<IGenericRepository<TipoAeronave>, TiposAeronavesRepository>();
                kernel.Bind<IGenericRepository<Aeroporto>, AeroportosRepository>();

                //Serviços
                kernel.Bind<IPlanoVooService, PlanoVooService>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.
        private static void RegisterServices(IKernel kernel)
        {
        }
    }
}
