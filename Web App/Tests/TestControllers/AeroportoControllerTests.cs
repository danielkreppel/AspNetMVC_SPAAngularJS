using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Application.AeroportoViewModels;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using System.Collections.Generic;
using Site.Controllers;
using Moq;
using Service.Contract;
using System.Web.Http;
using System.Linq;

namespace Tests.TestControllers
{
    [TestClass]
    public class AeoportoControllerTests 
    {
        private AeroportoController _aeroportoController;
        private Mock<IAeroportoService> _aeroportoServiceMock = new Mock<IAeroportoService>();

        public AeoportoControllerTests()
        {
            _aeroportoController = new AeroportoController(_aeroportoServiceMock.Object);
        }

        [TestMethod]
        public async Task MetodoBuscarAeroportos_RetornaLista()
        {
            var listaAeroportosMock = Builder<AeroportosViewModel>.CreateListOfSize(3).Build();
            _aeroportoServiceMock.Setup(m => m.BuscarAeroportos()).Returns(Task.FromResult<IEnumerable<AeroportosViewModel>>(listaAeroportosMock));

            var resultado = await _aeroportoController.BuscarAeroportos();

            Assert.IsNotNull(resultado);

            var listaAeroportos = resultado as IEnumerable<AeroportosViewModel>;
            Assert.IsNotNull(listaAeroportos);

            Assert.AreNotEqual(0, listaAeroportos.Count());
        }
        
    }
}
