using Application.AutoMapper;
using Application.Log.Concrete;
using Application.Log.Contract;
using AutoMapper;
using Data.Concrete;
using Data.Contract;
using Service.Concrete;
using Service.Contract;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace CrossCutting.IoC
{
    public static class SimpleInjectorResolver
    {
        public static void Start()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            #region Configurando DI para AutoMapper
            var mapperconfig = AutoMapperConfig.RegisterMappings();
            container.RegisterInstance<MapperConfiguration>(mapperconfig);
            container.Register<IMapper>(() => mapperconfig.CreateMapper(container.GetInstance), Lifestyle.Scoped);
            #endregion

            #region  Configurando DI para factory de objeto de conexão
            container.Register<IConnectionFactory, ConnectionFactory>(Lifestyle.Scoped);
            #endregion

            #region Configurando DI para Repositórios
            container.Register<IAeronavesRepository, AeronavesRepository>(Lifestyle.Scoped);
            container.Register<ITiposAeronavesRepository, TiposAeronavesRepository>(Lifestyle.Scoped);
            container.Register<IAeroportosRepository, AeroportosRepository>(Lifestyle.Scoped);
            container.Register<IPlanoVooRepository, PlanoVooRepository>(Lifestyle.Scoped);
            #endregion

            #region Configurando DI para Serviços
            container.Register<IPlanoVooService, PlanoVooService>(Lifestyle.Scoped);
            container.Register<IAeronaveService, AeronaveService>(Lifestyle.Scoped);
            container.Register<IAeroportoService, AeroportoService>(Lifestyle.Scoped);
            #endregion

            #region Configurando DI para Log
            container.Register<ILog, Log>(Lifestyle.Scoped);
            #endregion

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
            new SimpleInjectorWebApiDependencyResolver(container);
        }
        

    }
}
