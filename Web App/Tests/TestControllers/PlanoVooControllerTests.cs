using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Application.PlanoDeVooViewModels;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using System.Collections.Generic;
using Site.Controllers;
using Moq;
using Service.Contract;
using System.Web.Http;
using System.Linq;
using Application.Log.Contract;
using Application.ViewModels;

namespace Tests.TestControllers
{
    [TestClass]
    public class PlanoVooControllerTests 
    {
        private PlanoVooController _planoVooController;
        private Mock<IPlanoVooService> _planoVooServiceMock = new Mock<IPlanoVooService>();
        private Mock<ILog> _log = new Mock<ILog>();

        public PlanoVooControllerTests()
        {
            _planoVooController = new PlanoVooController(_planoVooServiceMock.Object, _log.Object);
        }

        [TestMethod]
        public async Task MetodoBuscarPlanosVoo_RetornaLista()
        {
            var listaPlanoVooModelMock = Builder<PlanoVooViewModel>.CreateListOfSize(3).Build();

            _planoVooServiceMock.Setup(m => m.BuscarPlanosVoos()).Returns(Task.FromResult<IEnumerable<PlanoVooViewModel>>(listaPlanoVooModelMock));

            var resultado = await _planoVooController.BuscarPlanosVoo();

            Assert.IsNotNull(resultado);

            var listaPlanosVoos = resultado as IEnumerable<PlanoVooViewModel>;

            Assert.IsNotNull(listaPlanosVoos);

            Assert.AreNotEqual(0, listaPlanosVoos.Count());
        }

        [TestMethod]
        public async Task MetodoSalvarPlanoVoo_Inserir()
        {
            var planoVoo = Builder<PlanoVooViewModel>.CreateNew().With(p => p.IdPlanoVoo = 0).Build();

            var resultado = await _planoVooController.SalvarPlanoVoo(planoVoo);

            var objectResultado = resultado as JsonRetornoViewModel;

            Assert.IsNotNull(objectResultado);
            
        }

        [TestMethod]
        public async Task MetodoSalvarPlanoVoo_Atualizar()
        {
            var planoVoo = Builder<PlanoVooViewModel>.CreateNew().With(p => p.IdPlanoVoo = 1).Build();

            var resultado = await _planoVooController.SalvarPlanoVoo(planoVoo);

            var objectResultado = resultado as JsonRetornoViewModel;

            Assert.IsNotNull(objectResultado);

        }

        [TestMethod]
        public async Task MetodoExcluirPlanoVoo()
        {
            var planoVoo = Builder<PlanoVooViewModel>.CreateNew().With(p => p.IdPlanoVoo = 1).Build();

            var resultado = await _planoVooController.ExcluirPlanoVoo(planoVoo);

            var objectResultado = resultado as JsonRetornoViewModel;

            Assert.IsNotNull(objectResultado);

        }

    }
}
